using DietTracker.MockStore;
using DietTracker.Tracker;
using DietTracker.ViewModels;
using DietTracker.Views;
using Microsoft.Extensions.Logging;

namespace DietTracker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterViewModels() // ViewModels
			.RegisterViews() // Views
			.RegisterServices() // Services
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif


		return builder.Build();
	}

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
	{
		app.Services.AddTransient<TodayView>();
		app.Services.AddTransient<YesterdayView>();
		app.Services.AddTransient<SummaryView>();

		return app;
	}

	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder app)
	{
		app.Services.AddTransient<TodayViewModel>();
		app.Services.AddTransient<YesterdayViewModel>();
		app.Services.AddTransient<SummaryViewModel>();

		return app;
	}

	public static MauiAppBuilder RegisterServices(this MauiAppBuilder app)
	{
		app.Services.AddSingleton<IStore, Store>();
		app.Services.AddSingleton<Tracker.Tracker>();

		return app;
	}
}
