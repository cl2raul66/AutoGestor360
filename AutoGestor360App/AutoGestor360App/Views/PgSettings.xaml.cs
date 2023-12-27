namespace AutoGestor360App.Views;

public partial class PgSettings : ContentPage
{
    public PgSettings()
    {
        InitializeComponent();
    }

    private async void BtnBack_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("..", true);

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var rute = (sender as Button)!.Text switch
        {
            "Administrar conexión" => nameof(PgConnection),
            "Administrar actividades" => nameof(PgTasks),
            _ => nameof(PgTasks)
        };
        await Shell.Current.GoToAsync(rute, true);
    }
}