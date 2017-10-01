using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
using Windows.Web.Syndication;

namespace RuntimeComponent1
{
    public sealed class Class1:IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferal = taskInstance.GetDeferral();
            var upd = TileUpdateManager.CreateTileUpdaterForApplication();
            upd.EnableNotificationQueue(true);
            upd.Clear();
            var client = new SyndicationClient();
            var feed = await client.RetrieveFeedAsync(new Uri("http://www.tagesschau.de/xml/rss2"));
            for (int i = 0; i < 5; i++)
            {
                var xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text03);
                xml.GetElementsByTagName("text")[0].InnerText = feed.Items[i].Title.Text;
                upd.Update(new TileNotification(xml));
            }
            deferal.Complete();
        }
    }
}
