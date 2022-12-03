using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalar_And_Inline_Functions.Entites
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
