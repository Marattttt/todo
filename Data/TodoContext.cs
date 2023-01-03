using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

public class TodoContext : DbContext
{
    public TodoContext (DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<LoginInfo> LoginInfos { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginInfo>(
            li =>
            {
                li.Property("_login").HasColumnName("Login");
                li.Property("_password").HasColumnName("Password");
                li.ToTable("LoginInfo");
            });

        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Profile>().ToTable("Profiles");
        modelBuilder.Entity<TodoItem>().ToTable("TodoItems");
    }
}