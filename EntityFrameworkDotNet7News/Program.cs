using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static  void Main(string[] args)
    {
        ExampleDbContext context = new();
        #region ExecuteUpdate
        // .Net 7 ile gelen bir özelliktir. Toplu güncelleme işlemlerini yapmamızı sağlar. Aşağıdaki örnekte görüldüğü gibi.

        //context.Persons.Where(p => p.Id > 5).ExecuteUpdate(p => p.SetProperty(p => p.FirstName, v => v.FirstName + "yeni"));
        #endregion
        #region ExecuteDelete
        //.Net 7 ile gelen bir özelliktir. Toplu silme işlemlerini yapmamızı sağlar. Aşağıdaki örnekte görüldüğü gibi.

         context.Persons.Where(p => p.FirstName.StartsWith("B")).ExecuteDeleteAsync();

        //executeupdate ve executedelete fonksiyonları ile toplu işlem yaparken savechanges fonksiyonunu çağırmamıza gerek kalmadan direkt olarak veritabanına komutu göndermektedir.
        #endregion

    }
}