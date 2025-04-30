public class Manager : IndividualEmployee
{
    public Manager(string name, string position) : base(name, position) { }

    public override string GetInfo()
    {
        return $"Менеджер: {Name}, Посада: {Position} (Менеджер)";
    }
}