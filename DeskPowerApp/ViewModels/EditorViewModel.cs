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
        /// <summary>
        /// The category list
        /// Set category enum to the list and is binded to UI combo
        /// </summary>
        public List<DraftCategories> CategoryList = Enum.GetValues(typeof(DraftCategories))
                                    .Cast<DraftCategories>()
                                    .ToList();

           
        ObservableCollection<Draft> _drafts;
        /// <summary>
        /// Gets or sets the drafts.
        /// </summary>
        /// <value>
        /// The drafts.
        /// </value>
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
                Drafts = await DataSource.DraftData.Instance.GetDrafts();

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
        // RichEditBox draftREBS = new RichEditBox();
        

        /// <summary>
        /// Bolds the text selected.
        /// </summary>
        /// <param name="selectedText">The selected text.</param>
        public void BoldBtnClicked(Windows.UI.Text.ITextSelection selectedText)
        {
            Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
            charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
            selectedText.CharacterFormat = charFormatting;
        }

        /// <summary>
        /// Italics the text selected.
        /// </summary>
        /// <param name="selectedText">The selected text.</param>
        public void ItalicBtnClicked(Windows.UI.Text.ITextSelection selectedText)
        {
            Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
            charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
            selectedText.CharacterFormat = charFormatting;
        }
        
        /// <summary>
        /// Underlines the specified selected text.
        /// </summary>
        /// <param name="selectedText">The selected text.</param>
        public void Underline(Windows.UI.Text.ITextSelection selectedText)
        {
            Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
            if (charFormatting.Underline == Windows.UI.Text.UnderlineType.None)
            {
                charFormatting.Underline = Windows.UI.Text.UnderlineType.Single;
            }
            else
            {
                charFormatting.Underline = Windows.UI.Text.UnderlineType.None;
            }
            selectedText.CharacterFormat = charFormatting;
        }


    }
}
