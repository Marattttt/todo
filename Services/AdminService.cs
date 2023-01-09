using System;
using System.Text.Json;
using Todo.Data;
using Todo.Models;

namespace Todo.Services;

//This service handles actions that are used by admins
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
		catch(InvalidCastException)
		{
			return String.Empty;
		}

		if (admin.WatchList is null)
			return String.Empty;

        return JsonSerializer.Serialize(admin.WatchList);
	}

	public bool AddToWatchList(ref Admin admin, Client client)
	{
		if (admin.WatchList is null)
		{
			admin.WatchList = new List<Client> { client };
			return true;
		}

		if (admin.WatchList.Find(c => c.Id == client.Id) is null)
			return false;

		admin.WatchList.Add(client);
		return true;
	}
}


