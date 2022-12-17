using System.ComponentModel.DataAnnotations;

namespace Todo.Models;

class TodoItem
{
    [Key]
    public int TodoItemId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Due { get; set; }
}