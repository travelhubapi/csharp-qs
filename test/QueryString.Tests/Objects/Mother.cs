using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryString.Tests.Objects
{
    public class Mother: Person
    {
        public Person[] Children { get; set; }

        public Mother(string name, int age)
            :base(name, age)
        {

        }
    }
}
