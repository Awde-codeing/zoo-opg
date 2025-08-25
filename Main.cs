using System;

namespace zoo_opg
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Zoo myZoo = SetupZoo();

                ShowMenu(myZoo);

                Console.WriteLine("Tryk på en tast for at afslutte...");
                Console.ReadKey();
            

        }
        static void ShowMenu(Zoo zoo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til Zoo-menuen!");
                Console.WriteLine("Vælg et dyr for at se detaljer, eller tryk 0 for at afslutte:");

                int index = 1;
                var animals = new List<Animal>();

                // List alle dyr i alle bure og gem i animals-listen
                foreach (var enclosure in zoo.GetEnclosures())
                {
                    Console.WriteLine($"--- {enclosure.Name} ---");
                    foreach (var animal in enclosure.GetAnimals())
                    {
                        Console.WriteLine($"{index}. {animal.Name} ({animal.GetType().Name})");
                        animals.Add(animal);
                        index++;
                    }
                }

                Console.Write("\nDit valg: ");
                string input = Console.ReadLine();

                if (input == "0")
                    break;

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= animals.Count)
                {
                    var selectedAnimal = animals[choice - 1];
                    ShowAnimalDetails(selectedAnimal);

                    Console.WriteLine("\nTryk på en tast for at gå tilbage til menuen...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg, prøv igen.");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        static void ShowAnimalDetails(Animal animal)
        {
            Console.Clear();
            Console.WriteLine("Dyr detaljer:");
            Console.WriteLine($"Navn: {animal.Name}");
            Console.WriteLine($"Type: {animal.GetType().Name}");
            Console.WriteLine($"Fødselsdato: {animal.BirthDate.ToShortDateString()}");
            // Tilføj evt. flere detaljer hvis de findes i Animal-klassen
        }

        // Opretter og returnerer en færdig opsat Zoo
        static Zoo SetupZoo()
        {
            // Opret dyr
            Lion simba = new Lion("Simba", new DateTime(2015, 5, 1));
            Elephant dumbo = new Elephant("Dumbo", new DateTime(2010, 11, 12));
            Giraffe geoffrey = new Giraffe("Geoffrey", new DateTime(2012, 3, 15));
            Penguin skipper = new Penguin("Skipper", new DateTime(2018, 7, 10));

            // Opret bure
            Enclosure savannahEnclosure = new Enclosure("Savannah", 600);
            Enclosure arcticEnclosure = new Enclosure("Arktis", 300);

            // Tilføj dyr til bure
            savannahEnclosure.AddAnimal(simba);
            savannahEnclosure.AddAnimal(geoffrey);

            arcticEnclosure.AddAnimal(skipper);
            arcticEnclosure.AddAnimal(dumbo);

            // Opret dyrepassere
            Zookeeper john = new Zookeeper("John", 30, savannahEnclosure);
            Zookeeper anna = new Zookeeper("Anna", 28, arcticEnclosure);

            // Opret zoo og tilføj bure
            Zoo myZoo = new Zoo("Copenhagen Zoo");
            myZoo.AddEnclosure(savannahEnclosure);
            myZoo.AddEnclosure(arcticEnclosure);

            return myZoo;
        }
    }
}
