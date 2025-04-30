using System;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("Анджеліна", "Сміт", new DateTime(1970, 5, 15));
            Author author2 = new Author("Бред", "Сміт", new DateTime(1985, 10, 20));

            Book book1 = new Book("Пригоди", author1, 2000);
            ElectronicBook ebook1 = new ElectronicBook("Кіберпанк 2077", author2, 2020, "PDF", 2500000);

            DVD dvd1 = new DVD("Інтерстеллар", new DateTime(2014, 11, 5), "Blu-ray", new TimeSpan(2, 49, 0));

            AudioBook audiobook1 = new AudioBook("Володар Перснів", new DateTime(1954, 7, 29), new TimeSpan(36, 12, 0), "Роберт Інгліс");

            Magazine magazine1 = new Magazine("Мрія про себе", new DateTime(2024, 10, 1), 135);

            Newspaper newspaper1 = new Newspaper("Як вони вижили?", DateTime.Today, 25412);

            Library library = new Library("Центральна бібліотека", "вул. Українська, 1", "1950");

            Department fictionDepartment = new Department("Фантастика");
            Department nonFictionDepartment = new Department("Наукова література");
            Department periodicalsDepartment = new Department("Періодичні видання");
            Department multimediaDepartment = new Department("Мультимедіа");

            library.AddDepartment(fictionDepartment);
            library.AddDepartment(nonFictionDepartment);
            library.AddDepartment(periodicalsDepartment);
            library.AddDepartment(multimediaDepartment);

            library.AddItemToDepartment("Фантастика", book1);
            library.AddItemToDepartment("Фантастика", ebook1);
            library.AddItemToDepartment("Наукова література", new Book("Коротка історія часу", author1, 1988));
            library.AddItemToDepartment("Мультимедіа", dvd1);
            library.AddItemToDepartment("Мультимедіа", audiobook1);
            library.AddItemToDepartment("Періодичні видання", magazine1);
            library.AddItemToDepartment("Періодичні видання", newspaper1);

            Student student1 = new Student("Іван Петренко", "Інформатика");
            Guest guest1 = new Guest("Олег Іванов", "За номером посвідчення 12345");
            Employee employee1 = new Employee("Марія Сидоренко", "Бібліотечний відділ");

            Rating rating1 = new Rating(student1, 5, "Чудова книга!");
            Rating rating2 = new Rating(guest1, 4, "Цікаво, але трохи затягнуто.");
            Rating rating3 = new Rating(employee1, 5, "Рекомендую всім!");

            book1.AddRating(rating1);
            book1.AddRating(rating2);
            book1.AddRating(rating3);

            Console.WriteLine(book1);

            Console.WriteLine("\nВсі елементи в бібліотеці:");
            foreach (var item in library.GetAllItems())
            {
                Console.WriteLine(item);
            }
            library.IssueItem(book1, student1);
            library.IssueItem(dvd1, guest1);
            library.IssueItem(magazine1, student1);
        }
    }
}