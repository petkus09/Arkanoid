using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SharpGIS.CustomCursor;

namespace CustomCursorSample
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dynamic == null) return;
			var item = e.AddedItems[0] as ComboBoxItem;
			if (item.Tag == null)
				dynamic.SetValue(CustomCursor.CursorTemplateProperty, null);
			else
				dynamic.SetValue(CustomCursor.CursorTemplateProperty, Resources[item.Tag as string] as DataTemplate);
		}
	}
}
