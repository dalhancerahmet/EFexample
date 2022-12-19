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

       var persons= context.Persons.ToList();
        Console.WriteLine();
    }
}