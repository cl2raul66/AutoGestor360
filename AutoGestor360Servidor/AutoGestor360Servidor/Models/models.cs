using AutoGestor360Servidor.Tools.Enums;
using LiteDB;

namespace AutoGestor360Servidor.Models;

public class Contact
{
    public string? Name { get; set; }
    public string? Telephone { get; set; }

    public Contact() { }
    public Contact(string name, string telephone)
    {
        Name = name;
        Telephone = telephone;
    }
}

public class Work
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public Work(){ }
    public Work(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

public class Car
{
    public string? Plate { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int ProductionYear { get; set; }
    public string[]? Colors { get; set; }
    public TypeFuel? Fuel { get; set; }
    public Work[]? Tasks { get; set; }

    public Car() { }
    public Car(string plate, string brand, string model, int productionyear, string[] colors, TypeFuel fuel, Work[] tasks)
    {
        Plate = plate;
        Brand = brand;
        Model = model;
        ProductionYear = productionyear;
        Colors = colors;
        Fuel = fuel;
        Tasks = tasks;
    }
}

public class Register
{
    [BsonId]
    public string? Id { get; set; }
    public Contact? Client { get; set; }
    public Car? Vehicle { get; set; }
    public string[]? Notes { get; set; }

    public Register() { }
    public Register(string id, Contact client, Car vehicle, string[] notes)
    {
        Id = id;
        Client = client;
        Vehicle = vehicle;
        Notes = notes;
    }
}
