using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime BirthDate { get; set; }

        public Animal(string name, string species, DateTime birthdate)
        {
            Name = name;
            Species = species;
            BirthDate = birthdate;
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
            int age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;

        }
    }
}