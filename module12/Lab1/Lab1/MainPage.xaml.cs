using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Net.Http;
using Windows.Storage;
using Windows.Networking.BackgroundTransfer;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using Windows.UI.Core;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace Lab1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<DownloadOperation> activeDownloads;
        private CancellationTokenSource cts;
        public ObservableCollection<String> dateien = new ObservableCollection<string>();
        public MainPage()
        {
            cts = new CancellationTokenSource();
            this.InitializeComponent();


        }



        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var daten = await client.GetStringAsync("http://tv.ppedv.de/music/list.aspx");

            var files = daten.Split(new string[] { System.Environment.NewLine },
                System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var f in files)
            {
                var x = f.Split(' ');
                dateien.Add(x[1]);


            }


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var grp = new BackgroundTransferCompletionGroup();

            BackgroundDownloader downloader = new BackgroundDownloader(grp);

            foreach (var f in dateien)
            {
                var saveFile = await KnownFolders.MusicLibrary.CreateFileAsync(
                           f, CreationCollisionOption.ReplaceExisting);
                
                DownloadOperation download = downloader.CreateDownload( 
                new Uri("http://tv.ppedv.de/music/" + f),
                saveFile);
                download.Priority = BackgroundTransferPriority.Default;


                var progressCallback = new Progress<DownloadOperation>(operation =>
                {

                    if (download.Progress.TotalBytesToReceive > 0)
                    {
                        var percent = download.Progress.BytesReceived * 100 / download.Progress.TotalBytesToReceive;
                        // TODO report percent
                        progressbar1.Value = percent * 100;
                    }
                });
                await download.StartAsync();


            }


        }

     
        private void DownloadProgress(DownloadOperation download)
        {
            // DownloadOperation.Progress is updated in real-time while the operation is ongoing. Therefore,
            // we must make a local copy so that we can have a consistent view of that ever-changing state
            // throughout this method's lifetime.
            BackgroundDownloadProgress currentProgress = download.Progress;

            MarshalLog(String.Format(CultureInfo.CurrentCulture, "Progress: {0}, Status: {1}", download.Guid,
                currentProgress.Status));

            double percent = 100;
            if (currentProgress.TotalBytesToReceive > 0)
            {
                percent = currentProgress.BytesReceived * 100 / currentProgress.TotalBytesToReceive;
            }

            MarshalLog(String.Format(
                CultureInfo.CurrentCulture,
                " - Transfered bytes: {0} of {1}, {2}%",
                currentProgress.BytesReceived,
                currentProgress.TotalBytesToReceive,
                percent));

            if (currentProgress.HasRestarted)
            {
                MarshalLog(" - Download restarted");
            }

            if (currentProgress.HasResponseChanged)
            {
                // We have received new response headers from the server.
                // Be aware that GetResponseInformation() returns null for non-HTTP transfers (e.g., FTP).
                ResponseInformation response = download.GetResponseInformation();
                int headersCount = response != null ? response.Headers.Count : 0;

                MarshalLog(" - Response updated; Header count: " + headersCount);

                // If you want to stream the response data this is a good time to start.
                // download.GetResultStreamAt(0);
            }
        }
        private void MarshalLog(string value)
        {
            var ignore = this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Liste2.Items.Add(value);
               // Log(value);
            });
        }
        private void LogStatus(string message, NotifyType type)
        {
            NotifyUser(message, type);
          
        }
        public void NotifyUser(string strMessage, NotifyType type)
        {
                var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Liste2.Items.Add(strMessage));
           }
        public enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };

    }
}