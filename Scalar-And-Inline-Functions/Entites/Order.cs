using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scalar_And_Inline_Functions.Entites
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Person Person { get; set; }
    }
}
