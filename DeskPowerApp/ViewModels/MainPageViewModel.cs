using Template10.Mvvm;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using DeskPowerApp.Model;
using System.Diagnostics;

namespace DeskPowerApp.ViewModels
{
    /// <summary>
    /// The viewmodel for the view that display all drafts
    /// </summary>
    /// <seealso cref="Template10.Mvvm.ViewModelBase" />
    public class MainPageViewModel : ViewModelBase
    {

        /// <summary>
        /// The sample class that holds a random placeholder data for design mode
        /// </summary>
        private SampleData.SampleData sampleClass;
        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                 sampleClass = new SampleData.SampleData();
                 Drafts = sampleClass.DraftSamplpeData;
            }
        }
        
        public Draft DraftObject { get; set; } = new Draft();
        public ObservableCollection<Draft> Drafts { get; set; }


        /// <summary>
        /// Called when [navigated to asynchronous].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="suspensionState">State of the suspension.</param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            // Get thje drafts when navigated to
            if (Drafts == null)
            {
                Drafts = await DataSource.DraftData.Instance.GetDrafts();
            }

        }

        /// <summary>
        /// Called when [navigated from asynchronous].
        /// </summary>
        /// <param name="suspensionState">State of the suspension.</param>
        /// <param name="suspending">if set to <c>true</c> [suspending].</param>
        /// <returns></returns>
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {      
            await Task.CompletedTask;
        }

        /// <summary>
        /// Raises the <see cref="E:NavigatingFromAsync" /> event.
        /// </summary>
        /// <param name="args">The <see cref="NavigatingEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        //TODO
        // Throughs not set instance of an object error, when navigating to other pages before searching
        public void GotoDetailsPage() {
            try
            {
                if (DraftObject.DraftId.ToString() != null)
                {
                    NavigationService.Navigate(typeof(Views.DetailPage), DraftObject.DraftId.ToString());
                }
                
            }
            finally
            {
                // When copying the draft object the ID will start from null. A same navigation to detail error that caused the navigate to detail occurs on the copied list also
                Debug.Write("Null value on ID exception");
            }
           
        }
           

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingCustom), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

            
        
        
        
        
        /* public async Task<BitmapImage> GetImageUrlAsync(string url)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {              
                //  byte[] imageData = DownloadData(https://images.pexels.com/photos/34950/pexels-photo.jpg?auto=compress&cs=tinysrgb&h=350); //DownloadData function from here

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                byte[] img = await response.Content.ReadAsByteArrayAsync();
                InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
                DataWriter writer = new DataWriter(randomAccessStream.GetOutputStreamAt(0));

                writer.WriteBytes(img);
                await writer.StoreAsync();
                bitmapImage.SetSource(randomAccessStream);
                Debug.WriteLine(bitmapImage.UriSource);
                return bitmapImage;

            } catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return bitmapImage;
            }   
        }*/

      
    
    }
}
