using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ContactBook.Models
{
	public class Contacts
	{
		public int Id { get; set;}
        public string firstName { get; set;}
        public string lastName { get; set;}
        public string phone { get; set;}
        public string email { get; set;}
        public bool isBlocked { get; set;}

        public string FullName
        {
            get { return $"{firstName} {lastName}";}
        }

        public string Email
        {
            get { return $"{email}";}
        }
	}
}