using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

//Profile class is to be developed for actual use
public class Profile
{
    [Key]
    public int ProfileId { get; set; }
    public String? Desctription { get; set; }
}