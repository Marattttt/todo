using Todo.Data;
using Todo.Models;
using Microsoft.EntityFrameworkCore;

namespace Todo.Services;

public class TodoService
{
    private readonly TodoContext _context;

    TodoService(TodoContext context)
    {
        _context = context;
    }

    public void CreateUser(string firstName, string lastName, LoginInfo loginInfo)
    {
        User newUser = new User(firstName, lastName);
        newUser.LoginInfo = loginInfo;
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }
}
