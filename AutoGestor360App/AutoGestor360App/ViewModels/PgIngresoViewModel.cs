using CommunityToolkit.Mvvm.ComponentModel;
using AutoGestor360App.Models;
using AutoGestor360App.Tools.Enums;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using AutoGestor360App.Services;

namespace AutoGestor360App.ViewModels;

public partial class PgIngresoViewModel : ObservableValidator
{
    readonly IRegisterService registerServ;

    public PgIngresoViewModel(IRegisterService registerService)
    {
        registerServ = registerService;
    }

    [ObservableProperty]
    [Required]
    string? fullname;

    [ObservableProperty]
    [Required]
    string? telephone;

    [ObservableProperty]
    string? placa;

    [ObservableProperty]
    [Required]
    string? marca;

    [ObservableProperty]
    string? modelo;

    [ObservableProperty]
    string? afabricacion;

    [ObservableProperty]
    [Required]
    string? colors;

    public IEnumerable<Tools.Enums.TypeFuel> Combustibles => Enum.GetValues(typeof(TypeFuel)).Cast<TypeFuel>();

    [ObservableProperty]
    [Required]
    TypeFuel selectedCombustible;

    //public IEnumerable<Work> Servicios;

    //[ObservableProperty]
    //Work[] selectedServicios;

    [ObservableProperty]
    bool wPintura;

    [ObservableProperty]
    bool wAireAcondicionado;

    [ObservableProperty]
    bool wMecanicaGeneral;

    [ObservableProperty]
    bool wEnderezado;

    [ObservableProperty]
    bool visibleInfo;

    [RelayCommand]
    async Task GoToBack() => await Shell.Current.GoToAsync("..", true);

    [RelayCommand]
    async Task AddInscription()
    {
        ValidateAllProperties();
        List<Work> selectedWorks = new();
        if (WEnderezado)
        {
            selectedWorks.Add(new("Enderezado", string.Empty));
        }
        if (WAireAcondicionado)
        {
            selectedWorks.Add(new("Aire acondicionado", string.Empty));
        }
        if (WPintura)
        {
            selectedWorks.Add(new("Pintura", string.Empty));
        }
        if (WMecanicaGeneral)
        {
            selectedWorks.Add(new("Mecánica general", string.Empty));
        }
        if (HasErrors || !selectedWorks.Any())
        {
            VisibleInfo = true;
            await Task.Delay(5000);
            VisibleInfo = false;
        }
        else
        {
            Models.Contact client = new(Fullname!, Telephone!);
            Car vehicle = new(Placa!, Marca ?? string.Empty, Modelo ?? string.Empty, int.Parse(Afabricacion ?? "0"), Colors!.Split(";"), SelectedCombustible, [.. selectedWorks]);
            Register newRegister = new($"", client, vehicle);

            await registerServ.RegisterAsync(newRegister);

            await GoToBack();
        }
    }
}
