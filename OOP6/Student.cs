namespace LibraryManagement
{
    public class Student : Reader
    {
        public string Faculty { get; set; }

        public Student(string name, string faculty) : base(name)
        {
            Faculty = faculty;
        }

        public override int GetMaxLoanBooks()
        {
            return 5; 
        }

        public override int GetLoanDurationDays()
        {
            return 30; 
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Факультет: {Faculty}";
        }
    }
}