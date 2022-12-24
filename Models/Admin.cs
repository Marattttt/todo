namespace Todo.Models;

public class Admin : User
{
    public List<User>? WatchList;

    public Admin(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}