using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryString.Tests.Objects
{
    public class Father: Person
    {
        public Person Child { get; set; }

        public Father(string name, int age)
            :base(name, age)
        {

        }
    }
}
