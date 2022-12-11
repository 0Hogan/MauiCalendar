using mauiCalendar.ViewModel;

namespace mauiCalendar;

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

		builder.Services.AddSingleton<CalendarViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<CalendarListViewPage>();


		return builder.Build();
	}
}
