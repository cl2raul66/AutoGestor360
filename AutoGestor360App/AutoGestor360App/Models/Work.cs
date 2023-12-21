namespace AutoGestor360App.Models;

public class Work(string name, string description)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;

    public override string ToString()
    {
        return Name;
    }
}
