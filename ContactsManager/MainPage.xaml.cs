using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContactsManager
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Grouping<string, Contact>> ContactsGrouped { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Example contacts data
            var contacts = ContactData.GetContacts();

            // Group contacts by the first letter of their name
            ContactsGrouped = new ObservableCollection<Grouping<string, Contact>>(
                contacts
                    .GroupBy(c => c.Name[0].ToString().ToUpper())
                    .Select(g => new Grouping<string, Contact>(g.Key, g))
                    .OrderBy(g => g.Key)
            );

            BindingContext = this;
        }

        // Handle the selection of a contact and navigate to the details page
        private async void OnContactSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                // Get the selected contact
                var selectedContact = e.CurrentSelection[0] as Contact;

                if (selectedContact != null)
                {
                    // Navigate to the ContactDetailsPage, passing the selected contact
                    await Navigation.PushAsync(new ContactDetailsPage(selectedContact));
                }
            }
        }
    }

    // Model for Contact
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; } // Image file (Pic1.png, Pic2.png)
    }

    // Static class to return a list of sample contacts
    public static class ContactData
    {
        public static List<Contact> GetContacts()
        {
            return new List<Contact>
        {
            // Group A
            new Contact { Name = "Alice Johnson", Email = "alice@example.com", PhoneNumber = "123-456-7890", Description = "Lorem ipsum dolor sit amet.", Avatar = "picone.png" },
            new Contact { Name = "Adam Smith", Email = "adam@example.com", PhoneNumber = "987-654-3210", Description = "Lorem ipsum dolor sit amet.", Avatar = "pictwo.png" },
            new Contact { Name = "Ava Brown", Email = "ava@example.com", PhoneNumber = "555-555-5555", Description = "Lorem ipsum dolor sit amet.", Avatar = "picthree.png" },

            // Group B
            new Contact { Name = "Bob Smith", Email = "bob@example.com", PhoneNumber = "456-789-1230", Description = "Lorem ipsum dolor sit amet.", Avatar = "picfour.png" },
            new Contact { Name = "Bella White", Email = "bella@example.com", PhoneNumber = "222-333-4444", Description = "Lorem ipsum dolor sit amet.", Avatar = "picone.png" },
            new Contact { Name = "Ben Lee", Email = "ben@example.com", PhoneNumber = "777-888-9999", Description = "Lorem ipsum dolor sit amet.", Avatar = "pictwo.png" },

            // Group C
            new Contact { Name = "Charlie Brown", Email = "charlie@example.com", PhoneNumber = "333-444-5555", Description = "Lorem ipsum dolor sit amet.", Avatar = "picthree.png" },
            new Contact { Name = "Clara Davis", Email = "clara@example.com", PhoneNumber = "888-777-6666", Description = "Lorem ipsum dolor sit amet.", Avatar = "picfour.png" },
            new Contact { Name = "Cody Green", Email = "cody@example.com", PhoneNumber = "555-444-3333", Description = "Lorem ipsum dolor sit amet.", Avatar = "picone.png" },

            // Group D
            new Contact { Name = "David Lee", Email = "david@example.com", PhoneNumber = "111-222-3333", Description = "Lorem ipsum dolor sit amet.", Avatar = "pictwo.png" },
            new Contact { Name = "Diana King", Email = "diana@example.com", PhoneNumber = "666-777-8888", Description = "Lorem ipsum dolor sit amet.", Avatar = "picthree.png" },
            new Contact { Name = "Daniel White", Email = "daniel@example.com", PhoneNumber = "999-000-1111", Description = "Lorem ipsum dolor sit amet.", Avatar = "picfour.png" },

            // Group E
            new Contact { Name = "Eva White", Email = "eva@example.com", PhoneNumber = "444-555-6666", Description = "Lorem ipsum dolor sit amet.", Avatar = "picone.png" },
            new Contact { Name = "Ethan Clark", Email = "ethan@example.com", PhoneNumber = "222-333-4444", Description = "Lorem ipsum dolor sit amet.", Avatar = "pictwo.png" },
            new Contact { Name = "Ella Miller", Email = "ella@example.com", PhoneNumber = "555-666-7777", Description = "Lorem ipsum dolor sit amet.", Avatar = "picthree.png" }
        };
        }
    }

    // Grouping helper class for grouping contacts by the first letter of their name
    public class Grouping<TKey, TElement> : List<TElement>
    {
        public TKey Key { get; private set; }

        public Grouping(TKey key, IEnumerable<TElement> items) : base(items)
        {
            Key = key;
        }
    }
}
