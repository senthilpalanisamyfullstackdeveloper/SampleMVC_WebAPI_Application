namespace Customer.WebApp.Repository
{
    using global::Customer.WebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;

    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly PWCustomerEntities db;

        public CustomerRepository()
        {
            this.db = new PWCustomerEntities();
        }

        public IEnumerable<ICustomer> GetCustomers()
        {
            return this.db.Customers;
        }

        public ICustomer GetCustomer(int id)
        {
            return this.db.Customers.Find(id);
        }

        public void CreateCustomer(ICustomer customer)
        {
            var newcustomer = new Customer()
            {
                CustomerID = customer.CustomerID,
                CustomerName = customer.CustomerName,
                Address = customer.Address,
                VehicleType = customer.VehicleType,
                Category = customer.Category,
                CountryName = customer.CountryName,
                CreatedOn = customer.CreatedOn,
                CreatedBy = customer.CreatedBy
            };

            try
            {
                this.db.Customers.Add(newcustomer);
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        public void UpdateCustomer(int id, ICustomer customer)
        {
            var existingData = this.db.Customers.SingleOrDefault(x => x.CustomerID == id);
            existingData.CustomerName = customer.CustomerName;
            existingData.Address = customer.Address;
            existingData.VehicleType = customer.VehicleType;
            existingData.Category = customer.Category;
            existingData.CountryName = customer.CountryName;
            existingData.UpdatedOn = customer.UpdatedOn;
            existingData.UpdatedBy = customer.UpdatedBy;
            try
            {
                this.db.SaveChanges();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        public void DeleteCustomer(int id)
        {
            var existingData = this.db.Customers.Find(id);
            this.db.Customers.Remove(existingData);
            this.db.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
        }
    }
}
