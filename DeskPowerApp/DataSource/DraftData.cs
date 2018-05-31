using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeskPowerApp.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace DeskPowerApp.DataSource
{
   public class DraftData
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static DraftData Instance { get; } = new DraftData();

        private const string baseUri = "http://localhost:61251/api/";

        /// <summary>
        /// The client
        /// </summary>
        HttpClient _client;

        /// <summary>
        /// Prevents a default instance of the <see cref="DraftData" /> class from being created.
        /// </summary>
        private DraftData()
        {
            _client = new HttpClient
                {
                    BaseAddress = new Uri(baseUri)

                };
        }

        /// <summary>
        /// Gets the drafts.
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Draft>> GetDrafts()
        {
            var json = await _client.GetStringAsync("drafts").ConfigureAwait(false);
            ObservableCollection<Draft> drafts = JsonConvert.DeserializeObject<ObservableCollection<Draft>>(json);
            return drafts; 
        }

        /// <summary>
        /// Deletes the drafts.
        /// </summary>
        /// <param name="draft">The course.</param>
        /// <returns></returns>
        public async Task<bool> DeleteDrafts(Draft draft)
        {
            var response = await _client.DeleteAsync($"drafts\\{draft.DraftId}").ConfigureAwait(false);
            return response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound; 

        }

        /// <summary>
        /// Adds the draft.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <returns></returns>
        public async Task<bool> AddDraft(Draft draft)
        {
            string theDraft  = JsonConvert.SerializeObject(draft);
            var response = await _client.PostAsync("drafts", new StringContent(theDraft, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Puts the draft.
        /// </summary>
        /// <param name="draft">The draft.</param>
        /// <returns></returns>
        public async Task<bool> PutDraft(Draft draft, Draft newUpdateDraft)
        {
            try
            {
                await DeleteDrafts(draft);
                await AddDraft(newUpdateDraft);
                return true;
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }



    }
}
