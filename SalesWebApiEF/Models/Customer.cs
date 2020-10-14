using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApiEF.Models {
   
    public class Customer {

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Code { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "Decimal(11,2)")]
        public decimal Sales { get; set; }
        public bool Active { get; set; } = true;        //defaults to false
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; } = DateTime.Now;   //uses current time

       
        
        
        public Customer() {             //ctor + tab tab = default constructor

        }



    }
}
