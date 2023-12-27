using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AutoGestor360App.Views;

namespace AutoGestor360App.ViewModels;

public partial class PgHomeViewModel : ObservableRecipient
{
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
    bool statusApi;

    #region Extra
    [RelayCommand]
    public async Task GetStatusapi()
    {
        StatusApi = false;
        HttpClient clientApi = new();
        try
        {
            var response = await clientApi.GetAsync("http://localhost:5000/Register/");
            if (response is not null && response.IsSuccessStatusCode)
            {
                StatusApi = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al intentar conectarse al servidor: {ex.Message}");
        }
    }
    #endregion
}
