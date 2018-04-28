using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using DeskPowerApp.Model;

namespace DeskPowerApp.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
       
        private SampleData.SampleData sampleClass;
        public DetailPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                DraftIdValue = "Designtime value";
            }
        }
       public Draft DetailClickedDraft;
        

        ObservableCollection<Draft> _drafts;
        public ObservableCollection<Draft> Drafts
        {
            get
            {
               return _drafts;
            }
            set { Set(ref _drafts, value); }
        }

        /// <summary>
        /// The identifier Id value
        /// </summary>
        private string _IdValue = "NO ID";

        /// <summary>
        /// Gets or sets the draft identifier value.
        /// </summary>
        /// <value>
        /// The draft identifier value.
        /// </value>
        public string DraftIdValue { get { return _IdValue; } set { Set(ref _IdValue, value); } }
        
        /// <summary>
        /// Called when [navigated to asynchronous].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="suspensionState">State of the suspension.</param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            DraftIdValue = (suspensionState.ContainsKey(nameof(DraftIdValue))) ? suspensionState[nameof(DraftIdValue)]?.ToString() : parameter?.ToString();
            int tempIntId = int.Parse(DraftIdValue);

            
                sampleClass = new SampleData.SampleData();
                Drafts = sampleClass.DraftSamplpeData;


             foreach (Draft _draft in Drafts)
             {
                 if (_draft.DraftId == tempIntId)
                 {
                     System.Diagnostics.Debug.WriteLine(_draft.DraftId + " " + tempIntId);
                 if (Drafts != null)
                 {
                        ///
                        /// clear the observable collection
                        ///
                        // Drafts.Clear();
                        DetailClickedDraft = _draft;
                 }

                 }
                 
             }


            await Task.CompletedTask;
            System.Diagnostics.Debug.WriteLine("..... "+ DraftIdValue);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                //suspensionState[nameof(DraftIdValue)] = DraftIdValue;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }
}
