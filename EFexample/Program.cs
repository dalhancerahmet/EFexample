using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
#region Include
//Üretilen sorguda diğer ilişkisel tabloları dahil etmek istiyorsak include fonksiyonunu kullanırız.
/*var result = await context.Persons.Include(p => p.Adresses).ToListAsync(); */// Burada Persons tablosunun ilişkili olduğu Adresses tablosunu dahil etmiş olduk.
/*
SELECT[p].[Id], [p].[Active], [p].[CreatedDate], [p].[FirstName], [p].[Id2], [p].[LastName], [a].[Id], [a].[PersonAdress], [a].[PersonId]
FROM[Persons] AS[p]
LEFT JOIN[Adresses] AS [a] ON[p].[Id] = [a].[PersonId]
ORDER BY[p].[Id] 
Sql profile ile gönderdiğimiz sorgunun çıktısını görüyoruz.
 */

Console.WriteLine();
#endregion
#region Join

#region QuerySyntax
//var query = from person in context.Persons
//            join adress in context.Adresses
//            on person.Id equals adress.Id
//            select new
//            {
//                person.Id,
//                person.FullName,
//                adress.PersonAdress
//            };
//var datas=await query.ToListAsync();


/* Sql profile çıktısı: 
  SELECT [p].[Id], [p].[Active], [p].[CreatedDate], [p].[FirstName], [p].[Id2], [p].[LastName], [a].[PersonAdress]
FROM [Persons] AS [p]
INNER JOIN [Adresses] AS [a] ON [p].[Id] = [a].[Id]
*/
Console.WriteLine();
#endregion

#region MethodSyntax
//var query = context.Products.Join(context.Persons, product => product.Id, person => person.Id, (product, person) => new
//{
//    product.Name,
//    person.FirstName
//});
//var datas= await query.ToListAsync();


#endregion
#endregion
#region MultipleColumns
// 1 den fazla kolon ile  joinlenecek ise aşağıdaki syntax kullanılır. Bu sql sorgusu tarafında and işlemine karşılık gelir.
#region QuerySyntax
/*
var query = from product in context.Products
            join person in context.Persons //salary ile firstname eşitlenemediğinden dolayı hata veriyor. aşağıdaki bir örnek olsun diye yapıldı.
            on new { product.Id, product.Salary } equals new { person.Id, Salary = person.FirstName }
            select new
            {
                person.LastName,
                product.Name
            };
await query.ToListAsync();*/
#endregion
#region MethodSyntax
/*
context.Products
    .Join(context.Personels, product => new
    {
        product.Name
    },
    person => new
    {
        person.Name
    },
    (product, person) => new
    {
        person.Surname,
        product.Salary,
    });*/
#endregion
#endregion
#region MutlipleTableJoin
#region QuerySyntax
/*
var query = from product in context.Products
            join person in context.Persons
                on product.Id equals person.Id
            join p in context.Personels
                on product.Name equals p.Name
            select new
            {
                product.Name,
                person.CreatedDate,
                p.Id
            };
var datas = await query.ToListAsync();*/
#endregion
#region MethodSyntax
/*
var query = context.Persons
    .Join(context.Products,
    person => person.Id,
    product => product.Id,
    (person, product) => new
    {
        person.Id,
        person.LastName,
        product.Name
    })
    .Join(context.Personels, personProducts => personProducts.Id, p => p.Surname, (personProducts,p) => new
    {
        p.Surname,
        personProducts.LastName
    });*/
#endregion
#endregion
#region FromSql EF Core 7
//DotNet 7 ile gelen bir özellik olduğu için bu projeye değil de kendi başlığı altında değerlendirdim.
#endregion
#region View
#region View Nedir
//Karmaşık sorguları tekrar tekrar yazmak yerine view oluşturularak her çağrıldığında karmaşık sorgunun çalışmasını sağlayan veritabanı aracıdır.
/*
 * Veritabanı üzerinde view şu şekilde oluşturulur: 
 * Create View vm_Test
 * as
 * Select products.Name, Count(*) from products
 * join orders on products.Id=orders.Id
 * Group By products.Name, Count(*)
 */
