using CommunityToolkit.Maui;
using AutoGestor360App.Services;
using AutoGestor360App.ViewModels;
using AutoGestor360App.Views;
using Microsoft.Extensions.Logging;

namespace AutoGestor360App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();            
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("icofont.ttf", "icofont");
            });
        builder.Services.AddSingleton<IDateService, DateService>();
        builder.Services.AddSingleton<IRegisterService, RegisterService>();

        builder.Services.AddSingleton<PgHomeViewModel>();
        builder.Services.AddSingleton<PgAddRegisterViewModel>();
        builder.Services.AddSingleton<PgRegisterViewModel>();

        builder.Services.AddSingleton<PgHome>();
        builder.Services.AddSingleton<PgAddRegister>();
        builder.Services.AddSingleton<PgRegister>();
        builder.Services.AddSingleton<PgAddReview>();
        builder.Services.AddSingleton<PgReview>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
