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
        public Draft DraftObject { get; set;}
        
        ObservableCollection<Draft> _drafts;
        public ObservableCollection<Draft> Drafts
        {
            get
            {
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    return _drafts;
                }

                return _drafts;
            }
            set { Set(ref _drafts, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (Drafts == null)
            {
                sampleClass = new SampleData.SampleData();
                Drafts = sampleClass.DraftSamplpeData;

                DraftObject = new Draft();
            
            }

            if (suspensionState.Any())
            {
                
                // DraftObject.DraftID = suspensionState[nameof(DraftObject.DraftID)]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(DraftObject.DraftID)] = DraftObject.DraftID;
             
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), DraftObject.DraftID.ToString());

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingCustom), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
       
    }
}
