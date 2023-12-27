using AutoGestor360App.ViewModels;

namespace AutoGestor360App.Views;

public partial class PgHome : ContentPage
{
	public PgHome(PgHomeViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await (BindingContext as PgHomeViewModel)!.GetStatusapi();
    }
}