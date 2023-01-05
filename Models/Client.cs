using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

public class Client : User
{
    public List<TodoItem>? TodoItems { get; set; }
    void ChangeNames (string newFirstName, string newLastName)
    {
        FirstName = newFirstName;
        LastName = newLastName;
    }

    public Client(string firstName, string lastName, Role role) : base(firstName, lastName, role)
    {
    }

}