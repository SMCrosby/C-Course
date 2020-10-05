using System;

namespace ExceptionExample {
    class Program {
        static void Main(string[] args) {
            Method1();
        }

        static void Method1() {
            try { 
            Method2();
                } catch (Exception ex) {
                Console.WriteLine("The exception is caught here...");            }
        }

        static void Method2() {
           
                Method3();
            
        }

        static void Method3() {
            var n = 1;
            var d = 0;
            var x = n / d;
        }




    } // end of class
}
