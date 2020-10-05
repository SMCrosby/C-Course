using System;
using System.Collections.Generic;

namespace GenericCollection {
    class Program {

        static void Main(string[] args) {


            var rnd = new Random();
            var nbr = rnd.Next(0, 31);          // (min, max number) (will never hit max number so do max nbr+1)
            ////int i = 0;

            //var Score = new int[10];
            //if (i < 10) {
            //    i += i;
            //   Score[i] = nbr;
            //   Score[i].Add(nbr);
            //}

            var game = new List<int>();
            for(var idx = 1; idx <= 10; idx++) {
                var score = rnd.Next(0, 31);
                game.Add(score);

            }

            var total = 0;
            foreach(var score in game) {
                total += score;             //score plus new = new total
            }

            Console.WriteLine($"Bowling score is {total}");






            var names = new List<string>();    // generics are classes   -- generally interect with them with methods
            names.Add("Elena");
            names.Add("Christian");
            names.Add("Tracy");
            names.Add("Fred");
            names.Add("Yvonne");
            names.Add("Mark");
            names.Add("Manami");
            names.Add("Sarah");
            names.Sort();                       //automaticly sorts them by alphabeticly desc

            foreach(var name in names) {
                Console.WriteLine(name);
            }
            
            names.Remove("Fred");               //Removes an unwanted entry
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }


        }
    }
}