//Başına Create view daha sonra view'e bir isim veriyor ve As takısı ile başlıyoruz.
#endregion
#region View Kod Tarafında Nasıl Oluşturulur.
//1.Adım boş bir migration oluşturulur.
//2.Adım Up metodu içerisine sorgu yazılır. Bknz: Migrations içerisindeki mig_View'e
//3.Adım Down metodu içerisine ise migration'ı geri aldığımızda yapılmasını istediğimiz yani view'in silinmesi için gerekli sorguyu yazıyoruz.
//End


/* Migration Up Fonksiyonu içerisine aşağıdaki gibi kod yazılır.
 
 migrationBuilder.Sql($@"
                
                Create view vm_ListBooks
                As
                Select * From Books
            ");
 
 */

/* Migration Down Fonksiyonu içerisine aşağıdaki gibi kod yazılır.
 migrationBuilder.Sql($@"Drop view vm_ListBooks");

 */
#endregion
#region View Kod Tarafında  Nasıl Tanımlanır.
/*
 View'in çıktısında hangi kolonlar oluyorsa buna uygun olarak nesne oluşturulur. 
 Bu nesne DbSet olarak tanımlanır.
 Son olarak OnModelCreating override'ı içerisinde gerekli configuration'ları yapıyoruz.
 */
#endregion
#region Kod Tarafında View Nasıl Kullanılır/Çalıştırılır.
//var bookAuthors= await context.BookAuthors.ToListAsync();
// Sorgulanan view'lere linq sorguları da ekstradan eklenebilmektedir. Örn: 
// var bookAuthorsThenCount5=await context.BookAuthors.Where(bo=>bo.Count>5).ToListAsync();
#endregion
#region View Dikkat Edilmesi Gerekenler
/*
 1- Viewlerde primary key olmaz bundan dolayı hasnokey ile işaretlenmelidir.
 2- View'ler change tracker tarafından takip edilmezler.
 */
#endregion
#endregion
#region Store Procedure

#endregion
#region GlabalQueryFilter

//Bu özellik ile fluent api üzerinde belirttiğimiz entity'e global/genel şart koyabiliyoruz.
// Yani belirtilen entity nasıl sorgulanırsa sorgulansın en sonunda queryfilter ile koyduğumuz filtre uygulanarak veritabanına gönderilir.
// Genellikle MultiTenancy uygulamalarda kullanılır.;

//await context.Persons.ToListAsync();

// await context.Persons.IgnoreQueryFilters().ToListAsync(); // Bu şekilde global olarak filtrelemeyi anlık olarak ignore/gözardı etmek istiyorsak IgnoreQueryFilters'ı kullanabiliriz.
#endregion
#region Owned Entity Type
// Nedir?
// Bazen Entity'lerimizi tıpkı kalıtım alır gibi parçalamak isteriz. Bunu yapabilmemizi sağlayan mekanizmadır.
// Örneğin Member/Üye entitimiz için belli özellikler var. Bunları gruplayarak farklı entity türlerinde saklayabiliyoruz. Misal FirstName,LastName,MiddleName'i bir grup, Adress ve Location 'ı farklı bir grup olarak tutabiliyoruz. Bunu yaptıktan sonra EF'ye bunun bir Owned Entity olduğunu belirtmek için fluen Api'da onModelCreating içerisinde OwnsOne özelliğini kullanmamız gerekmektedir.
//Aşağıdaki yapı incelenebilir.
//class Member
//{
//    public int Id { get; set; }
//    //public string FirsName { get; set; }
//    //public string LastName { get; set; }
//    //public string MiddleName { get; set; }
//    public MemberNameGroup MemberNameGroup { get; set; }
//    //public string Adress { get; set; }
//    //public string Location { get; set; }
//    public MemberAdressGroup MemberAdressGroup { get; set; }
//    public bool Active { get; set; }
//}

