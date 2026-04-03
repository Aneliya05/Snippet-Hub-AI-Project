using Microsoft.Extensions.Logging;
using Mobile.Services;
using Mobile.ViewModels;
using Mobile.Views;

namespace Mobile
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ApiClient>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<SnippetService>();
            builder.Services.AddSingleton<TokenStorage>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<HomePage>();

            return builder.Build();
        }
    }
}
