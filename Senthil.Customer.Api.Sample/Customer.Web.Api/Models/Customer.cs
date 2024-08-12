using Customer.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer.Web.Api.Models
{
    public class Customer : ICustomer
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string VehicleType { get; set; }

        public string Category { get; set; }

        public string CountryName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public String UpdatedBy { get; set; }
    }
}