namespace SimpleContactBook.Models
{
    public class Contact
    {
        public string Name { get; set; }

        public string[] PhoneNumbers { get; set; }

        public string[] Emails { get; set; }

        public string[] Locations { get; set; }

        public bool IsFavorite { get; set; }

        public string ImagePath { get; set; }
    }
}
