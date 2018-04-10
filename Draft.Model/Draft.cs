using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPowerApp.Model
{
    public class Draft
    {
        public int DraftID { get; set; }
        public string DrafTitle { get; set; }
        public string DraftContent { get; set; }
        public DraftCategories DraftCategory { get; set; }
        public string DraftImage { get; set; }
        public DateTime DraftCreatedDate { get; set; }


        public Draft()
        {
            this.DraftCreatedDate = DateTime.Now; 
        }

    }
}
    public enum DraftCategories
    {
        Sport,
        Poletic,
        Entertainment,
        History,
        Blog


    }

