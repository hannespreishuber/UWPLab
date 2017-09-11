using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json; 

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace Lab1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static List<Type> _knownTypes = new List<Type>();

        public List<Customer> Customers = new List<Customer>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///XMLFile1.xml"));
            using (IInputStream inStream = await file.OpenSequentialReadAsync())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Customer>));
                Customers = (List<Customer>)serializer.ReadObject(inStream.AsStreamForRead());
            }


        }

        private async void Button_Click_1Async(object sender, RoutedEventArgs e)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<Customer>));
            serializer.WriteObject(stream1, Customers);
            Windows.Storage.StorageFile file = await KnownFolders.DocumentsLibrary.CreateFileAsync("nortwhind.xml", CreationCollisionOption.ReplaceExisting);
            using (Stream fileStream = await file.OpenStreamForWriteAsync())
            {
                stream1.Seek(0, SeekOrigin.Begin);
                await stream1.CopyToAsync(fileStream);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void ButtonJson_Click(object sender, RoutedEventArgs e)
        {
            var file = await KnownFolders.DocumentsLibrary.
                CreateFileAsync("nortwhind.json", CreationCollisionOption.ReplaceExisting);

            var data = await file.OpenStreamForWriteAsync();

            using (StreamWriter r = new StreamWriter(data))
            {
                string json = JsonConvert.SerializeObject(Customers,
                    Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
                r.Write(json);

            }

        }
    }
}
