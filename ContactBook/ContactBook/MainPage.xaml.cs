using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ContactBook
{
	public partial class MainPage : ContentPage
	{
        private ObservableCollection<Models.Contacts> contacts;

        public MainPage()
		{
			InitializeComponent();

            contacts = new ObservableCollection<Models.Contacts>
            {
                new Models.Contacts{Id = 1,firstName = "John",lastName = "Smith",email="john@gmail.com",phone = "111111"}
            };

            listContacts.ItemsSource = contacts;

        }

        async  void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var page = new SignUpForm(new Models.Contacts());

            page.ContactAdded += (source, contact) =>
            {
                contacts.Add(contact);
            };

           await Navigation.PushAsync(page);
        }

        async void OnDeleteContact(object sender, EventArgs e)
        {
            var deleteContact = (sender as MenuItem).CommandParameter as Models.Contacts;

            if (await DisplayAlert("Warning",$"Are you sure you want to delete {deleteContact.FullName}?", "Yes", "No"))
            {
                contacts.Remove(deleteContact);
            }
        }

        async void OnContactsSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listContacts.SelectedItem == null)
            {
                return;
            }

            var selectedContact = e.SelectedItem as Models.Contacts;
            listContacts.SelectedItem = null;

            var page = new SignUpForm(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.firstName = contact.firstName;
                selectedContact.lastName = contact.lastName;
                selectedContact.phone = contact.phone;
                selectedContact.email = contact.email;
                selectedContact.isBlocked = contact.isBlocked;
            };

            await Navigation.PushAsync(page);
        }
    }
}
