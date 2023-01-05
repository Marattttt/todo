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

    //method returns a user if one is found, or otherwise, throws a 
    //KeyNotFound exception
    //This method or its implementations should always be wrapped in a try/catch
    public User GetUserById(int id)
    {
        var user = from u in _context.Users
                    where u.Id == id
                    select u;

        if (!user.ToList().Any())
            throw new KeyNotFoundException();

        return user.First();
    }

    //Method does not need to chek whether such an id exists, and the user is not 
    //an admin, it will delete the user
    public async void DeleteUser(int id)
    {
        var user = from u in _context.Users
                    where u.Id == id
                    select u;
        if (user is Admin)
            return; 

        _context.Users.Remove((User)user);
        await _context.SaveChangesAsync();
    }

    //Method overload made for a better future implementation
    public async Task<int> CreateUser(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }
    public async Task<int> CreateUser(string firstName, string lastName, LoginInfo loginInfo, Role role)
    {
        User newUser = new User(firstName, lastName, role);
        newUser.LoginInfo = loginInfo;
        _context.Users.Add(newUser);
        return await _context.SaveChangesAsync();
    }

    public bool IsUserAdmin (User user)
    {
        if (user.Role is Role.admin)
            return true;
        return false;
    }
}
