using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    class Penguin : Animal
    {
        public Penguin(string name, DateTime birthdate)
            : base(name, "Penguin", birthdate) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} siger: Honk!");
        }
    }
}
