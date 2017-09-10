using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace lab2
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

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            ContactPicker cp = new ContactPicker();
                     
            cp.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);
            cp.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Address);
            cp.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);
      
            Contact contact = await cp.PickContactAsync();
            
            if (contact != null)
            {
                
                text1.Text = contact.DisplayName;
                var contactStore = await ContactManager.RequestStoreAsync();
                Contact Mycontact = await contactStore.GetContactAsync(contact.Id);
                if (Mycontact.Thumbnail != null)
                {

                    BitmapImage img = new BitmapImage();
                    IRandomAccessStreamWithContentType sr = await Mycontact.Thumbnail.OpenReadAsync();
                    img.SetSource(sr);

                    img1.Source = img;


                }

                //BitmapImage img = new BitmapImage();
                //IRandomAccessStreamWithContentType sr = await contact.SourceDisplayPicture.OpenReadAsync();
                //img.SetSource(sr);

                //img1.Source = img;

            }

        }
        
        }
    }

