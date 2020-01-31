namespace Product.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public DateTime AddedDate { get; set; }

        public int? CustomerID { get; set; }

        public Customers Customers { get; set; }
    }
}