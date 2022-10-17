using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

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
#region Composite Key
//Bir tabloda birden fazla pramery key oluşturmak istiyorsak composite key kullanırız.

#endregion
#region HasConstrainName
// Constrain oluşturulurken manuel bunlara isim vermemizi sağlıyor. Örneği iki ilişkili tabloda HasForeignKey leri veritabanında constrain olarak manuel isim verebiliyoruz.
#endregion
#region TablePerHierarchy ile veri ekleme davranışları
//Employee employee = new() { Name = "Ahmet", Surname = "Dalhançer", Department = "Yazılım" };
//Personel personel = new() { Name = "Personel1", Surname = "PersonelSoyadi1", };
//await context.AddRangeAsync(employee,personel);
context.SaveChanges();
#endregion
#region TablePerHierarchy ile veri silme davranışları
//Personel silinecekPersonel=await context.Personels.FindAsync(3);
//context.Remove(silinecekPersonel);

//Discriminatör kolonunda belli sınıfta üretilenleri silmek istersek
//var silinecekVeriler = context.Employees.ToList();
//context.RemoveRange(silinecekVeriler);
//context.SaveChanges();
#endregion
#region TablePerHierarchy ile veri güncelleme davranışları
//var guncellenecekVeri = await context.Employees.FindAsync(4);
//guncellenecekVeri.Name = "Mehmet";

//Employee guncellenecekVeri2 = new() { Id = 4, Name = "AhmetComeBack" };
//context.Personels.Update(guncellenecekVeri2);
await context.SaveChangesAsync();
#endregion
#region TablePerHierarchy ile veri sorgulama davranışları
//var result = context.Employees.ToList();
//Console.WriteLine();
#endregion
#region Table Per Type
/** Bu davranışta kalıtım alan tablolarda tek tablo şeklinde değil de her sınıf için farklı tablolar oluşturulur.
 * Bu durumun oluşması için modelbuilder ile toTable yapılarak tablo adları verilmelir.
 **/
#endregion
#region Table Per Concrete
/**
 * Ef core 7 ile gelecek olan özelliktir. Bu davranışta abstract sınıf yani kalıtımı alınan sınıf için tablo oluşturulmaz.
 * Kalıtım alan sınıflar için ayrı ayır tablolar oluşturulur.
 * Oluşturulan tablolar arasında ilişki kurulmamaktadır.
  **/
#endregion

class Person
{
    public int Id { get; set; }
    public int Id2 { get; set; }
    public string FullName;
    public string FirstName { get => FullName; set => FullName = value; }
    public string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Active { get; set; }



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
    public int IdBook { get; set; }
    //public Byte[] rowVersion { get; set; }
    public string BookName { get; set; }

