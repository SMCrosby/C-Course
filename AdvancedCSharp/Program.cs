using System;
using System.Collections.Generic;

namespace AdvancedCSharp {
    class Program {         //if you make a class static all included methods and variables must be static

        Mathmatics<double> coll = new Mathmatics<double>();

        private void TestCollection() {
            coll.Add(1.7);
            coll.Add(7.37);
            coll.Add(-22);
        }



        //Lambda in Methods
                //private int Add(int a, int b) {
                //    return a + b;
                //}
        private int Add(int a, int b) => a + b;     //Same function as the commented out block -- Not super commonly used 



        //Rethrowing Exceptions
        private void RethrowingExceptions() {
            try {
                throw new BootcampException("Throw this exception");
                //var ex = new BootcampException("Throw this exception");       --another way to do above by creating a variable
                //throw ex
            } 
            catch (BootcampException ex) {                    //ex is just a variable
                // if we can't handle the exception
                throw;      //cancels our catch block -- throw without variable so it gives the correct line where the exception occurs
            }
        }


        //Colection Initializers
        //List<int>
        List<int> ints = new List<int> { 1, 2, 3, 4, 5 };

        //Dictionary<int, Bootcamp>
        Dictionary<string, Bootcamp> bootcamps = new Dictionary<string, Bootcamp> {
            ["CSharp"] = new Bootcamp(),
            ["Java"] = new Bootcamp()
        };

        void AccessDictionary() {
            var csharpBc = bootcamps["CSharp"];
        }





        static int i = 10;
        static string a = "ABC";

        static void Elena() {
            Console.WriteLine("Hi Elena!");
        }

        static void Main(string[] args) {
            Console.WriteLine("Advanced C Sharp");
            Console.WriteLine("=================");

            string a = "abc";
            int stringlength = a.Length;
            Console.WriteLine($"The string has {stringlength} characters in it");


            Program.Elena();
            var program = new Program();
            program.Run();
        }
        void Run() {

            var stateCode = "OH";
            var stateName = "";

            // Switch Statement
            switch(stateCode) {                                 //Switch statements go directly to the matching data
                case "OH": stateName = "Ohio"; break;           //break says we're done with this case
                case "KY": stateName = "Kentucky"; break;
                case "IN": stateName = "Indiana"; break;
                default: stateName = "I Don't Know"; break      //defaults to I don't know. --the same as the end of an else statement
            }

            //Switch Expression     -- does the same as the statement above just different syntax
            stateName = stateCode switch {
                "OH" => "Ohio",
                "KY" => "Kentucky",
                "IN" => "Indiana",
                _ => "I Don't Know"

            };

            //var ac = new AbstractClass(); -- can't create an instance of an abstract class
            

            TestCollection();

            RethrowingExceptions();

            var nbrStr = "123";
            int nbr;
            var ok = int.TryParse(nbrStr, out nbr);     //Converts string to Int (will not work if letters are in the string"

            Console.WriteLine($"Before addition a is {a}");
            Concat(ref a);
            Console.WriteLine($"After addition a is {a}");

            Console.WriteLine($"Before increment i is {i}");
            Add1(ref i);                                            //must add ref when method is called as well
            Console.WriteLine($"After increment i is {i}");

        }

        //ref parameter Example -- treats i as a reference type instead of a value type
        static void Add1(ref int n) {
            n++;
        }
        //ref parameter String Example
        static void Concat(ref string s) {
            s += "XXX";
        }

        
        //Struct example -- mostly used just to put data/values together
        public struct XY {
            public double x;
            public double y;

            public XY(double x, double y) {
                this.x = x;
                this.y = x;
            }
        }

             ////GetType() Example     --the word Type is a class
             //double d = 0;
             //var t = d.GetType();
             //// t contains [System.Double]



    

    }
}
