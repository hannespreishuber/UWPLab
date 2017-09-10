using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace lab4
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

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            var kreis = new Ellipse();
            kreis.Width = 100;
                kreis.Height = 100;

            // kreis.Fill = "Red";
            kreis.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
            StackPanel1.Children.Add(kreis);

        }

        private void Ellipse_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            args.Data.SetText("demo");
                args.DragUI.SetContentFromDataPackage();
            }

        private void Ellipse_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            pos.X += e.Delta.Translation.X;
            pos.Y += e.Delta.Translation.Y;

        }

        private void StackPanel1_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "Copy";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private void StackPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.DragUIOverride.Caption = "Drop here to insert text";
        }
    }
}
