using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

public class LoginInfo
{
    [Required()]
    private string _login { get; set; }
    [Required()]
    private string _password { get; set; }

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