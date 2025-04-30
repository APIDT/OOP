using System;

namespace LibraryManagement
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }

        public LibraryItem(string title, DateTime publicationDate)
        {
            Title = title;
            PublicationDate = publicationDate;
        }

        public abstract override string ToString();
    }
}