using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using DeskPowerApp.Model;
using System.Diagnostics;
namespace DeskPowerApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
       
        private SampleData.SampleData sampleClass;
        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                
            }
        }

        //public Draft t;
        public Draft DraftObject { get; set; } = new Draft();
        public ObservableCollection<Draft> Drafts { get; set; }

        /// <summary>
        /// Called when [navigated to asynchronous].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="suspensionState">State of the suspension.</param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (Drafts == null)
            {
                Drafts = await DataSource.DraftData.Instance.GetDrafts();
                //Drafts = new ObservableCollection<Draft>(await DataSource.DraftData.Instance.GetDrafts());
                // sampleClass = new SampleData.SampleData();
                // Drafts = sampleClass.DraftSamplpeData;
                
            
            }

            //if (suspensionState.Any())
            //{
                
                // DraftObject.DraftId = suspensionState[nameof(DraftObject.DraftId)]?.ToString();
            //}
            //await Task.CompletedTask;

        }

       /* public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(DraftObject.DraftId)] = DraftObject.DraftId;
             
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
        */

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), DraftObject.DraftId.ToString());

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingCustom), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);


        /* public void Test()
         {
             //Slett funksjon og sett OnClick i MainPage.xaml til "GotoDetailsPage()"
             Debug.WriteLine("TEST: " + DraftObject);
             GotoDetailsPage();
         }*/

    }
}
