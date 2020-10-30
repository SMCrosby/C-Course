using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCSharp {

    public class Mathmatics<T> {

        T[] collection = new T[10];     // Generic class
            int NbrOfItems = 0;

        public void Add(T item) {
            if (NbrOfItems >= 10)
                return;
            collection[NbrOfItems] = item;
            NbrOfItems++;
        }


        //public static T Add(T a, T b) {
        //        return (T)a + b;
        }

    }
}
