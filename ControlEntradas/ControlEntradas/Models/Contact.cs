
namespace ControlEntradas.Models;

public class Contact(string name, string telephone)
{
    public string Name { get; set; } = name;
    public string Telephone { get; set; } = telephone;

    public override string ToString()
    {
        return Name;
    }
}
