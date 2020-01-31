using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Product.Models;

namespace Product.ViewModels
{
    public class ProductViewModel
    {
      public string CompanyName { get; set; }

      public int Id { get; set; }

      public string Name { get; set; }

      public int Price { get; set; }

      public DateTime AddedDate { get; set; }

      public Products Products { get; set; }

      public Customers Customers { get; set; }
    }
}