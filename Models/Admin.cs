namespace Todo.Models;

public class Admin : User
{
    public List<Client> WatchList { get; set; }
    public Admin(string firstName, string lastName, Role role) : base(firstName, lastName, role)
    {
        WatchList = new List<Client>();
    }
}