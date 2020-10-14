using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
--Inside Package Manager --
install - package microsoft.entityframeworkcore.tools
install-package microsoft.entityframeworkcore.sqlserver

add-migration "Initialization"
remove-migration
update-database
*/



namespace Practice_Notes {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("This is a Formating Trial\n=========================\n1\t2\t3\t4\t5");      //Formatting is the same

            Console.WriteLine("Question asked: ");
            var answer = Console.ReadLine();

            var myName = "Sarah Crosby";
            int yearsOld = 28;
            char letter = 'S';          //char = single character -- uses ''  not ""
            string name = "Sarah";
            bool isActive = true;       //bool = true or false  -- defaults to false 



            

            Console.WriteLine($"My name is {myName}");      //formating = Interpolation

            int[] numbers = { 1, 2, 3, 4, 5, 6 };              //Arrays
            string[] codes = new string[3];
            var odds = numbers.Where(i => i % 2 == 0);


            var nbr = new List<int> {               //way to initialize generic list
                    286, 545, 268, 219, 324,
                    711, 471, 344, 990, 732,
                    542, 758, 372, 447, 497};

            int total = 0;
            foreach (var i in nbr){                 //adding numbers in nbr list
                                                    // i is an independent variable for the foreach loop
                total += i;                         // total = total + number;   -- shorthand

            }



            /*---Math Operators---
            int i = 2;
            int i2 = 2;
            int rem = 0;
            i = (++i);          // Increment (++i) || (i++)
            i = (--i);          // Decrement (--i) || (i--)
            rem = (i%i2);       // Remainder after division


            var a = 5;
            var b = ++a;        //increment then assign to b       order of ++ or -- matters
            var c = a++;        //assign to c then increment

            ---Positive and Negatives---
            var a = -5;
            var b = +a;         // negative 5   (+ returns the value of the variable)
            var c = -a;         // positive 5   (- returns the negation of the variable)
            */

            /*---Syntax Questions--- 

            File f = new File(); 
            DateTime Mar27 = DateTime(2020, 3, 27);

            */


            /*---Attributes used for "Code First" EntityFramework to SQL
            
            [Required]                                      -Not Null
            [StringLength(50)]                              -String(50)     -Max length for string is 50 characters
            public string Description { get; set; }
            
            [Column(TypeName = "decimal(11,2)")]            -Sets the type as decimal in SQL (11,2) (ints,decimals)
            public decimal Total { get; set; }
            
            [Column(TypeName = "datetime")]                 -Sets the type to datetime in SQL
            public DateTime Created { get; set; } = DateTime.Now;   //uses current time as default

            public bool Active { get; set; } = true;        //Defaults to false

            public int CustomerId { get; set; }
            public virtual Customer Customer { get; set; }     //virtual instance of customer in class 
                                                            --need to use virtual since theres not an actual column for this

            */
            /*
             ------Adding unique property to CodeFirst----  Add block in context class
             protected override void OnModelCreating(ModelBuilder builder) {     //Tables without FKey's go first //fluent-api's go here
            
                        //start with variable name
                        builder.Entity<Customer>(e => {
                            e.HasIndex(x => x.Code).IsUnique();
            */


        }
    }
}


