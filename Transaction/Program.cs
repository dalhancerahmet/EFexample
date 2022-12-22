using Value_Conversions;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new ApplicationDbContext();
        var transaction=  context.Database.BeginTransaction();
        Thread.Sleep(1000);
        Person person3 = new() { Name = "Kamil", Gender = "M", Gender2 = Gender.Male, Married = false};
        context.Persons.Add(person3);
        context.SaveChanges();
    }
}