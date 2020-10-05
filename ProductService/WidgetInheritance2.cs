using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService {
    class Widget : Products {

        public string Size { get; set; } = "Medium";
        public string model { get; set; } = "Basic";

        public Widget() : base() { }
    }
}
