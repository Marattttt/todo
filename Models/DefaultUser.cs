using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

class DefaultUser : User
{
    public List<TodoItem>? TodoItems { get; set; }
    public String? ProfileDescription { get; set; }

    void ChangeNames (string newFirstName, string newLastName)
    {
        FirstName = newFirstName;
        LastName = newLastName;
    }
}