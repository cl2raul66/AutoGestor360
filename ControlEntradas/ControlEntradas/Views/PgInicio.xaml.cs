using ControlEntradas.ViewModels;

namespace ControlEntradas.Views;

public partial class PgInicio : ContentPage
{
	public PgInicio(PgInicioViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}