//class MemberNameGroup
//{
//    public string FirsName { get; set; }
//    public string LastName { get; set; }
//    public string MiddleName { get; set; }
//}
//class MemberAdressGroup
//{
//    public string Adress { get; set; }
//    public string Location { get; set; }
//}
#endregion
#region Temprol Tables
// Tablolara history/tarih/log atmayı sağlayan ef core 6.0 ile gelen özelliktir. Configuration kısmı onModelCreating kısmında yapılır. Bir tabloya Temprol özelliği kazandırmak için modelbuilder.Entity<TabloAdı>().ToTable("TabloyaVerdiğimizİsim", builder=>builder.IsTemporal) komutunu kullanıyoruz.

// Önemli not! Temprol Table veri kaydederken history/log tutmaz, sadece veri güncelleme esnasında kayıt tutar.
#endregion
#region Connection Resiliency 
// Veritabanı kopukluklarında nasıl bir yol izlememizi belirleyen stratejidir.
#region EnableRetryOnFailure
// EnableRetryOnFailure fonksiyonu ile veritabanı bağlantı kopukluklarında default ayarlarında bağlantıyı tekrar kurmaya çalışır. Configuration işlemleri fluent api tarafında onConfiguring metodunda yapılır.
#endregion
#region CustomExecution Strategy
// Custom bir class oluşturup bunu ExecutionStrategy sınıfından inherent ediyoruz ve overload'larını oluşturuyoruz. Daha sonra fluent api da ExecutionStrategy fonksiyonunu kullanarak oluşturduğumuz sınıfı buraya referansını veriyoruz.
#endregion
#region Bir işlem sırasında bağlantı kopukluğu olursa işlemin devam etme durumu hakkında

// bağlantı kesilmesi durumunda yarıda kalan işlemin en başından yapılması gerekmektedir. Execute fonksiyonu ile yapılan işlem commit edilene kadar devam edecek, eğer yarıda kalırsa işlemi başa alacak ve commit olana kadar tekrarlayacaktır. Örnek:

//var strategy = context.Database.CreateExecutionStrategy();

//await strategy.ExecuteAsync(async () =>
//{
//    using var transcation = context.Database.BeginTransaction();
//    await context.Personels.AddAsync(new() { Id = 1, Name = "Ahmet", Surname = "Dalhançer" });
//    context.SaveChanges();
//    transcation.Commit();
//});
#endregion
#endregion
#region Data Concurrency
// Concurrency => Eşzamanlı. Bazı durumlarda veri tutarsızlığı yaşıyoruz ve bu tutarsızlığı kontrol altına almak için concurrency yapısını kullanabiliriz. Örnek verecek olursak, bir veriyi güncellemek istediğimiz esnada farklı bir yerden aynı veri daha öncesinde güncellenmiş ise bu tutarsızlık demektir. Bu aşamada sistemin bizi uyarması gerekmektedir. Çok önemli bir konudur. Bunun iki farklı bir yaklaşımı vardır.
//1 - Pessimistic Lock (Kötümser  Kilitleme) : Bu yöntemi sadece fromSql cümlecikleri ile kullanabiliyoruz. Bu yöntem ile işlem yaparken commit olana kadar veritabanını kitler ve herhangi bir işlem yapmaya engel olur. Örnek kullanım
// context.Persons.FromSql($"Select * from Persons with XClock"); Xclock ile kilitliyoruz. Bu yöntem tercih edilen bir yöntem değildir.
//2 - Optimistic Lock(İyimser Kilitleme) : Bu yöntem ile kilitlediğimizde veritabanında farklı işlemler yapılabilir fakat bize veri tutarsızlığı olduğu zaman hata fırlatır. Örnek kullanım : Fluent Api tarafında ve ConcurrencyCheck attribute'u ile yapılabilir. Bakınız fluentApi.

