using System;

namespace zoo_opg
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo myZoo = SetupZoo();

            myZoo.ListAllAnimals();

            // Få dyrepasserne til at udføre deres opgaver
            FeedAndClean(myZoo);

            Console.WriteLine("Tryk på en tast for at afslutte...");
            Console.ReadKey();
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
