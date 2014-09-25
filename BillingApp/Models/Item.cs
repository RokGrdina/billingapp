using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace BillingApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int StartingLocationId { get; set; }
        public int EndingLocationId { get; set; }
        public Location StartingLocation { get; set; }
        public Location EndingLocation { get; set; }
        public string Quantity { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxValue { get; set; }
        public decimal OverallPrice { get; set; }

    }
}