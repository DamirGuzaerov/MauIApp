using MauiWaifs.DataAccess;
using Microsoft.Extensions.Logging;

namespace MauiWaifs;

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
		builder.Services.AddDbContext<AppDbContext>();
		builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();

		using (var scope = 
		       app.Services.CreateScope())
		using (var context = scope.ServiceProvider.GetService<AppDbContext>())
			context.Database.EnsureCreated();
		
		return app;
	}
}