    public ICollection<Author> Authors { get; set; }
}
class Author
{
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<Book> Books { get; set; }
}
class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Salary { get; set; }
    public int ComputedValue { get; set; }
}
//TablePerHierarchy sınıfları başlangıcı.
class Personel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
class Employee : Personel
{
    public string? Department { get; set; }
}
class Customer : Personel
{
    public string? CompanyName { get; set; }
}
class Technician : Employee
{
    public string? Branch { get; set; }
}
//TablePerHierarchy sınıfları bitişi.
class ExampleDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Product> Products { get; set; }

    //TableForHierarchy dbsetlerin tanımlanması.
    public DbSet<Personel>? Personels { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Technician>? Technicians { get; set; }
    //TableForHierarchy dbsetlerin tanımlanması bitiş.

    #region ConConfiguringSqlServerConnection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=EfExampleDb;Trusted_Connection=True;");
    }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region OnModelCreating
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Person>().ToTable("Kişiler"); // Person tablosuna karşılık veritabanında kişiler adında tablo adını vermemizi sağlıyor. Burada istediğimiz tablo adını verebiliriz.

        //    //modelBuilder.Entity<Person>().ToTable("Kişiler", "TabloAdı"); --> Çıktısı: TabloAdı.Kişiler diye veritabanında tablo oluşturacaktır.

        //    //modelBuilder.Entity<Adress>().Property(p => p.PersonAdress).HasColumnName("KisiAdresi"); Burada Adress Nesnesi üzerinden PersonAdress propertisinin veritabanında ki kolon karşılığına dilediğimiz ismi veriyoruz. Bu örnekte KisiAdresi olarak belirlemişiz.
        //}
        #endregion
        #region Fluent API yapılanaması:

        //    modelBuilder.Entity<Adress>()
        //        .HasOne(p => p.Person)
        //        .WithOne(a => a.Adress)
        //        .HasForeignKey<Adress>(a => a.Id)
        //        .OnDelete(DeleteBehavior.Cascade);//cascade ile silindiğinde ilişkili tablodaki veriyi de siler. SetNull yapılırsa ilişkili tablodaki veri silinirse diğer ilişkili tabloya karşılık gelen değerleri null yapar. 

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
        //    modelBuilder.Entity<Book>()
        //        .Property(x => x.rowVersion)
        //        .IsRowVersion();
        #endregion
        #region MaxLenght
        //kolonun maximum uzunluğunu belirtmemizi sağlar.
        //    modelBuilder.Entity<Book>()
        //        .Property(b => b.Authors)
        //        .HasMaxLength(50);
        #endregion
        #region Composite Key
        // Bir tabloda birden fazla primary key oluşturmak istiyorsak kullanırız.
        //    modelBuilder.Entity<Person>()
        //        .HasKey("Id", "Id2"); //1.Kullanım
        //    modelBuilder.Entity<Book>()
        //        .HasKey(p => new { p.Id, p.IdBook }); //2. kullanım

        #endregion
        #region HasDefaultSchema
        //Veritabanı nesnesi default olarak dbo şemasına sahiptir. HasDefaultSchme ile bunu özelleştirebiliyoruz.
        //    modelBuilder.HasDefaultSchema("Admin");

        #endregion
        #region HasDefaultValue
        //propertilere default değer atamamızı sağlarız.Herhangi bir değer vermediğimizde otomatik tanımlanan değeri verir.
        //    modelBuilder.Entity<Person>()
        //        .Property(p => p.Adresses)
        //        .HasDefaultValue("Varsayılan Adres");
        #endregion
        #region HasDefaultValueSql
        // eğer propertiye bir değer atamazsak bunu sql cümleciği ile atayabiliyoruz. Yukarıdaki hasdefaultValue'nin sql cümlecikli hali olarak uyguluyoruz. Örn: 
        //    modelBuilder.Entity<Person>()
        //        .Property(p => p.CreatedDate)
        //        .HasDefaultValueSql("GETDATE()");  // --> bir sql cümleciği yazıyoruz.
        #endregion
        #region HasComputedColumnSql
        //ComputedValue -- > Hesaplanmış değer.
        //Bu işlemde ComputedValue propertisine price ile salary propertilerinin toplamını atıyoruz. Sadece matematiksel değil metinsel değeri de birleştirebiliriz.
        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.ComputedValue)
        //        .HasComputedColumnSql("[Price]+[Salary]");
        #endregion
        #region HasData
        // Oluşturulan veritabanında ve tablolarında oluşturma esnasında yazılım tarafında datalar oluşturmamızı sağlar. Yani yazılım tarafında hazır veriler oluşturmamızı sağlar.
        //    modelBuilder.Entity<Product>()
        //        .HasData(new Product { Name="Elma",Id=1,Price=100,Salary=50});
        //ÖNEMLİ!! Seed datalar oluşturulurken primary key kolonuna manuel değer girmemiz gerekiyor.
        #endregion
        #region HasDisciminator
        // Ayırıcı demektir. Table For Hierarchy ile kullanılır. Hangi etitiden gelen değeri tutar. Detayı Table For Hierarchy dersinde bulunmaktadır. Bknz:Table For Hierarchy
        #endregion
        #region HasNoKey
        //Normalde her entitide primary key vardır. Eğer primary key olmasını istemiyorsak HasNoKey kullanırız.
        //modelBuilder.Entity<Person>()
        //    .HasNoKey();
        #endregion
        #region HasQueryFilter
        //Default olarak filtreleme yapmamızı sağlar. Örn:
        //modelBuilder.Entity<Person>()
        //    .HasQueryFilter(p => p.Active == true);
        // Burada HasQueryFilter ile Person entitisindeki Active propersinin true olanlarının gelmesini sağlıyoruz.
        #endregion
        #region GeneratedValue

        #endregion
        #region IEntityTypeConfigurationOnModelCreating
        /* modelBuilder.ApplyConfiguration(new PersonConfiguration());*/ // Farklı sınıflarda yaptığımız configuration işlemlerini burada tanımlayarak aktif hale getiriyoruz.
        #endregion
        #region ApplyConfigurationsFromAssembly
        /*modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());*/ // Bunu yaptığımızda harici sınıflardaki tüm configuration'ları tek tek onModelCreating içerisinde tanımlamak yerine bunu yazdığımızda EF Core gidip tüm assembly'leri bulup ekliyor. Bir üstteki IEntityTypeConfigurationOnModelCreating başlığındaki işlemi her nesne için yapmamıza gerek kalmıyor.
        #endregion
        #region Seed Data
        // Migration sürecinde manuel olarak veri oluşturmamızı sağlar. Bunlar şu gibi durumlar için kullanılabilir:
        //1- Static rolleri migration sürecinde direkt oluşturmak. 2- Test amaçlı veriler eklemek.3- Örneğin  konnektör için varsayılan bir kullanıcı oluşturma Kullanımı: 

        //modelBuilder.Entity<Product>()
        //    .HasData(
        //    new Product() { Id=1,Name="Telefon",Price=1000,Salary=500},
        //    new() { Id = 2, Name = "Pc", Price = 5000, Salary = 100 }
        //    );

        // Önemli not!!--> Seed Datalarda primary key değerli manuel olarak tarafımızca verilmelidir.
        #endregion
        #region TableForHierarchy 
        // Hiyerarşili tabloları oluştururken farklı tablolar halinde değil de tek tablo altında oluşturmak istiyorsak bu yaklaşımı kullanabiliriz. Yukarıda person ile başlayan nesneler oluşturup alt nesnelere kalıtım vererek bu şekilde hiyerarşi oluşturmuş olduk. EntitFramework bu yapıyı algılayıp ona göre veritabanında tek tablo şeklinde oluşturacaktır.

        //1. Yapılması gereken kalıtım alacak sınıfları oluşturma. 2. olarak dbsetlerini ayrı ayrı belirlemek.Gerisini ef core yapacaktır.
        #endregion
        #region TableForHierarchy Discriminatör kolonunu özelleştirme
        #region Discriminatör adını özelleştirme
        // Base sınıfta bulunur. Bunun için modelbuilder yapılırken Personel tablosu seçilir. Örn:
        /*modelBuilder.Entity<Personel>().HasDiscriminator<string>("Ayirici");*/ // Bu şekilde discriminator'e istediğimiz isimlendirmeyi verebiliyoruz.
        #endregion
        #region Discriminatör Değerlerini değiştirme


        #endregion

        #endregion

    }
    #region IEntityTypeConfiguration<T>
    // Bu interface ile implemente edilen sınıfta OnModelCreating işlemlerini yapabiliyoruz. Bu bizim configuration işlemlerini farklı bir sınıfta yaparak düzenli ve profesyonel çalışmamızı sağlıyor.

    //Önemli Not!!! --> Farklı sınıf üzerinden yaptığımız configuration'ı kullanıma açmak/uygulamak için OnModelCreating fonksiyonuna özellikle belirtmemiz gerekmektedir. Nasıl belirttiğimizi kendi başlığı altında görebiliriz. Bakınız yukarıdaki IEntityTypeConfigurationOnModelCreating

    //class PersonConfiguration : IEntityTypeConfiguration<Person>
    //{
    //    public void Configure(EntityTypeBuilder<Person> builder)
    //    {
    //        builder.HasKey(p => p.Id);
    //        builder.Property(p => p.CreatedDate)
    //            .HasDefaultValue(DateTime.UtcNow);
    //        builder.Property(p => p.Active)
    //            .HasColumnName("Activeted");
    //        //... bu şekilde devam eder.
    //    }
    //}
    #endregion
}