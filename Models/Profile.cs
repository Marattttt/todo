using System.ComponentModel.DataAnnotations;

namespace Todo.Models;
public class Profile
{
    [Key]
    public int ProfileId { get; set; }
    public String? Desctription { get; set; }
}