using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AutoGestor360App.Views;

namespace AutoGestor360App.ViewModels;

public partial class PgHomeViewModel : ObservableRecipient
{
    public PgHomeViewModel()
    {
        _ = GetStatusapi();
    }

    [RelayCommand]
    async Task GoToAddregister() => await Shell.Current.GoToAsync($"{nameof(PgRegister)}/{nameof(PgAddRegister)}", true);
    [RelayCommand]
    async Task GoToRegister() => await Shell.Current.GoToAsync(nameof(PgRegister), true);

    [RelayCommand]
    async Task GoToAddreview() => await Shell.Current.GoToAsync($"{nameof(PgReview)}/{nameof(PgAddReview)}", true);
    [RelayCommand]
    async Task GotoReview() => await Shell.Current.GoToAsync(nameof(PgReview), true);

    [RelayCommand]
    async Task GoToAjustes() => await Shell.Current.GoToAsync(nameof(PgAjustes), true);

    [ObservableProperty]
    string? statusApi;

    #region Extra
    [RelayCommand]
    async Task GetStatusapi()
    {
        StatusApi = "Desconectado";
        HttpClient clientApi = new();
        var response = await clientApi.GetAsync("http://localhost:5000/register/");
        if (response is not null && response.IsSuccessStatusCode)
        {
            StatusApi = "Conectado";
        }
    }
    #endregion
}
