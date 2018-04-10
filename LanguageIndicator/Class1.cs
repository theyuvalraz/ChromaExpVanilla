using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Text.Core;

namespace LanguageIndicator
{

    public sealed class Indicator : IBackgroundTask
    {
        private BackgroundTaskDeferral backgroundTaskDeferral;
        private AppServiceConnection appServiceconnection;
        private CoreTextServicesManager menager = CoreTextServicesManager.GetForCurrentView();

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.backgroundTaskDeferral = taskInstance.GetDeferral();
            CoreTextServicesManager textServiceManager = CoreTextServicesManager.GetForCurrentView();
            textServiceManager.InputLanguageChanged += TextServiceManager_InputLanguageChanged;

        }
        private async void TextServiceManager_InputLanguageChanged(CoreTextServicesManager sender, object args)
        {
            var thing = menager.InputLanguage.DisplayName;
            MessageDialog showDialog = new MessageDialog(thing);

            showDialog.Commands.Add(new UICommand("Yes") { Id = 0 });

            showDialog.Commands.Add(new UICommand("No") { Id = 1 });

            showDialog.DefaultCommandIndex = 0;

            showDialog.CancelCommandIndex = 1;

            var result = await showDialog.ShowAsync();

            if ((int)result.Id == 0)

            {

                //do your task 

            }

            else

            {

                //skip your task 

            }
            Debug.WriteLine("Keyboard layout is changed!");
        }

    }
}
