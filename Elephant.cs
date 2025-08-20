using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    class Elephant : Animal
    {
        public Elephant(string name, DateTime birthdate)
            : base(name, "Elephant", birthdate) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} siger: Trumpet!");
        }
    }
}
