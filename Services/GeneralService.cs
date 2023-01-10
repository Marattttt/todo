using System.Text.RegularExpressions;
using Todo.Data;
using Todo.Models;
using System.Text.Json;

namespace Todo.Services;

//This service should be used for general actions regarding User class  
public class GeneralService
{
    private readonly TodoContext _context;

    public GeneralService(TodoContext context)
    {
        _context = context;
    }

    public async Task<Admin?> GetAdminAsync(int id)
        => await _context.Admins.FindAsync(id);
    

    public async Task<Client?> GetClientAsync(int id)
        => await _context.Clients.FindAsync(id);

    public User? GetUser(int id)
    {
        User? user;
        user = GetAdminAsync(id).Result;
        if (user is not null)
            return user;
        user = GetClientAsync(id).Result;
        return user;
    }

    //Method does not need to chek whether such an id exists, and
    //if the user is not an admin, it will delete the user
    public async Task<int> DeleteUser(int id)
    {
        User? user = GetUser(id);
        if (user is Admin || user is null)
            return 0; 

        _context.Clients.Remove((Client)user);
        return await _context.SaveChangesAsync();
    }
    //Creates a user
    public async Task<int> CreateUser(User user, Role role)
    {
        if (role == Role.admin)
        {
            Admin admin = new Admin(user);
            _context.Admins.Add(admin);
        }
        else if (role == Role.client)
        {
            Client? client = new Client(user);
            _context.Clients.Add(client);
        }
             
        return await _context.SaveChangesAsync();
    }
}