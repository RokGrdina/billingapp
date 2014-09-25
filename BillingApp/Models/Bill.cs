using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApp.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public string Location { get; set; }
        public string DUR { get; set; }
        public int ValidUntill { get; set; }
        public DateTime PaymentDue { get; set; }
        public DateTime ServiceDate { get; set; }
        public int SenderCompanyId { get; set; }
        public int RecieverCompanyId { get; set; }
        public Company SenderCompany { get; set; }
        public Company RecieverCompany { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public decimal OverallPrice { get; set; }
        public string Notes { get; set; }
    }
}