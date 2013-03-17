/*
DISCLAIMER: The sample code described herein is provided on an "as is" basis, without warranty of any kind, to the 
fullest extent permitted by law. Both Microsoft and I do not warrant or guarantee the individual success developers 
may have in implementing the sample code on their development platforms or in using their own Web server configurations. 
Microsoft and I do not warrant, guarantee or make any representations regarding the use, results of use, accuracy, 
timeliness or completeness of any data or information relating to the sample code. Microsoft and I disclaim all 
warranties, express or implied, and in particular, disclaims all warranties of merchantability, fitness for a 
particular purpose, and warranties related to the code, or any service or software related thereto. 
Microsoft and I shall not be liable for any direct, indirect or consequential damages or costs of any type 
arising out of any action taken by you or others related to the sample code.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CustomCursorDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // Window.Current.CoreWindow.PointerCursor =  new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Custom, 0/*How to get this ID?*/);
        private void Button_ChangeCursor_Click_1(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 0 );
        }

        private void Button_RestoreCursor_Click_1(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow,0);
        }

        private void Button_CustomCursor_Click_1(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Custom, 101);
        }
    }
}
