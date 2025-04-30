using System;

namespace LibraryManagement
{
    public abstract class Reader
    {
        public string Name { get; set; }
        public int ReaderID { get; private set; } 
        private static int nextID = 1;

        public Reader(string name)
        {
            Name = name; ReaderID = nextID++;
        }

        public abstract int GetMaxLoanBooks();

        public abstract int GetLoanDurationDays();

        public override string ToString()
        {
            return $"ID: {ReaderID}, Ім'я: {Name}, Тип: {GetType().Name}"; 
        }
    }
}