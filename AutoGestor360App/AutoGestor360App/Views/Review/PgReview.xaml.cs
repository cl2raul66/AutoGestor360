using AutoGestor360App.ViewModels;

namespace AutoGestor360App.Views;

public partial class PgReview : ContentPage
{
	public PgReview(PgReviewViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}