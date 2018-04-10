using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskPowerApp.Model
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set;}    
        public string Position { get; set; }

        public  ObservableCollection<Draft> WrittenDrafts { get; set;  }

        public Person()
        {

        }

    }
}
