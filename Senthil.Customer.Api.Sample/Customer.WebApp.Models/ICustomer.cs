namespace Customer.WebApp.Models
{
    using System;

    public interface ICustomer
    {
        int CustomerID { get; set; }

        string CustomerName { get; set; }

        string Address { get; set; }

        string VehicleType { get; set; }

        string Category { get; set; }

        string CountryName { get; set; }

        DateTime? CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedOn { get; set; }

        String UpdatedBy { get; set; }
    }
}
