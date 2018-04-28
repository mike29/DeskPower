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
using DeskPowerApp.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.Text;

namespace DeskPowerApp.ViewModels
{
   public class EditorViewModel :ViewModelBase
    {
        private SampleData.SampleData sampleClass;
        public EditorViewModel()
        {
            sampleClass = new SampleData.SampleData();
            Drafts = sampleClass.DraftSamplpeData;
            Saved = "Some Value";
            
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

        public string Saved { get { return _saved; } set { Set(ref _saved, value); } }
        string _saved;

        
        

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
           // Saved = "NEW VALUE";
            if (Drafts != null)
            {
                Drafts = new ObservableCollection<Draft>(await DataSource.DraftData.Instance.GetDrafts());

            }
            
            if (suspensionState.Any())
            {
               
            }
            await Task.CompletedTask;
        }

            private AwaitableDelegateCommand _SaveCommand;
         /*   public AwaitableDelegateCommand SaveCommand =>
                _SaveCommand ?? (_SaveCommand = new AwaitableDelegateCommand(
                    new Func<AwaitableDelegateCommandParameter, Task>(async (param) =>
                    {


                        SaveCommand.RaiseCanExecuteChanged();
                        System.Diagnostics.Debug.WriteLine(Saved);
                       // RichEditBox d = e.Assigner();
                        await SaveFileBtnClickedAsync();
                      


                        //  SaveCommand.RaiseCanExecuteChanged();
                    })
                ));
        */

    /*    private Task SaveFileBtnClickedAsync()
        {
            System.Diagnostics.Debug.WriteLine("---- SAVE BUTTON CLICKED ---");
            // saved.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out value);
            return Task.FromResult(0); 

        }
*/
        RichEditBox draftREBS = new RichEditBox();
        
     /* public async Task OpenFileBtnClickedAsync()
        {
            // Open a text file.
            Windows.Storage.Pickers.FileOpenPicker open =
                new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".rtf");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

           
            if (file != null)
            {
                try
                {
                    Windows.Storage.Streams.IRandomAccessStream randAccStream =
                await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                    // Load the file into the Document property of the RichEditBox.
                    draftREBS.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                  
                    //        draftREBS.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf,out d);
    
                      Saved =   draftREBS.Document.GetRange(0,10).Text;
                  
                    System.Diagnostics.Debug.WriteLine("XOXOXOXOXOX" + Saved);


                }
                catch (Exception)
                {
                    
                    Windows.UI.Xaml.Controls.ContentDialog errorDialog = new Windows.UI.Xaml.Controls.ContentDialog()
                    {
                        Title = "File open error",
                        Content = "Sorry, I couldn't open the file.",
                        PrimaryButtonText = "Ok"
                    };

                    await errorDialog.ShowAsync();
                }
            }
        }*/

        private RichEditBox GetEditorBox()
        {
            throw new NotImplementedException();
        }

        public void SaveFileBtnClicked()
        {
            System.Diagnostics.Debug.WriteLine("Hello bebe");
        }

        public void BoldBtnClicked()
        {
            System.Diagnostics.Debug.WriteLine("Hello bebe");
        }

        public void ItalicBtnClicked()
        {
            System.Diagnostics.Debug.WriteLine("Hello bebe");
        }

        public void OpenFileBtnClicked()
        {
            System.Diagnostics.Debug.WriteLine("Hello bebe");
        }


    }
}
