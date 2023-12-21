namespace AutoGestor360Servidor.Models;

public class Register(string id, Contact client, Car vehicle)
{
    public string Id { get; set; } = id;
    public Contact? Client { get; set; } = client;
    public Car? Vehicle { get; set; } = vehicle;
    //public string[] Notes { get; set; } = [];
}