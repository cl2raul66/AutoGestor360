using AutoGestor360App.ViewModels;

namespace AutoGestor360App.Views;

public partial class PgConnection : ContentPage
{
	public PgConnection(PgConnectionViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}