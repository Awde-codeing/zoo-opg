using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    class Enclosure
    {
        public string Name { get; set; }
        public int Size { get; set; } // i m²
        private List<Animal> animals;

        public Enclosure(string name, int size)
        {
            Name = name;
            Size = size;
            animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            if (!animals.Contains(animal))
            {
                animals.Add(animal);
                Console.WriteLine($"{animal.Name} er tilføjet til {Name}.");
            }
            else
            {
                Console.WriteLine($"{animal.Name} er allerede i {Name}.");
            }
        }
        public void RemoveAnimal(Animal animal)
        {
            if (animals.Contains(animal))
            {
                animals.Remove(animal);
                Console.WriteLine($"{animal.Name} er fjernet fra {Name}.");
            }
            else
            {
                Console.WriteLine($"{animal.Name} findes ikke i {Name}.");
            }
        }
        public void ListAnimals()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine($"Der er ingen dyr i {Name}.");
            }
            else
            {
                Console.WriteLine($"Dyr i {Name}:");
                foreach (var animal in animals)
                {
                    Console.WriteLine($"- {animal.Name} ({animal.Species})");
                }
            }

        }
    }
}
