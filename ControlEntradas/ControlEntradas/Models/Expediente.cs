
namespace ControlEntradas.Models;

public class Expediente(string id, Contacto cliente, Automovil vehiculo)
{
    public string Id { get; set; }
    public Contacto Cliente { get; set; }
    public Automovil Vehiculo { get; set; }

    public override string ToString()
    {
        return Id;
    }
}