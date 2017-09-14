using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Test2
{
    public sealed partial class chatbubble : UserControl
    {
        public static readonly DependencyProperty Text1Property = 
            DependencyProperty.Register(
         "Text1", typeof(string), typeof(chatbubble),
          new PropertyMetadata(""));
        public string Text1
        {
            get { return (string) GetValue(Text1Property) ; }
            set { SetValue(Text1Property, value); }
        }



        private Boolean _Leftright;
        public Boolean Leftright {
            set {
                _Leftright = value;
                if (_Leftright)
                {
                   PolyLeft.Visibility=Visibility.Collapsed;
                    PolyRight.Visibility = Visibility.Visible;

                    Panelrechtslinks.HorizontalAlignment = HorizontalAlignment.Right;
                }
                else
                {

                    PolyLeft.Visibility = Visibility.Visible;
                    PolyRight.Visibility = Visibility.Collapsed;

                    Panelrechtslinks.HorizontalAlignment = HorizontalAlignment.Left;

                }

            } }
      
 
        public chatbubble()
        {
            this.InitializeComponent();
         
      
        }
    }
}
