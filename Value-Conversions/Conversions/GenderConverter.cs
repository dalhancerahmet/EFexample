using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Value_Conversions.Conversions
{
    public class GenderConverter : ValueConverter<Gender, string>
    {
        public GenderConverter() : base(g=>g.ToString(),g=>(Gender)Enum.Parse(typeof(Gender),g))
        {
        }

        // Bir sınıfın converter sınıfı olması için ValueConverter sınıfından kalıtım alması lazım. Gender tipini veriyoruz ve dönüşümün hangi türe olduğunu belirtiyoruz. Daha sonra base'e işlemi yapıp gönderiyoruz. Bu işlemde update ve inster işlemlerinde Gender'ın string olarak kaydedilmesini sağlıyoruz. Select işleminde de tam tersi.
    }
}
