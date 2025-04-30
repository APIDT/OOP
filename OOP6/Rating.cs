namespace LibraryManagement
{
    public class Rating
    {
        public Reader User { get; private set; }
        public int Score { get; private set; }
        public string Review { get; private set; }

        public Rating(Reader user, int score, string review)
        {
            User = user;
            Score = score;
            Review = review;
            // Додайте валідацію для score (наприклад, від 1 до 5 або 1 до 10)
            if (score < 1 || score > 5) // Приклад валідації від 1 до 5
            {
                throw new ArgumentOutOfRangeException(nameof(score), "Оцінка повинна бути від 1 до 5.");
            }
        }

        public override string ToString()
        {
            return $"Користувач: {User.Name}, Оцінка: {Score}, Відгук: {Review}";
        }
    }
}