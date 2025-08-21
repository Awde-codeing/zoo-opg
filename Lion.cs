using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    class Lion : Animal
    {
        public Lion(string name, DateTime birthdate)
            : base(name, "Lion", birthdate) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} siger: Roar!");
        }

        public void Hunt()
        {
            Console.WriteLine($"{Name} er på jagt.");
        }
    }
}
