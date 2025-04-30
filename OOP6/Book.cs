using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    public class Book : LibraryItem
    {
        public Author Author { get; set; }
        public int PublicationYear
        {
            get => PublicationDate.Year;
            set => PublicationDate = new DateTime(value, PublicationDate.Month, PublicationDate.Day);
        }
        private List<Rating> Ratings { get; } = new List<Rating>();

        public Book(string title, Author author, int publicationYear)
            : base(title, new DateTime(publicationYear, 1, 1))
        {
            Author = author;
            Author.Books.Add(this);
        }

        public void AddRating(Rating rating)
        {
            Ratings.Add(rating);
        }

        public double GetAverageRating()
        {
            if (Ratings.Count == 0)
            {
                return 0; // Або можна повернути null чи інше значення за замовчуванням
            }
            return Ratings.Average(r => r.Score);
        }

        public override string ToString()
        {
            string ratingInfo = Ratings.Count > 0 ? $" (Рейтинг: {GetAverageRating():F2})" : " (Немає рейтингів)";
            return $"{Title} - {Author} ({PublicationYear}){ratingInfo}";
        }
    }
}