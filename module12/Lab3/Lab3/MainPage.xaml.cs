using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
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

namespace Lab3
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
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var status = await BackgroundExecutionManager.RequestAccessAsync();
            //clean
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                Debug.WriteLine(task.Value.Name);
                task.Value.Unregister(true);

            }

            var tb = new BackgroundTaskBuilder();
            tb.Name = "ZDF RSS";
            tb.TaskEntryPoint = "RuntimeComponent1.Class1";
            tb.SetTrigger(new TimeTrigger(15, false));
            tb.Register();


            base.OnNavigatedTo(e);  
        }

    }
}
