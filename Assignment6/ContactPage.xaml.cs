using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Assignment6.Models;

namespace Assignment6
{
    public partial class ContactPage : ContentPage
    {
        public ObservableCollection<GroupedContact> GroupedContacts { get; set; }

        public ContactPage()
        {
            InitializeComponent();
            GroupedContacts = CreateGroupedContacts();
            BindingContext = this;
        }

        private ObservableCollection<GroupedContact> CreateGroupedContacts()
        {
            var contacts = new List<ContactInformation>
            {
                new ContactInformation { Name = "Alice Anderson", Email="alice@example.com", PhoneNumber="123-456-0001", Description="Friend A", Photo="pic1.png" },
                new ContactInformation { Name = "Aaron A.",       Email="aaron@example.com", PhoneNumber="123-456-0002", Description="Friend B", Photo="pic1.pngG" },
                new ContactInformation { Name = "Amanda Adams",   Email="amanda@example.com", PhoneNumber="123-456-0003", Description="Friend C", Photo="pic1.png" },
                new ContactInformation { Name = "Andrew Applegate", Email="andrew@example.com", PhoneNumber="123-456-0004", Description="Friend D", Photo="pic1.png" },
                new ContactInformation { Name = "Annie Arrow",    Email="annie@example.com", PhoneNumber="123-456-0005", Description="Friend E", Photo="pic2.png" },

                new ContactInformation { Name = "Brian Brown",    Email="brian@example.com", PhoneNumber="123-456-0006", Description="Friend F", Photo="Contacts_Avatars/Pic2.PNG" },
                new ContactInformation { Name = "Bella Baker",    Email="bella@example.com", PhoneNumber="123-456-0007", Description="Friend G", Photo="Contacts_Avatars/Pic2.PNG" },
                new ContactInformation { Name = "Bob Black",      Email="bob@example.com", PhoneNumber="123-456-0008", Description="Friend H", Photo="Contacts_Avatars/Pic2.PNG" },

                new ContactInformation { Name = "Charlie Clark",  Email="charlie@example.com", PhoneNumber="123-456-0009", Description="Friend I", Photo="Contacts_Avatars/Pic3.PNG" },
                new ContactInformation { Name = "Cathy Carter",   Email="cathy@example.com", PhoneNumber="123-456-0010", Description="Friend J", Photo="Contacts_Avatars/Pic3.PNG" },
                new ContactInformation { Name = "Chris Cox",      Email="chris@example.com", PhoneNumber="123-456-0011", Description="Friend K", Photo="Contacts_Avatars/Pic3.PNG" },

                new ContactInformation { Name = "David Davis",    Email="david@example.com", PhoneNumber="123-456-0012", Description="Friend L", Photo="Contacts_Avatars/Pic3.PNG" },
                new ContactInformation { Name = "Diana Dawson",   Email="diana@example.com", PhoneNumber="123-456-0013", Description="Friend M", Photo="Contacts_Avatars/Pic4.PNG" },
                new ContactInformation { Name = "Derek D.",       Email="derek@example.com", PhoneNumber="123-456-0014", Description="Friend N", Photo="Contacts_Avatars/Pic4.PNG" },

                new ContactInformation { Name = "Ethan Edwards",  Email="ethan@example.com", PhoneNumber="123-456-0015", Description="Friend O", Photo="Contacts_Avatars/Pic4.PNG" },
            };

            var grouped = contacts
                .GroupBy(c => c.Name.Substring(0, 1).ToUpper())
                .Select(g => new GroupedContact(g.Key, g.OrderBy(c => c.Name)))
                .OrderBy(g => g.Key);

            return new ObservableCollection<GroupedContact>(grouped);
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is ContactInformation selectedContact)
            {
                await Navigation.PushAsync(new ContactDetailsPage(selectedContact));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
