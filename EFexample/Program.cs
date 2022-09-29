using Microsoft.EntityFrameworkCore;
ExampleDbContext context = new();
#region one to one add

//Person person = new()
//{
//    Name = "Ahmet",
//    Adress = new() { PersonAdress = "Salköprü mahallesi" }
//};
// context.Persons.Add(person);
// context.SaveChanges();
#endregion
#region one to one delete

//Person? deletePerson= await context.Persons
//    .Include(p => p.Adress)
//    .FirstOrDefaultAsync(p => p.Id == 1);

//context.Adresses.Remove(deletePerson.Adress);
//context.SaveChanges();
#endregion
#region one to one Varolan üzerinde güncelleme yapma

//Adress adress = new()
//{
//    //PersonId=1,
//    PersonAdress = "Yeni adress"
//};

//context.Adresses.Add(adress);
//context.SaveChanges();


#endregion
#region one to many add
//Person person = new()
//{
//    Name = "Mehmet",
//    Adresses = new HashSet<Adress>()
//    {
//        new()
//        {
//            PersonAdress="Salköprü Boncuklu",
//        },
//        new()
//        {
//            PersonAdress="Salköprü desenli"
//        }
//    }
//};

//context.Persons.Add(person);
//context.SaveChanges();

#endregion
#region one to many delete

//var person2 = await context.Persons
//    .Include(p => p.Adresses)
//    .FirstOrDefaultAsync(p => p.Id == 3);

//Adress deleteAdress = person2.Adresses.FirstOrDefault(p => p.Id == 6);
//context.Adresses.Remove(deleteAdress);
//context.SaveChanges();
#endregion
#region one to many update

//Person? person = await context.Persons
//    .Include(p => p.Adresses)
//    .FirstOrDefaultAsync(p => p.Id == 2);

//Adress deletedAdress= person.Adresses.FirstOrDefault(p => p.Id == 5);
//context.Adresses.Remove(deletedAdress);

//person.Adresses.Add(new() { PersonAdress = "Yeni adres" });
//context.SaveChanges();

#endregion
#region many to many add

//Book book = new()
//{
//    BookName="Marmara",
//    Authors= new HashSet<Author>() { new() { AuthorName="Ahmet"}, new() { AuthorName="Veli"} }
//};
//context.Books.Add(book);
//context.SaveChanges();

#endregion
#region many to many delete

//Book? book=await context.Books
//    .Include(a => a.Authors)
//    .FirstOrDefaultAsync(b => b.Id == 1);

//Author deletAuth= book.Authors.FirstOrDefault(a => a.Id == 2);
//context.Authors.Remove(deletAuth);
//context.SaveChanges();
#endregion
#region Cascade Delete

//Person person = new()
//{
//    Name = "Ahmet",
//    Adresses = new HashSet<Adress>()
//    {
//        new() { PersonAdress = "Salköprü mah" },
//        new() { PersonAdress = "Hidayet mah" }
//    }
//};
//await context.Persons.AddAsync(person);
//context.SaveChanges();

//Cascade ile ilişkili tablolarda veri silinirken ilişkisi olan diğer tablodaki veriyi de otomatik siler. Fluent API ile bu işlemi yapabiliriz veya otomatik zaten aktif oluyor.
//Person deletedPerson=await context.Persons.FindAsync(1);
//context.Persons.Remove(deletedPerson);
//await context.SaveChangesAsync();


#endregion
#region BackingFields
//propertilere kapsülleme yapmaya yarar. Örneğin FirstName'i dışarıya fullname field'i ile açabiliyoruz.
//Person? person=await context.Persons.FindAsync(1);
//Console.WriteLine();
#endregion
#region AddBookOfRowVersion
//Book book = new()
//{
//    BookName="kitap adı",
//    Authors=new HashSet<Author>() { new() { AuthorName="Yazar Adı"} }
//};
//context.Books.Add(book);
//context.SaveChanges();
#endregion


class Person
{
    public int Id { get; set; }
    public string FullName;
    public string FirstName { get => FullName; set => FullName = value; }
    public string LastName { get; set; }

    public ICollection<Adress> Adresses { get; set; }
}
class Adress
{
    public int Id { get; set; }

    public string PersonAdress { get; set; }
    public int PersonId { get; set; }

    public Person? Person { get; set; }
}
class Book
{
    public int Id { get; set; }
    public Byte[] rowVersion { get; set; }
    public string BookName { get; set; }

    public ICollection<Author> Authors { get; set; }
}
class Author
{
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<Book> Books { get; set; }
}
class ExampleDbContext : DbContext
{
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=EfExampleDb;Trusted_Connection=True;");
    }
    #region OnModelCreating
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    //modelBuilder.Entity<Person>().ToTable("Kişiler"); // Person tablosuna karşılık veritabanında kişiler adında tablo adını vermemizi sağlıyor. Burada istediğimiz tablo adını verebiliriz.

    //    //modelBuilder.Entity<Person>().ToTable("Kişiler", "TabloAdı"); --> Çıktısı: TabloAdı.Kişiler diye veritabanında tablo oluşturacaktır.

    //    //modelBuilder.Entity<Adress>().Property(p => p.PersonAdress).HasColumnName("KisiAdresi"); Burada Adress Nesnesi üzerinden PersonAdress propertisinin veritabanında ki kolon karşılığına dilediğimiz ismi veriyoruz. Bu örnekte KisiAdresi olarak belirlemişiz.
    //}
    #endregion
    #region Fluent API yapılanaması:
    //
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Adress>()
    //        .HasOne(p => p.Person)
    //        .WithOne(a => a.Adress)
    //        .HasForeignKey<Adress>(a => a.Id)
    //        .OnDelete(DeleteBehavior.Cascade);//cascade ile silindiğinde ilişkili tablodaki veriyi de siler. SetNull yapılırsa ilişkili tablodaki veri silinirse diğer ilişkili tabloya karşılık gelen değerleri null yapar. 


    //}
    #endregion
    #region Fluent Api Yapılanması 2
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Person>(p =>
    //    {
    //        p.ToTable("Persons").HasKey(p => p.Id); -->HasNoKey özelliği de key'in olmaması için kullanılır.s
    //        p.Property(p => p.FirstName).HasColumnName("FirstName");
    //        p.HasOne(p => p.Adresses);
    //    });
    //}
    #endregion
    #region RowVersion FluentApi yapılanması ile
    //IsRowVersion ile kolon versiyonunu belirtiyoruz.
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Book>()
    //        .Property(x => x.rowVersion)
    //        .IsRowVersion();
    //}
    #endregion

}