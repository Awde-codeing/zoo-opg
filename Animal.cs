using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    abstract class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime Birthdate { get; set; }

        public Animal(string name, string species, DateTime birthdate)
        {
            Name = name;
            Species = species;
            Birthdate = birthdate;
        }
        public abstract void MakeSound();

        public void eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
        public void sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }
        public int GetAge()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - Birthdate.Year;
            if (Birthdate > today.AddYears(-age)) age--;
            return age;

        }
    }
}