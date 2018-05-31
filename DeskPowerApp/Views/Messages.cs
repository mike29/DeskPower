using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DeskPowerApp.Views
{
    public static class Messages
    {
        // TODO
        // Create one method that accepts the arguments and adjust the primary, secondary and cancel message
        // No need to add three methods
        public static async void DisplayDialogMessage(string title, string content)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = "Ok"
            };
            try
            {
                ContentDialogResult result = await noWifiDialog.ShowAsync();
            }
            catch (Exception e)
            {
                Debug.Write("Update corrupted", e.Message);
            }
           
        }

        public static async Task<bool> DisplayDeleteFileDialog(string title, string content)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = "Delete",
                SecondaryButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            
            if (result == ContentDialogResult.Primary)
            {
                return true;
            }
            else
            {
             
                return false;
            }
        }

        public static async Task<bool> DisplaySaveFileDialog(string title, string content, string primary, string secondary)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = primary,
                SecondaryButtonText = secondary,               
                CanDrag = true
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                return true;
            }
            else
            {
                // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
                return false;
            }
        }
    }
}
