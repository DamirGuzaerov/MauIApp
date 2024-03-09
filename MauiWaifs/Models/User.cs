using System.ComponentModel.DataAnnotations;

namespace MauiWaifs.Models;

public class User
{
	[Key]
	public string Id { get; set; }
	
	public string Name { get; set; }
}