using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AutoGestor360App.Views;
using AutoGestor360App.Services;

namespace AutoGestor360App.ViewModels;

public partial class PgHomeViewModel : ObservableRecipient
{
    readonly IApiClientService apiClientServ;

    public PgHomeViewModel(IApiClientService apiClientService)
    {
        apiClientServ = apiClientService;
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
    async Task GoToAjustes() => await Shell.Current.GoToAsync(nameof(PgSettings), true);

    [ObservableProperty]
    bool statusApi;

    #region Extra
    [RelayCommand]
    public async Task GetStatusapi()
    {
        StatusApi = await apiClientServ.Test();
    }
    #endregion
}
