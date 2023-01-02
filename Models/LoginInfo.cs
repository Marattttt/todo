using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

public class LoginInfo
{
    [Key()]
    public int Id { get; set; }
    private string Login { get; set; } = "";
    private string Password { get; set; } = "";

    public bool VerifyLogin (string login, string password)
    {
        if (login == Login && password == Password)
            return true;
        else 
            return false;
    }
    
    public void UpdateLoginInfo (string newLogin, string newPassword)
    {
        Login = newLogin;
        Password = newPassword;
        Console.WriteLine("\n\nUpdateLoginInfo - success\n\n");
    }
}