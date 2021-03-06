﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SharpGIS.CustomCursor
{
	public class CustomCursor
	{
		private FrameworkElement element;
		private Cursor originalCursor;
		System.Windows.Controls.Primitives.Popup cursorContainer;
		private static readonly DependencyProperty CustomCursorProperty =
			DependencyProperty.RegisterAttached("CustomCursor", typeof(CustomCursor), typeof(CustomCursor), null);

		private CustomCursor(FrameworkElement element, DataTemplate template)
		{
			this.element = element;
			element.SetValue(CustomCursorProperty, this);
			originalCursor = element.Cursor;
			element.Cursor = Cursors.None;
			element.MouseLeave += element_MouseLeave;
			element.MouseMove += element_MouseMove;
			cursorContainer = new System.Windows.Controls.Primitives.Popup()
			{
				IsOpen = false,
				Child = new ContentControl()
				{
					ContentTemplate = template,
					IsHitTestVisible = false,
					RenderTransform = new TranslateTransform()
				}
			};
			cursorContainer.IsHitTestVisible = false;
		}

		private void element_MouseMove(object sender, MouseEventArgs e)
		{
			cursorContainer.IsOpen = true;
			var p = e.GetPosition(null);
			var t = (cursorContainer.Child.RenderTransform as TranslateTransform);
			t.X = p.X;
			t.Y = p.Y;
		}

		private void element_MouseLeave(object sender, MouseEventArgs e)
		{
			cursorContainer.IsOpen = false;
		}

		private void Dispose()
		{
			element.MouseLeave -= element_MouseLeave;
			element.MouseMove -= element_MouseMove;
			element.ClearValue(CustomCursorProperty);
			element.Cursor = originalCursor;
			cursorContainer.IsOpen = false;
			(cursorContainer.Child as ContentControl).ContentTemplate = null;
			cursorContainer.Child = null;
			cursorContainer = null;
		}

		public static DataTemplate GetCursorTemplate(DependencyObject obj)
		{
			return (DataTemplate)obj.GetValue(CursorTemplateProperty);
		}

		public static void SetCursorTemplate(DependencyObject obj, DataTemplate value)
		{
			obj.SetValue(CursorTemplateProperty, value);
		}

		public static readonly DependencyProperty CursorTemplateProperty =
			DependencyProperty.RegisterAttached("CursorTemplate", typeof(DataTemplate), typeof(CustomCursor), new PropertyMetadata(OnCursorTemplatePropertyChanged));

		private static void OnCursorTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (!(d is FrameworkElement))
				throw new ArgumentOutOfRangeException("Property can only be attached to FrameworkElements");
			var element = (d as FrameworkElement);
			if (e.OldValue is DataTemplate)
			{
				(element.GetValue(CustomCursorProperty) as CustomCursor).Dispose();
			}
			if(e.NewValue is DataTemplate)
				new CustomCursor(element, e.NewValue as DataTemplate);
		}
	}
}
