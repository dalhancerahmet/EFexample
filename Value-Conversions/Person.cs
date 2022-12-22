using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_Conversions
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Gender Gender2 { get; set; }
        public bool Married { get; set; }
        public List<string>? Titles { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
