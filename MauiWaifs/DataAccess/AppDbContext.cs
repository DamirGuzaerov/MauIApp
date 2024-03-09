using MauiWaifs.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiWaifs.DataAccess;

public class AppDbContext: DbContext
{
	public DbSet<User> Users => Set<User>();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var dbPath = Path.Combine(FileSystem.AppDataDirectory, "waifs.db");
		var connectionString = $"FileName={dbPath}";
		optionsBuilder.UseSqlite(connectionString);
	}
}