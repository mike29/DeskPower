using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DeskPowerApp.Views
{
    public static class Messages
    {
        public static async void DisplayDialogMessage(string title, string content)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
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
