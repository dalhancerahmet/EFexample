// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Value_Conversions;

#nullable disable

namespace ValueConversions.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221222130706_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Value_Conversions.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender2")
                        .HasColumnType("int");

                    b.Property<bool>("Married")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titles")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gender = "M",
                            Gender2 = 0,
                            Married = false,
                            Name = "Ahmet"
                        },
                        new
                        {
                            Id = 2,
                            Gender = "M",
                            Gender2 = 0,
                            Married = false,
                            Name = "Mehmet "
                        },
                        new
                        {
                            Id = 3,
                            Gender = "M",
                            Gender2 = 0,
                            Married = false,
                            Name = "Ali"
                        },
                        new
                        {
                            Id = 4,
                            Gender = "F",
                            Gender2 = 1,
                            Married = false,
                            Name = "Fatma"
                        },
                        new
                        {
                            Id = 5,
                            Gender = "F",
                            Gender2 = 1,
                            Married = false,
                            Name = "Ayşe"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
