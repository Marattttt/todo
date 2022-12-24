using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

public class TodoItem
{
    [Key()]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Due { get; set; }
}