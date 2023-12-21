using CommunityToolkit.Mvvm.ComponentModel;
using ControlEntradas.Models;
using ControlEntradas.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEntradas.ViewModels;

public partial class PgHomeViewModel : ObservableRecipient
{
    [ObservableProperty]
    string fullname;

    [ObservableProperty]
    string telephone;

    [ObservableProperty]
    string placa; 

    [ObservableProperty] 
    string marca; 

    [ObservableProperty] 
    string modelo; 

    [ObservableProperty] 
    int afabricacion; 

    [ObservableProperty] 
    string[] colores;

    public IEnumerable<TypeFuel> Combustibles => Enum.GetValues(typeof(TypeFuel)).Cast<TypeFuel>();

    [ObservableProperty]
    TypeFuel selectedCombustible;

    public IEnumerable<Work> Servicios;

    [ObservableProperty]
    Work[] selectedServicios;
}
