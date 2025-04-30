using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    public class Library
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string YearOfFoundation { get; set; }

        private List<Department> Departments { get; } = new List<Department>();

        public Library(string title, string address, string yearOfFoundation)
        {
            Title = title;
            Address = address;
            YearOfFoundation = yearOfFoundation;
        }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void RemoveDepartment(Department department)
        {
            Departments.Remove(department);
        }

        public Department? FindDepartment(string departmentName)
        {
            return Departments.FirstOrDefault(d => d.Name == departmentName);
        }

        public void AddItemToDepartment(string departmentName, LibraryItem item)
        {
            var department = FindDepartment(departmentName);
            if (department != null)
            {
                department.AddItem(item);
            }
            else
            {
                Console.WriteLine($"Відділ '{departmentName}' не знайдено.");
            }
        }

        public void RemoveItemFromDepartment(string departmentName, LibraryItem item)
        {
            var department = FindDepartment(departmentName);
            if (department != null)
            {
                department.RemoveItem(item);
            }
            else
            {
                Console.WriteLine($"Відділ '{departmentName}' не знайдено.");
            }
        }

        public void IssueItem(LibraryItem item, Reader reader)
        {
            if (/* Перевірка, чи елемент доступний */ true)
            {
                if (/* Перевірка, чи читач не перевищив ліміт */ GetCurrentLoanedItemsCount(reader) < reader.GetMaxLoanBooks())
                {
                    Console.WriteLine($"'{item.Title}' ({(item is Book ? "Книга" : item.GetType().Name)}) видано читачеві {reader.Name} ({reader.GetType().Name}) на {reader.GetLoanDurationDays()} днів.");
                    // Тут має бути логіка для обліку виданих елементів
                }
                else
                {
                    Console.WriteLine($"Читач {reader.Name} ({reader.GetType().Name}) досяг максимальної кількості елементів для абонементу ({reader.GetMaxLoanBooks()}).");
                }
            }
            else
            {
                Console.WriteLine($"'{item.Title}' недоступний.");
            }
        }

        // Тимчасова заглушка для отримання кількості виданих елементів читачеві
        private int GetCurrentLoanedItemsCount(Reader reader)
        {
            // У реальній системі тут буде логіка для підрахунку виданих читачеві елементів
            return 0;
        }

        public IEnumerable<LibraryItem> GetAllItems()
        {
            return Departments.SelectMany(d => d.GetItems());
        }

        public override string ToString()
        {
            return $"Бібліотека '{Title}'\nАдреса: {Address}\nРік заснування: {YearOfFoundation}";
        }
    }
}