using System;
using System.Collections.Generic;

namespace zoo_opg
{
    public class Zoo
    {
        private List<Enclosure> enclosures = new List<Enclosure>();
        public string Name { get; private set; }

        public Zoo(string name)
        {
            Name = name;
        }

        public void AddEnclosure(Enclosure enclosure)
        {
            enclosures.Add(enclosure);
        }

        public List<Enclosure> GetEnclosures()
        {
            return enclosures;
        }

        public void ListAllAnimals()
        {
            Console.WriteLine($"Dyr i {Name}:");
            foreach (var enclosure in enclosures)
            {
                Console.WriteLine($"--- {enclosure.Name} ---");
                foreach (var animal in enclosure.GetAnimals())
                {
                    Console.WriteLine($"- {animal.Name} ({animal.GetType().Name}), {animal.GetAge()} år gammel");
                }
            }
        }

        // Hovedmenuen for zooen
        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine($"=== Velkommen til {Name} ===");
                Console.WriteLine("1. Vis alle dyr");
                Console.WriteLine("2. Se detaljer om et dyr");
                Console.WriteLine("3. Få dyrepasserne til at fodre og gøre rent");
                Console.WriteLine("0. Afslut");
                Console.Write("Vælg en mulighed: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        ListAllAnimals();
                        Pause();
                        break;

                    case "2":
                        ShowAnimalSelection();
                        break;

                    case "3":
                        Console.Clear();
                        FeedAndClean();
                        Pause();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        System.Threading.Thread.Sleep(1000);
                        break;
                }
            }
        }

        // Undermenu til at vælge dyr og se detaljer
        private void ShowAnimalSelection()
        {
            var animals = new List<Animal>();
            int index = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vælg et dyr for at se detaljer:");
                foreach (var enclosure in enclosures)
                {
                    Console.WriteLine($"--- {enclosure.Name} ---");
                    foreach (var animal in enclosure.GetAnimals())
                    {
                        Console.WriteLine($"{index}. {animal.Name} ({animal.GetType().Name})");
                        animals.Add(animal);
                        index++;
                    }
                }

                Console.WriteLine("0. Tilbage til menu");
                Console.Write("Dit valg: ");

                string input = Console.ReadLine();

                if (input == "0")
                {
                    return; // Tilbage til hovedmenu
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= animals.Count)
                {
                    ShowAnimalDetails(animals[choice - 1]);
                    Pause();
                    return;
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        // Viser detaljer for et bestemt dyr
        private void ShowAnimalDetails(Animal animal)
        {
            Console.Clear();
            Console.WriteLine("Dyr detaljer:");
            Console.WriteLine($"Navn: {animal.Name}");
            Console.WriteLine($"Type: {animal.GetType().Name}");
            Console.WriteLine($"Fødselsdato: {animal.BirthDate.ToShortDateString()}");
            Console.WriteLine($"Alder: {animal.GetAge()} år");
            // Tilføj gerne flere detaljer hvis du har dem
        }

        // Simpel pause funktion
        private void Pause()
        {
            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }

        // Få dyrepasserne til at fodre og gøre rent
        private void FeedAndClean()
        {
            Console.WriteLine("Dyrepasserne går i gang med deres arbejde:\n");

            foreach (var enclosure in enclosures)
            {
                // Eksempel på dyrepasser til hvert bur (du kan lave din egen struktur her)
                Zookeeper keeper = new Zookeeper("Dyrepasser", 30, enclosure);
                keeper.FeedAnimals();
                keeper.CleanEnclosure();
            }
        }
        // Metode til at få dyrepassere til at fodre og gøre rent
        static void FeedAndClean(Zoo zoo)
        {
            Console.WriteLine("\nDyrepasserne går i gang med deres arbejde:\n");


            Enclosure savannahEnclosure = null;
            Enclosure arcticEnclosure = null;

            foreach (Enclosure e in zoo.GetEnclosures())
            {
                if (e.Name == "Savannah") savannahEnclosure = e;
                else if (e.Name == "Arktis") arcticEnclosure = e;
            }

            if (savannahEnclosure != null)
            {
                Zookeeper john = new Zookeeper("John", 30, savannahEnclosure);
                john.FeedAnimals();
                john.CleanEnclosure();
            }

            if (arcticEnclosure != null)
            {
                Zookeeper anna = new Zookeeper("Anna", 28, arcticEnclosure);
                anna.FeedAnimals();
                anna.CleanEnclosure();
            }
        }

    } 
   
}
