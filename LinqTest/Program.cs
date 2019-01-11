using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleData();
            Console.ReadKey();
        }

        static void SampleData()
        {
            const int arraysize = 50000000;
            var r = new Random();
            var arr = Enumerable.Range(0, arraysize).Select(x => r.Next(140)).ToList();
            var res = (from x in arr.AsParallel()
                where Math.Log(x) < 4
                select x
            ).Average();

        }

        static void TestLookUp()
        {
            var racers = (from r in Formula1.GetChampions()
                from c in r.Cars
                select new
                {
                    Car = c,
                    Racer = r
                }
            ).ToList();
            //ToLookup(cr => cr.Car, cr => cr.Racer)
        }

        private static void GroupByTest()
        {
            var countries = from r in Formula1.GetChampions()
                group r by r.Country
                into g
                orderby g.Key, g.Count() descending
                where g.Count() >= 2
                select new
                {
                    Country = g.Key,
                    Count = g.Count()
                };
            var countries2 = Formula1.GetChampions().GroupBy(r => r.Country).OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key).Where(g => g.Count() > 1)
                .Select(g => new {Country=g.Key, Count=g.Count()});

            //var countries3 = Formula1.GetChampions().GroupBy(r => r.Country).OrderByDescending(g => g.Count())
            //    .ThenBy(g => g.Key).Where(g => g.Count() > 1)
            //    .SelectMany(g =>
            //        {
                        
            //        }
            //    );

            foreach (var country in countries2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{country.Country}--{country.Count}");
                Console.ResetColor();
            }
        }

        private static void SelectMany2()
        {
            // flatten the year list to return a list of all racers and positions in the championship 
            var racers = Formula1.GetChampionships()
                .Select(cs => new List<dynamic>()//Count是67 ， 如果换成SelectMany Count 是 201
                {
                    new
                    {
                        Year = cs.Year,
                        Position = 1,
                        Name = cs.First
                    },
                    new
                    {
                        Year = cs.Year,
                        Position = 2,
                        Name = cs.Second
                    },
                    new
                    {
                        Year = cs.Year,
                        Position = 3,
                        Name = cs.Third
                    }
                }).ToList();


            foreach (var s in racers)
            {
                WriteLine(s);
            }
        }
    }
}
