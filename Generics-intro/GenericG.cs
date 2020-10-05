using System;
using System.Collections.Generic;
using System.Text;

namespace Generics_intro {
    class GenericG<T> {                         // <T> -- T stands for type    -- treat it like a variable to use as an instance
                                                // <T> Type   --   <TK> Type of Key    --  <TV>  Type of Value
                                                // Make sure is using System.Collection.Generic up top if not auto generated
        public T value;

        public void Print() {
            Console.WriteLine(value);
        }

    }
}
