using System;

namespace LibraryManagement
{
    public class AudioBook : LibraryItem
    {
        public TimeSpan Duration { get; set; }
        public string Narrator { get; set; }

        public AudioBook(string title, DateTime releaseDate, TimeSpan duration, string narrator)
            : base(title, releaseDate)
        {
            Duration = duration;
            Narrator = narrator;
        }

        public override string ToString()
        {
            return $"{Title} (Аудіокнига, Тривалість: {Duration}, Озвучено: {Narrator})";
        }
    }
}