using System;
using System.Text.Json;
using Todo.Models;

namespace Todo.Services;

public class ClientService : IUserService
{
	public ClientService()
	{
	}

    public string GetDispayData(User user)
    {
        Client client;
        try
        {
            client = (Client)user;
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine(e.Message);
            return String.Empty;
        }

        if (client.Profile is null)
            return String.Empty;

        return JsonSerializer.Serialize(client.Profile);
    }
}


