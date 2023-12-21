using AutoGestor360Servidor.Tools.Enums;

namespace AutoGestor360Servidor.Models;

public class Car(string plate, string brand, string model, int productionyear, string[] colors, TypeFuel fuel, Work[] tasks)
{
    public string Plate { get; set; } = plate;
    public string Brand { get; set; } = brand;
    public string Model { get; set; } = model;
    public int ProductionYear { get; set; } = productionyear;
    public string[] Colors { get; set; } = colors;
    public TypeFuel Fuel { get; set; } = fuel;
    public Work[] Tasks { get; set; } = tasks;
}
