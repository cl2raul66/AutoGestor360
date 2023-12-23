using AutoGestor360App.ViewModels;

namespace AutoGestor360App.Views;

public partial class PgAddRegister : ContentPage
{
	public PgAddRegister(PgAddRegisterViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}