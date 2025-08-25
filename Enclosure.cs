using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    public class Enclosure
    {
        public string Name { get; set; }
        public int Size { get; set; }
        private List<Animal> animals;

        public Enclosure(string name, int size)
        {
            Name = name;
            Size = size;
            animals = new List<Animal>();
        }
        public List<Animal> GetAnimals()
        {
            return animals;
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
            Console.WriteLine($"Dyr i {Name}:");
            if (animals.Count == 0)
            {
                Console.WriteLine("Ingen dyr i buret.");
            }
            else
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine($"- {animal.Name} ({animal.Species}), {animal.GetAge()} år gammel");
                }
            }
        }
    }
}
