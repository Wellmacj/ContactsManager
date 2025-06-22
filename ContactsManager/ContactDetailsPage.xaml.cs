using Microsoft.Maui.Controls;

namespace ContactsManager
{
    public partial class ContactDetailsPage : ContentPage
    {
        public Contact Contact { get; set; }

        public ContactDetailsPage(Contact contact)
        {
            InitializeComponent();
            Contact = contact;
            BindingContext = this;
        }

        // Navigate back to the Contacts Page when "Back" button is pressed
        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
