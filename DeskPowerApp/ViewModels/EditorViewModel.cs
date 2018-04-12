using Template10.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using DeskPowerApp.Model;

namespace DeskPowerApp.ViewModels
{
   public class EditorViewModel :ViewModelBase
    {
        private SampleData.SampleData sampleClass;
        public EditorViewModel()
        {
            sampleClass = new SampleData.SampleData();
            Drafts = sampleClass.DraftSamplpeData;
        }

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
            }

            if (suspensionState.Any())
            {
               
            }
            await Task.CompletedTask;
        }



    }
}
