
namespace ControlEntradas.Models;

public class Servicio(string nombre, string descripcion)
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public override string ToString()
    {
        return Nombre;
    }
}
