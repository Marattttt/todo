using System;
using System.Text.Json;
using Todo.Data;
using Todo.Models;

namespace Todo.Services;

public class AdminService : IUserService
{
    TodoContext context;
    public AdminService(TodoContext context)
    {
        this.context = context;
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


