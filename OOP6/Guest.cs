namespace LibraryManagement
{
    public class Guest : Reader
    {
        public string RegistrationInfo { get; set; }

        public Guest(string name, string registrationInfo) : base(name)
        {
            RegistrationInfo = registrationInfo;
        }

        public override int GetMaxLoanBooks()
        {
            return 2; 
        }

        public override int GetLoanDurationDays()
        {
            return 14; 
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Реєстраційна інформація: {RegistrationInfo}";
        }
    }
}