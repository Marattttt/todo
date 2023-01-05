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
    public Role Role{ get; set; }
    public Profile? Profile { get; set; }

    public User(string firstName, string lastName, Role role)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        LoginInfo = new LoginInfo();
    }
}