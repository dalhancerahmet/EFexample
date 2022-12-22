using Microsoft.EntityFrameworkCore;
using Value_Conversions;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new ApplicationDbContext();

        //var persons=  context.Persons.ToList();
        //context.Persons.Add(new Person { Name = "Ziya", Gender = "Male", });
        //context.SaveChanges();
        //Person person1 = new Person{ Name="BlaBla", Gender="M", Gender2=Gender.Male, Married=true, Titles= new List<string> {"A", "B" }  };
        //context.Persons.Add(person1);
        //context.SaveChanges();
       var persons= context.Persons.ToList();
        Console.WriteLine();
    }
}