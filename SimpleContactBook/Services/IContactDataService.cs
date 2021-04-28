using SimpleContactBook.Models;
using System.Collections.Generic;

namespace SimpleContactBook.Services
{
    public interface IContactDataService
    {
        IEnumerable<Contact> GetContacts();
        void Save(IEnumerable<Contact> contacts);
    }
}
