using System;

namespace LibraryManagement
{
    public class Newspaper : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Newspaper(string title, DateTime publicationDate, int issueNumber)
            : base(title, publicationDate)
        {
            IssueNumber = issueNumber;
        }

        public override string ToString()
        {
            return $"{Title} (Газета, Випуск №{IssueNumber}, Дата: {PublicationDate.ToShortDateString()})";
        }
    }
}