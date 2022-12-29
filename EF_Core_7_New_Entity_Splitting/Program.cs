using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new SplittingApplicationDbContext();

        //Person person = new()
        //{
        //    Name= "Ahmet",
        //    Surname="Dalhançer",
        //    City="Malatya",
        //    Country="Türkiye",
        //    PhoneNumber="555123456789",
        //    PostCode="44100",
        //    Street="BilmemNeSokak"
        //};

        //context.Persons.Add(person);
        //context.SaveChanges();

        var person = context.Persons.FirstOrDefault();
        Console.WriteLine();
    }
}
class Person
{
    //.Net7 ile birlikte gelen Splitting özelliği entity'i parçalara ayırarak veritabanına parça kadar tablo oluşturmasını sağlar. Örneğin aşağıdaki entity tek olmasına rağmen fluent api tarafında split fonksiyonu sayesinde parçalayarak veritabanına gönderebiliyoruz.


    //Kişi bilgileri tablosu

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    //adres bilgileri tablosu
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostCode { get; set; }
    public string? Country { get; set; }

    //iletişim bilgileri tablosu
    public string? PhoneNumber { get; set; }
}

class SplittingApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=EfCore7NewSplittingDb;Encrypt=False;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Person>(entityBuilder =>
        {
            //SplitToTable ile Person entity'si içerisinde farklı bir tablo olarak oluşturması gerektiğini söylüyoruz.
            entityBuilder.ToTable("Persons")
            .SplitToTable("Adress", tableBuilder =>
            {
                tableBuilder.Property(a => a.Id).HasColumnName("PersonId");
                tableBuilder.Property(a => a.Street);
                tableBuilder.Property(a => a.PostCode);
                tableBuilder.Property(a => a.City);
                tableBuilder.Property(a => a.Country);
            })
            .SplitToTable("Contact", tableBuilder =>
            {
                tableBuilder.Property(p => p.Id).HasColumnName("PersonId");
                tableBuilder.Property(p => p.PhoneNumber);
            });
        });
    }

}