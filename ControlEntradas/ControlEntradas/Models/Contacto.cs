
namespace ControlEntradas.Models;

public class Contacto(string nombre, string telefono)
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }

    public override string ToString()
    {
        return Nombre;
    }
}
