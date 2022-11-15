using Microsoft.EntityFrameworkCore;
using System.Reflection;

internal class Program
{
    private static async void Main(string[] args)
    {
        ForFromSqlDbContext context = new ForFromSqlDbContext();
        var result = await context.Persons.FromSql($"select * from Persons").ToListAsync();

        Console.WriteLine();
    }
}

class ForFromSqlDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = AHMET\\SQLEXPRESS; Database = EfExampleDb2; Trusted_Connection = True; ");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Person>()
            .HasMany(a => a.Orders)
            .WithOne(a => a.Person)
            .HasForeignKey(a => a.PersonId);
    }
}
public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }

    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    public int OrderId { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }

    public Person Person { get; set; }
}