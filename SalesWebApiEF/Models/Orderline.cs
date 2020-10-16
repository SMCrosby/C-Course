using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApiEF.Models {

    public class Orderline {

        public int Id { get; set; }
        //[Required]
        //[StringLength(30)]
        //public string Product { get; set; }
        //[Column(TypeName = "decimal(11,2)")]
        //public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
        
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }         //Add "int?" would allow ProductId to be null
        public virtual Product Product { get; set; }




        public Orderline() {}
    }
}
