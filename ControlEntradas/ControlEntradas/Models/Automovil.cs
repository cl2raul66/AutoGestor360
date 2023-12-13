﻿
namespace ControlEntradas.Models;

public class Automovil(string Placa, string Marca, string Modelo, string AFabricacion, string[] Colores, string Combustible,Servicio[] Servicios)
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string AFabricacion { get; set; }
    public string[] Colores { get; set; }
    public string Combustible { get; set; }
    public Servicio[] Servicios { get; set; }
}