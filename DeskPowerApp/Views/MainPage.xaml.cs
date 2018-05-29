using System;
using DeskPowerApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Template10.Services.NavigationService;
using DeskPowerApp.Model;
using Windows.UI.Xaml.Input;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace DeskPowerApp.Views
{
    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            InitializeComponent();            
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void pageHeader_Opened(object sender, object e)
        {

        }
        private void AutoSuggestBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Only get results when it was a user typing,
            // otherwise assume the value got filled in by TextMemberPath
            // or the handler for SuggestionChosen.
          
            //Set the ItemsSource to be your filtered dataset
            //sender.ItemsSource = dataset;
            List<string> _nameList = new List<string>();

            if(AutoSuggestBox.Text.Length == 0)
            {
                DraftsGrid.ItemsSource = ViewModel.Drafts;
            }

            foreach (Draft d in ViewModel.Drafts)
            {
                _nameList.Add(d.DraftTitle.ToLower());
            }
            _listSuggestion = _nameList.Where(x => x.StartsWith(AutoSuggestBox.Text.ToLower())).ToList();
                
            AutoSuggestBox.ItemsSource = _listSuggestion;
            
        }

        List<string> _listSuggestion = null;
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var tempList = new List<Draft>();
            var selectedItem = args.SelectedItem.ToString();
            
            foreach(Draft d in ViewModel.Drafts)
            {
                if (d.DraftTitle.ToLower().Contains(selectedItem))
                {
                    tempList.Add(d);
                    Debug.WriteLine(d.DraftId);
                }
            }
            DraftsGrid.ItemsSource = tempList;
        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                if (args.ChosenSuggestion != null)
                {
                    // User selected an item from the suggestion list, take an action on it here.
                }
                else
                {
                    // Use args.QueryText to determine what to do.
                    AutoSuggestBox.Text = args.ChosenSuggestion.ToString();
                }

            }
            catch
            {
                
            }
        }

        private void button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }
        private void button_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

      
    }
}