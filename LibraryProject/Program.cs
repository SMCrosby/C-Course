using System;
using UtilityLibrary;
using Education.DB;

namespace LibraryProject {
    
    class Program {
        
        static void Main(string[] args) {

            Console.WriteLine("This is the Library Demo Project");
            Console.WriteLine("================================");

            var about = Utility.About();
            Console.WriteLine($"About is {about}.");

            var stud1 = new Student() {
                Id = 1, Name = "Fred", SAT = 1000, GPA = 2.5
            };




        }
    }
}
