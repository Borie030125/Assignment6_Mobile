using Microsoft.Maui.Controls;
using Assignment6.Models;

namespace Assignment6
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage(ContactInformation contact)
        {
            InitializeComponent();
            BindingContext = contact;
        }
    }
}
