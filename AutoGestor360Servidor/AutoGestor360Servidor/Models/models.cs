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
    public string? Note { get; set; }

    public Work(){ }
    public Work(string name, string description, string note)
    {
        Name = name;
        Description = description;
        Note = note;
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
}

public class Register
{
    [BsonId]
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
}

#region Revisiones

public class CarObject
{
    public string? Tag { get; set; }
    public string? Name { get; set; }
    public string[]? Damages { get; set; }
    public string? Observations { get; set; }
}

public class BaseReview
{
    public string? ServiceName { get; set; }
    public string? RegisterId { get; set; }
    public DateTime? ReviewDate { get; set; }
    public List<CarObject>? CarObjects { get; set; }
}

public class EntryReview : BaseReview
{
    public bool CustomerApproved { get; set; }
}

public class ExitReview : BaseReview
{
    public bool ReviewStatus { get; set; } = false;
}


#endregion