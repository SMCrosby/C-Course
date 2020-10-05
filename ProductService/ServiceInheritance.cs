using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.OOP.Inheritance {

    class Service : Products {

        public int WidgetId { get; set; }
        public int ServiceYears { get; set; } = 1

        public Service() : base() {}

    }
}
