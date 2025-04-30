public class HR : IndividualEmployee
{
    public HR(string name, string position) : base(name, position) { }
    public override string GetInfo()
    {
        return $"HR Спеціаліст: {Name}, Посада: {Position} (HR)";
    }
}