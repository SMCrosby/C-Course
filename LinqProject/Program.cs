using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject {
    
    class State {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class City {
        public string Name { get; set; }
        public int StateId { get; set; }
    }
    
    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Language Integrated Query - Linq\n=================================");

            var states = new List<State> {
                new State {Id = 1, Name = "Ohio"}, 
                new State {Id = 2, Name = "Kentucky"},
                new State {Id = 3, Name = "Indiana"},
            };
            var cities = new List<City> {
                new City { Name = "Cincinnati", StateId = 1},
                new City { Name = "Columbus", StateId = 1},
                new City { Name = "Cleveland", StateId = 1},
                new City { Name = "Newport", StateId = 2},
                new City { Name = "Covington", StateId = 2},
                new City { Name = "Indianapolis", StateId = 3}
            };

            var citiesStates = from s in states
                               join c in cities
                               on s.Id equals c.StateId  //first referenced must be the same as from clause // uses keyword equals instead of =
                               select new {         //list coloumns we want
                                   City = c.Name, State = s.Name 
                               };
            foreach(var cs in citiesStates.ToList()) {
                Console.WriteLine($"City/State is: \t{cs.City} \t{cs.State}");
            
            }






            var nbrs = new List<int> {
                268,876,510,365,219,299,489,390,965,993,
                419,726,282,926,681,206,263,481,501,456,
                744,976,792,201,674,595,805,360,973,203,
                913,747,356,437,897,170,151,906,684,763,
                369,332,215,660,666,366,272,127,543,803,
                175,823,119,427,963,478,553,903,384,220,
                471,164,401,236,539,845,805,489,209,273,
                944,261,529,570,206,401,157,870,266,861,
                411,487,600,702,177,829,810,371,932,262,
                286,467,834,303,842,544,659,738,431,458
            };

            //avg #'s >= 500
            var avgGte500 = nbrs.Where(i => i >= 500).Average();        //Method syntax 
            avgGte500 = (from i in nbrs                                 //Query syntax 
                         where i >= 500
                         select i).Average();

            var nbrsGte500 = from i in nbrs
                             where i >= 500
                             select i;
            avgGte500 = nbrsGte500.Average();

            //Sum #'s divisable by 3 || 7
            var sumDivBy3or7 = nbrs.Where(n => n % 3 == 0 || n % 7 == 0)            //Query to note for reference
                                   .Sum();

            var Add37 = (from i in nbrs
                        where i%3 == 0 || i%7 == 0
                        select i).Sum();




            var ints = new int[] { 1, 3, 5, 7, 9, 11, 13, 17 };
            Console.WriteLine("\n\nThe givin ints are:");
            foreach (int i in ints) {
                Console.Write(i + " ");
            }

            //Are ALL ints odd?
            var allAreOdd = ints.All(i => i % 2 == 1);


            //Sum of #'s > 7
            var sumGt7 = ints.Where(i => i > 7).Sum();
            Console.WriteLine($"\n\nThe sum of ints greater than 7 is: {sumGt7}");
            sumGt7 = (from i in ints        //query syntax
                     where i > 7
                     select i).Sum();

            //Avg of all #'s <= 11
            var avgLte11 = ints.Where(i => i <= 11).Average();
            Console.WriteLine($"\nThe Average of ints less than or equal to 11 is: {avgLte11}");
            avgLte11 = (from i in ints
                        where i <= 11
                        select i).Average();


            var max = ints.Max();
            var min = ints.Min();
            var sum = ints.Sum();
            var cnt = ints.Count();
            var avg = ints.Average();


        }
    }
}
