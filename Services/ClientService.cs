using System;
using System.Text.Json;
using Todo.Models;
using Todo.Data;

namespace Todo.Services;

//This service is used for services used by clients
public class ClientService : IUserService
{
    TodoContext context;
	public ClientService(TodoContext context)
	{
        this.context = context;
	}
    public string GetDispayData(User user)
    {
        Client client;
        try
        {
            client = (Client)user;
        }
        catch (InvalidCastException)
        {
            return "Invalid user";
        }

        if (client.Profile is null)
            return "Empty profile";

        return JsonSerializer.Serialize(client.Profile);
    }
}


