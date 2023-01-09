using System;
using System.Reflection;
namespace Todo.Models;

public class Client : User
{
    public List<TodoItem>? TodoItems { get; set; }
    public Profile? Profile { get; set; }

    void ChangeNames (string newFirstName, string newLastName)
    {
        FirstName = newFirstName;
        LastName = newLastName;
    }

    public Client() : base() {}

    //Constructor using reflection
    public Client (User u)
    {
        foreach (PropertyInfo prop in u.GetType().GetProperties())
            GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(u));
    }

}