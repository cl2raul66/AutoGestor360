﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ControlEntradas.Services;
using ControlEntradas.ViewModels;
using ControlEntradas.Views;

namespace ControlEntradas;

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
        builder.Services.AddSingleton<IWorkService, WorkService>();

        builder.Services.AddSingleton<PgHomeViewModel>();

        builder.Services.AddSingleton<PgHome>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
