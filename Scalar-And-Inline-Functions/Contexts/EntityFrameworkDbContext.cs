using Microsoft.EntityFrameworkCore;
using Scalar_And_Inline_Functions.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scalar_And_Inline_Functions.Contexts
{
    public class EntityFrameworkDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AHMET\\SQLEXPRESS;Database=EntityFrameworkExampleDb;Encrypt=False;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);
        }
    }
}
