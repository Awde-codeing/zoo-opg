using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    class Giraffe : Animal
    {
        public Giraffe(string name, DateTime birthdate)
            : base(name, "Giraffe", birthdate) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} siger: Hum!");
        }
    }

}
