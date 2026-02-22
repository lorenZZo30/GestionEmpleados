using GestionEmpleadosMaui.PageModels;
using GestionEmpleadosMaui.Pages;
using GestionEmpleadosMaui.Services;
using Microsoft.Extensions.Logging;

namespace GestionEmpleadosMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<DepartamentoService>();
            builder.Services.AddTransient<DepartamentosPageModel>();
            
            builder.Services.AddSingleton<SedeService>();
            builder.Services.AddTransient<SedesPageModel>();
            
            builder.Services.AddSingleton<EmpleadoService>();
            builder.Services.AddTransient<EmpleadosPageModel>();

            builder.Services.AddTransient<MainPageModel>();

            builder.Services.AddTransient<SettingsPageModel>();

            builder.Services.AddTransient<SedeDetailPage>();
            builder.Services.AddTransient<SedeDetailPageModel>();

            builder.Services.AddTransient<EmpleadoDetailPage>();
            builder.Services.AddTransient<EmpleadoDetailPageModel>();

            builder.Services.AddTransient<DepartamentoDetailPage>();
            builder.Services.AddTransient<DepartamentoDetailPageModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
