using AutoGestor360App.ViewModels;

namespace AutoGestor360App.Views;

public partial class PgRegister : ContentPage
{
	public PgRegister(PgRegisterViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		await (BindingContext as PgRegisterViewModel)!.GetRgistrations();
    }
}