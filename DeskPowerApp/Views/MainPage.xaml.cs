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
        private int isEmprty = 0;
        public MainPage()
        {
            InitializeComponent();            
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        /// <summary>
        /// Handles the KeyDown event of the AutoSuggestBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyRoutedEventArgs"/> instance containing the event data.</param>
        private void AutoSuggestBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // create a list of categories to be viewed in the combo
            List<string> _nameList = new List<string>();

            // Hold intial drafts from viewModel if user didn't search for one.
            if(AutoSuggestBox.Text.Length == isEmprty)
            {
                DraftsGrid.ItemsSource = ViewModel.Drafts;
            }
            //Assign the category 
            foreach (Draft d in ViewModel.Drafts)
            {
                _nameList.Add(d.DraftTitle.ToLower());
            }

            // Assign to the suggestion
            _listSuggestion = _nameList.Where(x => x.StartsWith(AutoSuggestBox.Text.ToLower())).ToList();                
            AutoSuggestBox.ItemsSource = _listSuggestion;
            
        }

        List<string> _listSuggestion = null;
        /// <summary>
        /// Automatics the suggest box suggestion chosen.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="AutoSuggestBoxSuggestionChosenEventArgs"/> instance containing the event data.</param>
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // A temporary list that holds the search match drafts
            var tempList = new List<Draft>();
            var selectedItem = args.SelectedItem.ToString();
            
            foreach(Draft d in ViewModel.Drafts)
            {
                if (d.DraftTitle.ToLower().Contains(selectedItem))
                {
                    tempList.Add(d);                   
                }
            }
            // Display the drafts that match the search
            DraftsGrid.ItemsSource = tempList;
        }

       

        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
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
            catch (NullReferenceException e)
            {

                Messages.DisplayDialogMessage("Insert text", "Write some text before searching");

            }

        }

    }
      
    }
