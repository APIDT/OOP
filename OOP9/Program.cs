using System;

namespace OOP9
{
    class Program
    {
        static void Main(string[] args)
        {
            Department topManagement = new Department("Топ-менеджмент", "Генеральний директор");

            Department developmentDepartment = new Department("Відділ розробки", "Керівник відділу розробки");
            Department qaDepartment = new Department("Відділ тестування", "Керівник відділу тестування");
            Department hrDepartment = new Department("Відділ кадрів", "Керівник відділу кадрів");

            IndividualEmployee developer1 = new IndividualEmployee("Іван Петренко", "Розробник");
            IndividualEmployee developer2 = new IndividualEmployee("Марія Сидоренко", "Розробник");
            IndividualEmployee tester1 = new IndividualEmployee("Петро Іваненко", "Тестувальник");
            Manager manager1 = new Manager("Анна Ковальчук", "Провідний розробник");
            HR hrSpecialist1 = new HR("Олена Бондаренко", "HR-менеджер");

            developmentDepartment.Add(developer1);
            developmentDepartment.Add(developer2);
            developmentDepartment.Add(manager1);

            qaDepartment.Add(tester1);

            hrDepartment.Add(hrSpecialist1);

            topManagement.Add(developmentDepartment);
            topManagement.Add(qaDepartment);
            topManagement.Add(hrDepartment);

            Console.WriteLine(topManagement.GetInfo());

            Console.WriteLine($"\nЗагальна кількість співробітників в компанії: {topManagement.GetSubordinateCount()}");

            IEmployee foundEmployee = topManagement.FindByName("Марія Сидоренко");
            if (foundEmployee != null)
            {
                Console.WriteLine($"\nЗнайдено співробітника: {foundEmployee.GetInfo()}");
            }
            else
            {
                Console.WriteLine("\nСпівробітника не знайдено.");
            }

            developmentDepartment.Add(developer1);
        }
    }
}
