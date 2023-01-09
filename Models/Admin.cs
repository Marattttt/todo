using System.Reflection;
namespace Todo.Models;

public class Admin : User
{
    public List<Client>? WatchList { get; set; }
    public Admin() : base() {}

    //Constructor using reflection 
    public Admin (User u)
    {
        foreach (PropertyInfo prop in u.GetType().GetProperties())
            GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(u));
    }
}