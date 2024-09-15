using EfCoreTesting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Oracle connection string
        optionsBuilder.UseOracle("User Id=demo;Password=demo;Data Source=127.0.0.1:1521/XEPDB1");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("EMPLOYEES").HasNoKey();
    }
    
}
public class SqlDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Project> Projects { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Author>().ToTable("Authors");
        modelBuilder.Entity<Project>().ToTable("Projects");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connect to LocalDB
        // optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PubDatabase;Trusted_Connection=True;");
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=RepositoryDb;Trusted_Connection=True;Encrypt=False;");
       

    }
}


