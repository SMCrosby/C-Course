using System;

namespace Generics_intro {

    class Program {

        static void Main(string[] args) {

            GenericG<int> gOfInt = new GenericG<int>();
            gOfInt.value = 1;
            gOfInt.Print();

            GenericG<string> gOfStr = new GenericG<string>();
            gOfStr.value = "1";
            gOfStr.Print();



        }
    }
}
