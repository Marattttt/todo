using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

class User
{
    [Key]
    public int UserID { get; set; }
    protected LoginInfo LoginInfo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}