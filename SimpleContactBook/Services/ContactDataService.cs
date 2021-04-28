using SimpleContactBook.Models;
using System.Collections.Generic;

namespace SimpleContactBook.Services
{
    public class ContactDataService : IContactDataService
    {
        private IEnumerable<Contact> _contacts;

        public ContactDataService()
        {
            InitialData();
        }

        private void InitialData()
        {
            _contacts = new List<Contact>() 
            {
                new Contact {
                        Name = "John Doe",
                        PhoneNumbers = new string[] { "555-111-1111", "555-222-2222" },
                        Emails = new string[] { "Johndoe@personal.com", "Johndoe@business.com" },
                        Locations = new string[] { "111 Fake Street", "222 Fake Ave" }
                    },
                new Contact {
                        Name = "Jane Doe",
                        PhoneNumbers = new string[] { "555-333-3333", "555-444-4444" },
                        Emails = new string[] { "Janedoe@personal.com", "Janedoe@business.com" },
                        Locations = new string[] { "111 Fake Street", "333 Fake Ave" }
                    },
            };
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            this._contacts = contacts;
        }
    }
}
