using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Castle.MicroKernel.SubSystems.Conversion;

namespace EF_CodeFirst {


    public class Customer {

        public int Id { get; set; }
        [Required]                        //Name != null
        [StringLength(30)]                //Max characters in Name = 30
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Code { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "decimal(11,2)")]            //tells framework what type to convert to
        public decimal Sales { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        


        public Customer() { }             //default constructor
    }
}
