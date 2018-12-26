using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CollectionTest
{
    public class ListTest
    {
        public static void RacerTest()
        {
            var graham = new Racer(7, "Graham", "Hill", "UK", 14);
            var emerson = new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14);
            var mario = new Racer(16, "Mario", "Andretti", "USA", 12);

            var racers = new List<Racer>(20) { graham, emerson, mario };

            racers.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91));
            racers.Add(new Racer(27, "Mika", "Hakkinen", "Finland", 20));

            racers.AddRange(new Racer[] {
                new Racer(14, "Niki", "Lauda", "Austria", 25),
                new Racer(21, "Alain", "Prost", "France", 51)});

            // insert elements

            racers.Insert(3, new Racer(6, "Phil", "Hill", "USA", 3));

            // accessing elements

            for (int i = 0; i < racers.Count; i++)
            {
                Console.WriteLine(racers[i]);
            }

            foreach (var r in racers)
            {
                Console.WriteLine(r);
            }

            // searching
            int index1 = racers.IndexOf(mario);
            int index2 = racers.FindIndex(new FindCountry("Finland").FindCountryPredicate);
            int index3 = racers.FindIndex(r => r.Country == "Finland");
            Racer racer = racers.Find(r => r.FirstName == "Niki");
            List<Racer> bigWinners = racers.FindAll(r => r.Wins > 20);
            foreach (Racer r in bigWinners)
            {
                Console.WriteLine($"{r:A}");
            }

            Console.WriteLine();


            // remove elements

            if (!racers.Remove(graham))
            {
                Console.WriteLine("object not found in collection");
            }



           
        }

        public static void SortTest()
        {
            var racers2 = new List<Racer>(new Racer[] {
                new Racer(12, "Jochen", "Aindt", "Austria", 6),
                new Racer(12, "Zochen", "Gindt", "Austria", 6),
                new Racer(12, "Aochen", "Findt", "Austria", 6),
                new Racer(22, "Gyrton", "Cenna", "Brazil", 41) }
            );
            //排序之前
            Console.WriteLine("排序之前··········");
            foreach (var ra in racers2)
            {
                Console.WriteLine(ra.LastName);
            }
            Console.WriteLine("IComparable··········");
            racers2.Sort();
            foreach (var ra in racers2)
            {
                Console.WriteLine(ra.LastName);
            }
            Console.WriteLine("Comparer············");
            racers2.Sort(new RacerComparer(CompareType.FirstName));
            foreach (var ra in racers2)
            {
                Console.WriteLine(ra.FirstName);
            }
            Console.WriteLine("Use delegate··········");
            racers2.Sort((r1,r2)=>r1.Wins.CompareTo(r2.Wins));
            foreach (var ra in racers2)
            {
                Console.WriteLine(ra.FirstName);
            }
        }

        public static void OtherTest()
        {
            var racers = new List<Racer>(new Racer[] {
                new Racer(12, "Jochen", "Aindt", "Austria", 6),
                new Racer(12, "Zochen", "Gindt", "Austria", 6),
                new Racer(12, "Aochen", "Findt", "Austria", 6),
                new Racer(22, "Gyrton", "Cenna", "Brazil", 41) }
            );
            var racer = racers.Find(r => r.FirstName == "Jochen");
            Console.WriteLine($"racer is :{JsonConvert.SerializeObject(racer)}");
            
        }

        public static void LookUpTest()
        {
            var racers = new List<Racer>(new Racer[] {
                new Racer(12, "Jochen", "Aindt", "Austria", 6),
                new Racer(12, "Zochen", "Gindt", "Austria", 6),
                new Racer(12, "Aochen", "Findt", "Austria", 6),
                new Racer(22, "GyrDDton", "Cenna", "Brazil", 41),
                new Racer(22, "GGHH", "Cenna", "China", 41),
                new Racer(22, "Gyrton", "Cenna", "Brazil", 41) }
            );
            var lookupRacers = racers.ToLookup(r => r.Country);
            foreach (var look in lookupRacers)
            {
                Console.WriteLine($"key:{look.Key}," +
                                  $"values:{JsonConvert.SerializeObject(look)}");
                foreach (var racer in look)
                {
                    Console.WriteLine(racer.Country);
                }
            }
        }

    }
}
