using System;

namespace LibraryManagement
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, DateTime publicationDate, int issueNumber)
            : base(title, publicationDate)
        {
            IssueNumber = issueNumber;
        }

        public override string ToString()
        {
            return $"{Title} (Журнал, Випуск №{IssueNumber}, Дата: {PublicationDate.ToShortDateString()})";
        }
    }
}