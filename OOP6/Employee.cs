namespace LibraryManagement
{
    public class Employee : Reader
    {
        public string Department { get; set; }

        public Employee(string name, string department) : base(name)
        {
            Department = department;
        }

        public override int GetMaxLoanBooks()
        {
            return 10; 
        }

        public override int GetLoanDurationDays()
        {
            return 60; 
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Відділ: {Department}";
        }
    }
}