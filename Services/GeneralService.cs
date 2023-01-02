using Todo.Data;
using Todo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Todo.Services;

public class GeneralService
{
    private readonly TodoContext _context;

    public GeneralService(TodoContext context)
    {
        _context = context;
    }

    public User? GetUserById(int id)
    {
        var user = from u in _context.Users
                    where u.Id == id
                    select u;

        if (user is null)
            return null;

        return user.First();
    }


    public async Task<int> CreateUser(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }
    public async Task<int> CreateUser(string firstName, string lastName, LoginInfo loginInfo)
    {
        User newUser = new User(firstName, lastName);
        newUser.LoginInfo = loginInfo;
        _context.Users.Add(newUser);
        return await _context.SaveChangesAsync();
    }
}
