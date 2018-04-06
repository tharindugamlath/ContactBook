using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace ContactBook
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpForm : ContentPage
	{
        public event EventHandler<Models.Contacts> ContactAdded;
        public event EventHandler<Models.Contacts> ContactUpdated;

		public SignUpForm (Models.Contacts contact)
		{
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

			InitializeComponent ();

            BindingContext = new Models.Contacts
            {
                Id = contact.Id,
                firstName = contact.firstName,
                lastName = contact.lastName,
                phone = contact.phone,
                email = contact.email,
                isBlocked = contact.isBlocked
            };
		}

        async void Button_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Models.Contacts;

            if (String.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Error", "Please enter the name", "ok");
                return;
            }

            if (contact.Id == 0)
            {
                contact.Id = 1;

                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                ContactUpdated.Invoke(this,contact);
            }

            await Navigation.PopAsync();
        }
    }
}