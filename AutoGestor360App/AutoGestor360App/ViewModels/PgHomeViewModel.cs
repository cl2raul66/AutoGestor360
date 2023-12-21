using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AutoGestor360App.Views;
using Windows.Media.Protection.PlayReady;

namespace AutoGestor360App.ViewModels;

public partial class PgHomeViewModel : ObservableRecipient
{
    public PgHomeViewModel()
    {
        _ = GetStatusapi();
    }

    [RelayCommand]
    async Task GoToIgreso() => await Shell.Current.GoToAsync(nameof(PgIngreso), true);

    [RelayCommand]
    async Task GoToAjustes() => await Shell.Current.GoToAsync(nameof(PgAjustes), true);

    [ObservableProperty]
    string? statusApi;

    #region Extra
    [RelayCommand]
    async Task GetStatusapi()
    {
        HttpClient clientApi = new();
        HttpResponseMessage response = await clientApi.GetAsync("http://localhost:5000/register/");

        StatusApi = response.IsSuccessStatusCode
            ? "Conectado"
            : "Desconectado";
    }
    #endregion
}
