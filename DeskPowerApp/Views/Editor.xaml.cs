using DeskPowerApp.Model;
using DeskPowerApp.Services.DraftEditorManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DeskPowerApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Editor : Page
    {

        Draft selectedDraft = null;
        Draft newUpdatedDraft;

        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        public Editor()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
          
        }

        private  void DraftSelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            selectedDraft = ((Draft)draftsList.SelectedItem);
            //Debug.WriteLine("Selected: {0}", selectedDraft.DraftId);
            if (selectedDraft != null)
            {
                 DraftAccessor.OpenDraftFromDb(draftEditor, selectedDraft);
            }
            
        }
        

        /// <summary>
        /// Handles the Click event of the OpenButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            await DraftAccessor.OpenDraft(sender, e, draftEditor); 
          
        }
        private String ExtractText()
        {
            string value = string.Empty;
            draftEditor.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out value);
            return value;
        }

        /// <summary>
        /// 
        /// Handles the Click event of the SaveButton control.
        /// After it calls saveDraft from Draft Accessor (stores in harddisk locally),
        /// It calls SaveDataToDb method which is responsibile for storing to database
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Store to local
             await DraftAccessor.SaveDraft(sender, e, draftEditor);
            // draftEditor.Document.SetText(Windows.UI.Text.TextSetOptions.None, "randAccStream");
            string textValue = ExtractText();

            // Store to database
            SaveDataToDb(textValue);
        }

        private DateTime CurrentDate()
        {           
            DateTimeOffset sourceTime = draftCalendarDatePicker.Date ?? DateTimeOffset.Now;
            Debug.Write((DateTimeOffset)draftCalendarDatePicker.Date);
            return sourceTime.DateTime;
        }

        private async void SaveDataToDb(string value)
        {
            string Dtitle = title.Text;
            try
            {
              
                if (CurrentDate() != null)
                {
                    DateTime DraftCreatedDate = CurrentDate();
                    await DraftAccessor.SaveToDb(Dtitle, value, CategoryCombo.SelectionBoxItem.ToString(), DraftCreatedDate, "ms-appx:///Assets/img/music.jpg");
                }
                else
                {
                    //TODO
                    // return meaningfull error to user
                    Debug.Write("no date & data not stored");
                }
            }
            catch
            {
                Debug.Write("error occured accessing data");
            }
        }
        
        private async void UpdateData(object sender, RoutedEventArgs e)
        {
            string textValue = ExtractText();
            DateTime DraftCreatedDate = CurrentDate();

            newUpdatedDraft = new Model.Draft()
            {
                DraftTitle = (title.Text == "") ? selectedDraft.DraftTitle : title.Text ,
                DraftContent = textValue,
                DraftCategory = (DraftCategories) CategoryCombo.SelectionBoxItem,
                DraftCreatedDate = (DraftCreatedDate == null) ? selectedDraft.DraftCreatedDate : DraftCreatedDate,
                DraftImageUrl = "ms-appx:///Assets/img/photo-1504.jpg",

            };
        
            selectedDraft = ((Draft)draftsList.SelectedItem);
            await DraftAccessor.UpdateDataInDb(selectedDraft, newUpdatedDraft);            
        }

        private async void DeleteData(object sender, RoutedEventArgs e)
        {
            selectedDraft = ((Draft)draftsList.SelectedItem);
            await DraftAccessor.DeleteDataInDb(selectedDraft);
 
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = draftEditor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = draftEditor.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = draftEditor.Document.Selection;
            if (selectedText != null)
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

   
}
