using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Conversions
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=ValueConversionsApplicationDb;Encrypt=False;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region HasConversions Nedir?
            //Verileri veritabanından çekerken veya veri ekleyip/güncellerken verilere manipüle etmemizi sağlayan yapıdır. Örneğin aşağıdaki örnekte Eklemek istediğimiz veri Male olarak gelirse veritabanına "M" olarak kayıt olmasını sağlıyoruz. Daha sonra veritabanından veriyi çekerken eğer "M" olarak geliyorsa biz "Male" olarak değiştiririz. Bu şekilde veriler üzerinde manipüle yapabiliriz.

            #region Value Converter
            //modelBuilder.Entity<Person>()
            //    .Property(p => p.Gender)
            //    .HasConversion(g => g == "Male" ? "M" : "F", g => g == "M" ? "Male" : "Female"); // virgülden önceki kısım update ve insert işlemlerinde manupule etmek için , virgülden sonraki ikinci kısım ise select sorgusunda veriyi manipule etmek için uygulanır.
            #endregion
            #region Enum Değerler ile Value Converter
            // Enum değerler üzerinde de manipülasyon yapabiliyoruz. Aşağıdaki örnekte Gender2 bir enum türündedir. Bunu veritabanına kaydederken string türde kaydediyoruz. Normalde enum türü integer değer olarak kaydedilirler. Çekerken de Gender'a pars edip çekiyoruz.
            //modelBuilder.Entity<Person>()
            //    .Property(p => p.Gender2)
            //    .HasConversion(g => g.ToString(), g => (Gender)Enum.Parse(typeof(Gender), g)); // update ve insert işlemlerinde verdiğimiz enum değeri string'e dönüştürüp veritabanına gönderiyor. Select işlemi için de Gender'e pars edip çekiyoruz.
            #endregion
            #region ValueConverter sınıfı ile dönüşüm işlemlerini yapma
            //ValueConverter<Gender, string> converter = new(g => g.ToString(), g => (Gender)Enum.Parse(typeof(Gender), g));
            //modelBuilder.Entity<Person>()
            //    .Property(p=>p.Gender)
            //    .HasConversion(converter);
            #endregion

            #endregion
            modelBuilder.Entity<Person>()
                .HasData(new[] { new Person() { Id = 1, Name = "Ahmet", Gender = "M", Gender2 = Gender.Male },
                new Person() { Id = 2, Name = "Mehmet ", Gender = "M", Gender2 = Gender.Male },
                new Person() { Id = 3, Name = "Ali", Gender = "M", Gender2 = Gender.Male },
                new Person() { Id = 4, Name = "Fatma", Gender = "F", Gender2 = Gender.Female },
                new Person() { Id = 5, Name = "Ayşe", Gender = "F", Gender2 = Gender.Female },});

        }
    }
}
