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


