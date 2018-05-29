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
        
        /// <summary>
        /// Saves the data to database.
        /// </summary>
        /// <param name="value">The value.</param>
        private async void SaveDataToDb(string value)
        {
            string Dtitle = title.Text;
            try
            {
              
                if (CurrentDate() != null)
                {
                    DateTime DraftCreatedDate = CurrentDate();
                    await DraftAccessor.SaveToDb(Dtitle, value,(DraftCategories) CategoryCombo.SelectionBoxItem, DraftCreatedDate, "ms-appx:///Assets/img/music.jpg");
                  
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

        /// <summary>
        /// Updates the draft.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Deletes the draft.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void DeleteData(object sender, RoutedEventArgs e)
        {
            selectedDraft = ((Draft)draftsList.SelectedItem);
            await DraftAccessor.DeleteDataInDb(selectedDraft);
 
        }

        /// <summary>
        /// Handles the Click event of the BoldButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = draftEditor.Document.Selection;
            if (selectedText != null)
            {
                ViewModel.BoldBtnClicked(selectedText);
               
            }
        }

        /// <summary>
        /// Handles the Click event of the ItalicButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = draftEditor.Document.Selection;
            if (selectedText != null)
            {
                ViewModel.ItalicBtnClicked(selectedText);
            }
        }

        /// <summary>
        /// Handles the Click event of the UnderlineButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = draftEditor.Document.Selection;
            if (selectedText != null)
            {
                ViewModel.Underline(selectedText);
            }
        }

        // LOCAL HELPERS
        /// <summary>
        /// retur date time.
        /// </summary>
        /// <returns></returns>
        private DateTime CurrentDate()
        {
            DateTimeOffset sourceTime = draftCalendarDatePicker.Date ?? DateTimeOffset.Now;
        
            return sourceTime.DateTime;
        }

        /// <summary>
        /// Extracts the text from text editor.
        /// </summary>
        /// <returns></returns>
        private String ExtractText()
        {
            string value = string.Empty;
            draftEditor.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out value);
            return value;
        }
    }

   
}