// Belirlediğimiz kolona concurrency yapılanmasını uygulayabiliriz veya bir diğer yöntem ise rowVersion adında bir properti tanımlarız ve bu propertinin versiyon tutmasını, uyuşmazlık durumunda hata fırlatmasını bekleriz. Tanımlanan propertinin concurreny yapılanmasını uygulayabilmek için [Timestamp] attribute'u ile işaretlememiz gerekiyor.

//public byte[] rowVersion { get; set; }

#endregion
#region Transaction
// Transaction ile yapılan işlem son adıma kadar başarılı veya başarısız bir şekilde ilerlemesi durumuna göre aksiyon almaya yarar. Örneğin bir hesaptan başka bir hesaba para göndermek istedik. Bizim hesaptan para çıkışı oldu fakat karşı tarafın hesabına para yansımadı. Bu durumda tüm yapılan bu işlemlerin geriye alınması gerekmektedir. Bu durumu transaction ile kontrol altına alırız. Örneğin aşağıda bir veri eklemek istiyoruz.
//var transaction = await context.Database.BeginTransactionAsync();
//Product product = new() { Name="Ürün Adı", Price=12, Salary=34, ComputedValue=3 };
//context.Products.Add(product);
//await context.SaveChangesAsync();
//transaction.Commit(); // Yukarıda BeginTransaction ile transaction açtığımız için commit etmediğimiz sürece veritabanına veriyi göndermeyecektir.

#region RollbackToSavePoint
// Bu fonksiyon ile yaptığımız işlemlerin arasında işaretlemeler koyup gerektiğinde o işaretlerin olduğu yere kadar işlemeleri geri alabilyoruz. Yani rollback yapabiliyoruz. Örneği inceleyelim.

//var transaction =await context.Database.BeginTransactionAsync();
//Product product1 = new() { Name = "Ürün 1", ComputedValue = 1, Price = 1, Salary = 1 };
//Product product2 = new() { Name = "Ürün 2", ComputedValue = 2, Price = 2, Salary = 2 };

//await context.Products.AddAsync(product1);
//await context.SaveChangesAsync();
//await transaction.CreateSavepointAsync("station1"); // Bir durak oluşturuyoruz. Eğer gerek duyulursa bu durağa kadar işlemler geri alınabilecektir.

//await context.Products.AddAsync(product2);
//await context.SaveChangesAsync();


//await transaction.RollbackToSavepointAsync("station1"); // Bu fonksiyon ile araya koyduğumuz ve ismini station1 verdiğimiz durağa kadar işlemi geri alıyoruz.
//transaction.Commit();


#endregion
#endregion

public class Person
{
    public int Id { get; set; }
    public int Id2 { get; set; }
    //[ConcurrencyCheck()] Attribute'u ile concurreny yapılanmasını uyguluyoruz.
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
    public int AuthorId { get; set; }
    //public Byte[] rowVersion { get; set; }
    public string BookName { get; set; }

    public ICollection<Author> Authors { get; set; }
}
class Author
{
    public int Id { get; set; }
    public int BookId { get; set; }
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
class SelectPersonView
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
//class BookAuthor
//{ //Bu view için tanımlanan bir nesnedir. View çıktısında aşağıdaki kolonlar olduğundan dolayı propertileri bu şekilde verilmektedir.
//    //public string  Name { get; set; }
//    //public int Count { get; set; }
//} 
//TablePerHierarchy sınıfları bitişi.
public class ExampleDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Product> Products { get; set; }
    /*public DbSet<BookAuthor> BookAuthors { get; set; } */// View nesnesini DbSet olarak tanımlıyoruz fakat onModelCreating içerisinde bir tablo değil view olduğunu belirtiyoruz.

