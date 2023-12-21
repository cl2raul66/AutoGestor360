using ControlEntradas.ViewModels;

namespace ControlEntradas.Views;

public partial class PgHome : ContentPage
{
	public PgHome(PgHomeViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}