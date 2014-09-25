using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DDVId { get; set; }
        public string TRR { get; set; }
    }
}