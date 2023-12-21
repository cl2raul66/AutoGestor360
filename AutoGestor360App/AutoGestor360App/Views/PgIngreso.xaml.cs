using AutoGestor360App.ViewModels;

namespace AutoGestor360App.Views;

public partial class PgIngreso : ContentPage
{
	public PgIngreso(PgIngresoViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}