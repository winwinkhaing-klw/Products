﻿namespace Product.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "Required CompanyName")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Required ContactName")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Required ContactTitle")]
        public string ContactTitle { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Required City")]
        public string City { get; set; }

        public string Region { get; set; }

        [Required(ErrorMessage = "Required PostalCode")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Required Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required Phone")]
        public string Phone { get; set; }

        public string Fax { get; set; }

        public Products Products { get; set; }
    }
}