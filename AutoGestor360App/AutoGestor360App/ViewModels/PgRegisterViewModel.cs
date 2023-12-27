using AutoGestor360App.Models;
using AutoGestor360App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestor360App.ViewModels;

public partial class PgRegisterViewModel : ObservableRecipient
{
    readonly IRegisterService registerServ;

    public PgRegisterViewModel(IRegisterService registerService)
    {
        registerServ = registerService;
    }

    [ObservableProperty]
    ObservableCollection<Register>? registrations;

    [RelayCommand]
    async Task GoBack() => await Shell.Current.GoToAsync("..", true);

    [RelayCommand]
    public async Task GetRgistrations()
    {
        if (await registerServ.RegisterExistsAsync())
        {
            Registrations = new (await registerServ.GetRegisters());
        }
    }
}
