using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace zoo_opg
{
    public class Zookeeper
    {
        // Attributter
        public string Name { get; set; }
        public int Age { get; set; }
        public Enclosure AssignedEnclosure { get; set; }

        // Constructor
        public Zookeeper(string name, int age, Enclosure assignedEnclosure)
        {
            Name = name;
            Age = age;
            AssignedEnclosure = assignedEnclosure;
        }

        // Metoder
        public void FeedAnimals()
        {
            Console.WriteLine($"Dyrene i buret '{AssignedEnclosure.Name}' fodres.");
        }

        public void CleanEnclosure()
        {
            Console.WriteLine($"Buret '{AssignedEnclosure.Name}' bliver rengjort.");
        }



    }
}


