using System;
using System.Collections.Generic;

namespace AddingNumbers {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Student List");
            Console.WriteLine("============");

                var stud1 = new Student() {
                    Id = 1, Name = "Fred", GPA = 2.75, SAT = 1200
                };      // ; is needed because we are initializing data
                var stud2 = new Student() {
                    Id = 2, Name = "Alice", GPA = 3.25, SAT = 1350
                };
                var stud3 = new Student() {
                    Id = 3, Name = "Bob", GPA = 2.25, SAT = 1000
                };

            var studentsList = new List<Student> {
                stud1, stud2, stud3
            };

            var studentsDictionary = new Dictionary<int, Student>();    //(TK,TV)
                foreach(Student s in studentsList) {
                    studentsDictionary.Add(s.Id, s);
                }

            var tempDictionary = new Dictionary<int, Student> {         //Example for initilizing data with key
                [1] = stud1,
                [2] = stud2,
                [3] = stud3,
            };

            //studentsDictionary.Add(stud1.Id, stud1);
            //studentsDictionary.Add(stud2.Id, stud2);
            //studentsDictionary.Add(stud3.Id, stud3);

            var s2 = studentsDictionary[2];             //2 = value of the key  -- Used to look up specific data using dictionary key
            Console.WriteLine($"S2 is {s2.Name}.\n");

            var students = new List<Student>();         //Could also just use {stud1, stud2, stud3}
            students.Add(stud1);
            students.Add(stud2);
            students.Add(stud3);

            foreach (var student in students) {
                student.GPA += 0.1;                     // student.GPA = (student.GPA + .1);
                Console.WriteLine($"{student.Name} GPA is {student.GPA}.");
                    if (student.SAT >= 1100) {
                        student.Honors = true;
                    Console.WriteLine($"{student.Name} : An honors student");
                    }
                    else {
                        student.Honors = false;
                    }
            }



            Console.WriteLine("\nAdding Numbers");
            Console.WriteLine("==============");

            Console.WriteLine("The given numbers are:\n286, 545, 268, 219, 324,\n711, 471, 344, 990, 732,\n542, 758, 372, 447, 497");
            int total = 0;
            int avg  = 0;

            var numbers = new List<int> {
                    286, 545, 268, 219, 324,
                    711, 471, 344, 990, 732,
                    542, 758, 372, 447, 497};

            
            foreach (var i in numbers) {            // i is an independent variable for the foreach loop
                total += i;                         // total = number + total;   -- Also worked

            }
                avg = total / numbers.Count;        //.Count is a property of the List/Collection
                Console.WriteLine($"\nThe total of the numbers is {total}.");
                Console.WriteLine($"\nThe average of the numbers is {avg}.");
        }
    }
}
