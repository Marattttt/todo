using System;
using System.Text.Json;
using Todo.Models;

namespace Todo.Services;

public class AdminService : IUserService
{
	public AdminService()
	{
	}
	
    public string GetDispayData(User user)
	{
		Admin admin;
        try
		{
			admin = (Admin)user;
		}
		catch(InvalidCastException e)
		{
			Console.WriteLine(e.Message);
			return String.Empty;
		}

		if (admin.WatchList is null)
			return String.Empty;

        return JsonSerializer.Serialize(admin.WatchList);
	}
}


