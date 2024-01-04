using AutoGestor360App.ViewModels;

namespace AutoGestor360App.Views;

public partial class PgTasks : ContentPage
{
    bool visibleNuevo = false;
    Color primaryColor;
    Color secundaryColor;

    public PgTasks(PgTasksViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        Application.Current!.Resources.TryGetValue("Primary", out var primary);
        primaryColor = (Color)primary;
        Application.Current!.Resources.TryGetValue("Secondary", out var secondary);
        secundaryColor = (Color)secondary;

        FrameNuevo.IsVisible = visibleNuevo;
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        
        if (visibleNuevo)
        {
            b!.BackgroundColor = primaryColor;
            visibleNuevo = false;
        }
        else
        {
            b!.BackgroundColor = secundaryColor;
            visibleNuevo = true;
        }

        FrameNuevo.IsVisible = visibleNuevo;
    }
}