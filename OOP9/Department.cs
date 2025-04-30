using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Department : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }
    private List<IEmployee> subordinates = new List<IEmployee>();

    public Department(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void Add(IEmployee employee)
    {
        if (!subordinates.Contains(employee))
        {
            subordinates.Add(employee);
        }
        else
        {
            if (employee is IndividualEmployee individualEmployee)
            {
                Console.WriteLine($"Співробітник {individualEmployee.Name} вже є у відділі {Name}");
            }
            else if (employee is Department department)
            {
                Console.WriteLine($"Відділ {department.Name} вже є у відділі {Name}");
            }
            else
            {
                Console.WriteLine($"Об'єкт вже є у відділі {Name}");
            }
        }
    }

    public void Remove(IEmployee employee)
    {
        subordinates.Remove(employee);
    }

    public string GetInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Відділ: {Name}, Керівник: {Position}");

        if (subordinates.Count > 0)
        {
            sb.AppendLine("Підлеглі:");
            foreach (var subordinate in subordinates)
            {
                sb.AppendLine("  " + subordinate.GetInfo());
            }
        }

        return sb.ToString();
    }

    public int GetSubordinateCount()
    {
        int count = subordinates.Count;
        foreach (var subordinate in subordinates)
        {
            count += subordinate.GetSubordinateCount();
        }
        return count;
    }

    public IEmployee FindByName(string name)
    {
        if (Name == null)
        {
            return null; // Або викинути виняток
        }
        if (Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            return this;
        }

        foreach (var subordinate in subordinates)
        {
            IEmployee found = subordinate.FindByName(name);
            if (found != null)
            {
                return found;
            }
        }
        return null;
    }
}