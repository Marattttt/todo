using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

//It is adviced to only use public methods
//If additional functionality must be added, it should be kept inside public methods
public class LoginInfo
{
    [Key()]
    public int Id { get; set; }
    private string _login { get; set; } 
    private string _password { get; set; }

    public LoginInfo()
    {
    }

    public bool VerifyLogin (string login, string password)
    {
        if (login == _login && password == _password)
            return true;
        else 
            return false;
    }
    
    public void UpdateLoginInfo (string newLogin, string newPassword)
    {
        _login = newLogin;
        _password = newPassword;
    }
}