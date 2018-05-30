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
       
       // private SampleData.SampleData sampleClass;
        public DetailPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                DraftIdValue = "Designtime value";
            }
        }
        /// <summary>
        /// Hold the value of clicked list rfom detail page similar drafts
        /// </summary>
        public Draft DetailClickedDraft;

        //Hold clicked from detail page grid view
        public Draft DraftObject { get; set; } = new Draft();


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

        //TODO
        /// <summary>
        /// When user select one of the grid view items from the detail page, they should be displayed 
        /// </summary>
        public void DraftSelected ()
        {
            DetailClickedDraft = DraftObject;
            System.Diagnostics.Debug.WriteLine(".....Display selected item in UI", DraftObject.DraftTitle);
        }


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
            
            // TODO
            // Maybe it's not neccssary to send a get request again. use the object value and select from there
            // sampleClass = new SampleData.SampleData();         
            Drafts = await DataSource.DraftData.Instance.GetDrafts();

            /*
            // When user clicked a draft from main page the id will be taken here
            // And used to select the clicked one
            // Select the clicked draft by ID
            */
            foreach (Draft _draft in Drafts)
             {
                 if (_draft.DraftId == tempIntId)
                 {                    
                     if (Drafts != null)
                     {                   
                         DetailClickedDraft = _draft;
                     }
                 }                 
             }

            await Task.CompletedTask;
           
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {      
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }
}
