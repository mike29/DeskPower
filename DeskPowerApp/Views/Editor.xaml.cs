using DeskPowerApp.Services.DraftEditorManager;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        public Editor()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;          
            
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
        /// Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
             await DraftAccessor.SaveDraft(sender, e, draftEditor);
           // draftEditor.Document.SetText(Windows.UI.Text.TextSetOptions.None, "randAccStream");
            string value = string.Empty;

            draftEditor.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out value);

           
            string Dtitle = title.Text;
            DateTimeOffset sourceTime = (DateTimeOffset)draftCalendarDatePicker.Date;
            DateTime DDate = sourceTime.DateTime;
            if (sourceTime != null)
            {

                await DraftAccessor.SaveToDb(Dtitle, value, "", DDate, "ms-appx:///Assets/img/gun.jpg");
            }
           

          //  System.Diagnostics.Debug.WriteLine(value); 
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
