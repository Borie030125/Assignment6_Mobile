using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.Models
{
    public class GroupedContact : ObservableCollection<ContactInformation>
    {
        public string Key { get; set; }

        public GroupedContact(string key, IEnumerable<ContactInformation> contacts)
            : base(contacts)
        {
            Key = key;
        }
    }
}