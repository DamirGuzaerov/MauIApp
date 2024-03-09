using MauiWaifs.DataAccess;
using MauiWaifs.Models;

namespace MauiWaifs;

public partial class MainPage : ContentPage
{
	private readonly AppDbContext _dbContext;
	int count = 0;

	public MainPage(AppDbContext dbContext)
	{
		_dbContext = dbContext;
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		_dbContext.Users.Add(new User()
		{
			Id = Guid.NewGuid().ToString("N"),
			Name = $"User{count}"
		});

		_dbContext.SaveChanges();
		var lastUser = _dbContext.Users.FirstOrDefault();
		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times, last user Name {lastUser?.Name}";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}