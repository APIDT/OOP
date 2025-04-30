using System.Collections.Generic;

public interface IEmployee
{
    void Add(IEmployee employee);
    void Remove(IEmployee employee);
    string GetInfo();
    int GetSubordinateCount();
    IEmployee FindByName(string name);
}