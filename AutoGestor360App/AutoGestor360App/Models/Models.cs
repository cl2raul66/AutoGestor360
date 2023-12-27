using AutoGestor360App.Tools;

namespace AutoGestor360App.Models;

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

    public override string ToString()
    {
        return Name!;
    }
}

public class Work
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Note { get; set; }

    public Work() { }
    public Work(string name, string description, string note = "")
    {
        Name = name;
        Description = description;
        Note = note;
    }

    public override string ToString()
    {
        return Name!;
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

    public Car() { }
    public Car(string plate, string brand, string model, int productionyear, string[] colors, TypeFuel fuel)
    {
        Plate = plate;
        Brand = brand;
        Model = model;
        ProductionYear = productionyear;
        Colors = colors;
        Fuel = fuel;
    }

    public override string ToString()
    {
        return string.IsNullOrEmpty(Model)
            ? $"{Brand} - {string.Join(", ", Colors!).TrimEnd([',', ' '])}"
            : $"{Brand} - {Model} - {string.Join(", ", Colors!).TrimEnd([',', ' '])}";
    }
}

public class Register
{
    public string? Id { get; set; }
    public Contact? Client { get; set; }
    public Car? Vehicle { get; set; }
    public Work[]? Tasks { get; set; }

    public Register() { }
    public Register(string id, Contact client, Car vehicle, Work[] tasks)
    {
        Id = id;
        Client = client;
        Vehicle = vehicle;
        Tasks = tasks;
    }

    public override string ToString()
    {
        return $"{Id} | {Client} | {Vehicle} | {string.Join(", ", Tasks!.Select(x => x.Name)!).TrimEnd([',', ' '])}";
    }
}
