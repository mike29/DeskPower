using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace DeskPowerApp.Model
{
    public class Person: INotifyPropertyChanged
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set;}    
        public string Position { get; set; }

        public virtual ObservableCollection<Draft> Drafts { get; set;  }

        public Person()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