    //TableForHierarchy dbsetlerin tanımlanması.
    public DbSet<Personel>? Personels { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Technician>? Technicians { get; set; }
    //TableForHierarchy dbsetlerin tanımlanması bitiş.

    #region ConConfiguringSqlServerConnection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=EfExampleDb;Encrypt=False;Trusted_Connection=True;");
        #region EnableRetryOnFailure Nedir
        //EnableRetryOnFailure ile veri tabanı bağlantı kopmalarında defaul şekilde bağlantıyı belli aralıkla ve belli sayıda tekrar kurmaya çalışır. Bu fonksiyon defaul değerlerde işlem yapar.

        //maxRetryCount : Deneme sayısı,maxRetryDelay: bekleme süresi, errorNumbersToAdd: port, LogTo: bağlantı kopuşlarında loglama yapılır.
        #endregion
        #region Default Execution Stategy Options

        //optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=EfExampleDb;Trusted_Connection=True;",builder => builder.EnableRetryOnFailure(
        //    maxRetryCount: 7,
        //    maxRetryDelay: TimeSpan.FromSeconds(7),
        //    errorNumbersToAdd: new[] { 4060 }))
        //.LogTo(logger: eventData => Console.WriteLine("Bağlantı tekrar kuruluyor..."), filter: null);

        //Aşağıdaki ayar ile Ef core içerisindeki loglama mekanizmasını kullanabiliyoruz. EnableDetailed ile detaylı loglama, enablesensitive ile hasssas verilerin de loglanmasını istiyoruz.
        // optionsBuilder.LogTo(msg => Console.WriteLine(msg)).EnableDetailedErrors().EnableSensitiveDataLogging();
        #endregion
        #region Custom Execution Stategy Options
        //optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=EfExampleDb;Trusted_Connection=True;",
        //    builder=>builder.ExecutionStrategy(dependencies=>new CustomExecutionStrategy(dependencies, 15,TimeSpan.FromSeconds(15))));
        #endregion
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
        #region View Tanımlanması
        //modelBuilder.Entity<BookAuthor>()
        //    .ToView("vm_BookAuthors") //ToView ile nesnenin Tablo değil View olduğunu belirtiyoruz.
        //    .HasNoKey(); // bir key olmadığını belirtiyoruz.
        #endregion
        #region vm_BookAuthor
        //vm_BookAuthor bir view olduğu için key'in olmadığını ve bir view olduğunu aşağıdaki gibi belirtiyoruz.
        //modelBuilder.Entity<BookAuthor>()
        //    .ToView("vm_BookAuthor")
        //    .HasNoKey();
        #endregion
        #region QueryFilter

        //modelBuilder.Entity<Person>()
        //.HasQueryFilter(p => p.Active); Bu şekilde tüm sorgulara genel olarak filtre eklemiş olduk. Yani tüm yapılan sorgulamalara ek olarak Person'ın Active olması da bekleniyor.
        #endregion
        #region Owned Entity Type

        //modelBuilder.Entity<Member>().OwnsOne(m => m.MemberAdressGroup);
        //modelBuilder.Entity<Member>().OwnsOne(m => m.MemberNameGroup);

        #endregion
        #region Temprol Table Configuration
        //modelBuilder.Entity<Person>().ToTable("Persons", builder => builder.IsTemporal());
        #endregion
        #region Data Concurrency
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.CreatedDate)
        //    .IsConcurrencyToken(); // is ConcurencyToken ile belirlediğimiz entity için concurrency yapılanmasını uygulayabiliyoruz.
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
    #region CustomExecution Class
    //class CustomExecutionStrategy : ExecutionStrategy // Custom oluşturduğumuz bağlantı kopukluğunda uygulanacak stratejimiz.
    //{
    //    public CustomExecutionStrategy(DbContext context, int maxRetryCount, TimeSpan maxRetryDelay) : base(context, maxRetryCount, maxRetryDelay)
    //    {
    //    }

    //    public CustomExecutionStrategy(ExecutionStrategyDependencies dependencies, int maxRetryCount, TimeSpan maxRetryDelay) : base(dependencies, maxRetryCount, maxRetryDelay)
    //    {
    //    }

    //    protected override bool ShouldRetryOn(Exception exception)
    //    {
    //        Console.WriteLine("Bağlantı kuruluyor...");
    //        return true;
    //    }
    //}
    #endregion

}