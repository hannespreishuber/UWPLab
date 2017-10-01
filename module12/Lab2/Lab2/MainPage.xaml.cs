using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Xml.Dom;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace Lab2
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string toastVisual =
$@"<toast launch='app - defined - string'>
 <visual>
   <binding template='ToastGeneric'>
    <text>Hallo</text>
    <text>Welt</text>
    <image src='Assets/Square44x44Logo.scale-200.png'/>
    <image src='Assets/Square44x44Logo.scale-200.png' placement='appLogoOverride' hint-crop='circle'/>
  </binding>
</visual>
</toast>";

            XmlDocument toastXml = new XmlDocument();
            toastXml.LoadXml(toastVisual);



            var toast = new ToastNotification(toastXml);
            toast.SuppressPopup = true;
           
            ToastNotificationManager.CreateToastNotifier().Show(toast);

        }
    }
}
