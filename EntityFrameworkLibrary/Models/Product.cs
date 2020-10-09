using System;
using System.Collections.Generic;

namespace EntityFrameworkProject
{
    public partial class Product
    {
        public Product()
        {
            LineItem = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public int VendorId { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string PhotoPath { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<LineItem> LineItem { get; set; }
    }
}
