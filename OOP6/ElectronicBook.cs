using System;

namespace LibraryManagement
{
    public class ElectronicBook : Book
    {
        public string FileFormat { get; set; }
        public long FileSize { get; set; }

        public ElectronicBook(string title, Author author, int publicationYear, string fileFormat, long fileSize)
            : base(title, author, publicationYear)
        {
            FileFormat = fileFormat;
            FileSize = fileSize;
        }

        public override string ToString()
        {
            return $"{base.ToString()} [Електронна книга, Формат: {FileFormat}, Розмір: {FileSize} байт]";
        }
    }
}