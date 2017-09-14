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

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace lab4
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public AdressenVM MyVM { get; set; } = new AdressenVM();
     
        public MainPage()
        {
            this.InitializeComponent();
        }
        

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

        await MyVM.load();
            var q = from t in MyVM.Personen
                    group t by t.Name[0] into FirstLetter
                    select FirstLetter;

            cvs1.Source = q;
            ZoomOutView1.ItemsSource = cvs1.View.CollectionGroups;
        }
    }
}
