using System.Collections.Generic;

namespace LibraryManagement
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Book> Books { get; } = new List<Book>();

        public Author(string firstname, string lastname, DateTime dataofbirth)
        {
            FirstName = firstname; LastName = lastname; DateOfBirth = dataofbirth;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
