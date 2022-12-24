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
        modelBuilder.Entity<LoginInfo>().ToTable("Users");

        modelBuilder.Entity<User>(
            usr =>
            {
                usr.ToTable("Users");
                usr.HasOne(li => li.LoginInfo).WithOne()
                    .HasForeignKey<LoginInfo>(li => li.Id);
                usr.Navigation(li => li.LoginInfo).IsRequired();
            });

        modelBuilder.Entity<Profile>().ToTable("Profiles");
        modelBuilder.Entity<TodoItem>().ToTable("TodoItems");
    }
}