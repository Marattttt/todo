using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

//User class should be used for managing overall user entities
public class User
{
    [Key()]
    public int Id { get; set; }
    public LoginInfo LoginInfo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        LoginInfo = new LoginInfo();
    }
}