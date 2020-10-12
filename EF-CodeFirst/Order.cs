using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_CodeFirst {

    public class Order {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }     //virtual instance of customer in class --need to use virtual since theres not an actual column for this



        public Order() { }
    }

}
