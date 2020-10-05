using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.OOP.Composition {
    class ServiceComposition {

        private Products Product { get; set; }

        public int Id {
            get { return Product.Id; }
            set { Product.Id = value; }
        }

        public string Description {
            get { return Product.Description; }
            set { Product.Description = ; }
        }



        public double Price {
            get { return Product.Price; }
            set { Product.Price = value; }
        }


        public int WidgetID { get; set; }
        public int ServiceYears { get; set; } = 1;

        public Service() {
            Product = new Products();

        }

    }
}
