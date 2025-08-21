using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    public class Zoo
    {
        public string Name { get; set; }
        public List<Enclosure> Enclosures { get; set; }
    
         public Zoo(string name)
        {
            Name = name;
            Enclosures = new List<Enclosure>();
        }
        public void AddEnclosure(Enclosure enclosure)
        {
            if (!Enclosures.Contains(enclosure))
            {
                Enclosures.Add(enclosure);
                Console.WriteLine($"{enclosure.Name} er tilføjet til zoo.");
            }
            else
            {
                Console.WriteLine($"{enclosure.Name} findes allerede i zoo.");
            }
        }
        public void ListAllAnimals()
        {
            Console.WriteLine($"Alle dyr i zooen '{Name}':");

            foreach (Enclosure enclosure in Enclosures)
            {
                Console.WriteLine($"Buret '{enclosure.Name}' har følgende dyr:");

                if (enclosure.Animals.Count == 0)
                {
                    Console.WriteLine("  Ingen dyr i dette bur.");
                }
                else
                {
                    foreach (Animal animal in enclosure.Animals)
                    {
                        Console.WriteLine($"  - {animal.Name} ({animal.Species}), {animal.GetAge()} år");
                    }
                }
            }
        }
        public List<Enclosure> GetEnclosures()
        {
            return Enclosures;
            
        }
        public void ListEnclosures()
        {
            Console.WriteLine($"Bure i {Name}:");
            if (Enclosures.Count == 0)
            {
                Console.WriteLine("Ingen bure i zoo.");
            }
            else
            {
                foreach (var enclosure in Enclosures)
                {
                    Console.WriteLine($"- {enclosure.Name}, Størrelse: {enclosure.Size}");
                }
            }
        }
    }
}
