using System;

public class IndividualEmployee : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public IndividualEmployee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void Add(IEmployee employee)
    {
        Console.WriteLine("Не можна додавати підлеглих до окремого співробітника.");
    }

    public void Remove(IEmployee employee)
    {
        Console.WriteLine("Не можна видаляти підлеглих у окремого співробітника.");
    }

    public virtual string GetInfo()
    {
        return $"Співробітник: {Name}, Посада: {Position}";
    }

    public int GetSubordinateCount()
    {
        return 0;
    }

    public IEmployee FindByName(string name)
    {
        if (Name == null)
        {
            return null; // Або викинути виняток, залежно від вимог
        }
        if (Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            return this;
        }
        return null;
    }
}