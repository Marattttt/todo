using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

public class TodoContext : DbContext
{
    public TodoContext (DbContextOptions<TodoContext> options)
        : base(options)
    {
        Npgsql.NpgsqlConnection.GlobalTypeMapper.MapEnum<Role>();
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Admin> Admins { get; set; }

    public DbSet<Profile> Profiles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginInfo>(
            li =>
            {
                li.Property("_login")
                    .HasColumnName("login")
                    .HasMaxLength(20)
                    .IsUnicode(false);
                li.Property("_password")
                    .HasColumnName("lassword")
                    .HasMaxLength(20)
                    .IsUnicode(false);
                li.ToTable("login_info");
            });
        modelBuilder.Entity<User>()
            .ToTable("users")
            .HasDiscriminator<string>("user_type")
            .HasValue<Admin>("admin")
            .HasValue<Client>("client");       
        modelBuilder.Entity<TodoItem>().ToTable("todo_items");
        modelBuilder.Entity<Profile>().ToTable("profiles");
    }
}