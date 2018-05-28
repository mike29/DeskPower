using DeskPowerApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace DeskPowerApp.ViewModels
{
    public class DetailDraftViewModel : ViewModelBase
    {
        public ObservableCollection<Draft> _drafts;
        public Draft DraftObject { get; set; }
        public ObservableCollection<Draft> Drafts
        {
            get
            {
                return _drafts;
            }
            set { Set(ref _drafts, value); }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            Drafts = new ObservableCollection<Draft>(await DataSource.DraftData.Instance.GetDrafts());
        }
    }
    
}
