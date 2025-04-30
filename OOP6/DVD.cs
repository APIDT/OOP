using System;

namespace LibraryManagement
{
    public class DVD : LibraryItem
    {
        public string Format { get; set; }
        public TimeSpan Duration { get; set; }

        public DVD(string title, DateTime releaseDate, string format, TimeSpan duration)
            : base(title, releaseDate)
        {
            Format = format;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Title} (DVD, Формат: {Format}, Тривалість: {Duration})";
        }
    }
}