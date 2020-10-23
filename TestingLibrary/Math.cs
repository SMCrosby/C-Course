using System;

namespace TestingLibrary {
    
    public class Math {

        public static int Add(int a, int b) {
            return a + b;
        }

        public static int Subtract(int a, int b) {
            return a - b;
        }

        public static int Multiply(int a, int b) {
            return a * b;
        }

        public static int Divide (int a, int b) {
            return a / b;
        }

        public static int Squared (int a) {
            return a * a;
        }

        public static int Cubed (int a) {
            return a * a * a;
        }

        public static int Modulo(int a, int b) {
            return a - (a / b * b);
        }

        public static int Equation1(int a) {
            if ((a >= -7) && (a <= 27))
                return (2 * (a * a)) + (3 * a) + 7;
            else
                return 0;
        }


    }
}
