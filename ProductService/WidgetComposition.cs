using System;
using System.Collections.Generic;
using System.Text;

namespace cSharp.OOP.Composition {
    class Widget {

        private Products Product { get; set; }

        public int Id {
            get { return Product.Id; }
            set { Product.Id = value; }
            }

        public double Price {
            get { return Product.Price; }
            set { Product.Price = value; }
        }


        public string Size { get; set; } = "Medium";
        public string Model { get; set; } = "Basic";

            public Widget() {
            Product = new Product();
        }

    }
}
