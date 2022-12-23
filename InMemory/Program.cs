using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        // InMemory ile sanki gerçek veritabanında çalışıyormuş gibi işlem yapabiliriz. Böylelikle gereksiz veritabanı işgalinde bulunmadan memory'de çalışabiliriz. 
        // InMemory'de çalışırken dikkat edilmesi gereken husus ilişkisel veritabanları yapılamadığıdır. Geri kalan işlemlerin tümü gerçek veritabanında çalışır gibi işlem görür.
        // Bir diğer önemli not ise uygulamada durduğu an hafızadaki/memory'deki tüm veriler silinir.

        InMemoryDbContext context = new();
        Product product = new() { Id = 1, Name = "Elma", Description = "Açıklama" };
        context.Products.Add(product);
        context.SaveChanges();

        var result = context.Products.ToList();
    }
}

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
public class InMemoryDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //InMemory'de çalışmak için Microsoft.EntityFramework.InMemory kütüphanesinin indirilmesi ve aşağıdaki konfigürasyonun yapılması gerekmektedir.
        optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
    }
}