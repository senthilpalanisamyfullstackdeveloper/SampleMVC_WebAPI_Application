namespace Customer.WebApp.Models
{
    using System.Collections.Generic;

    public interface ICustomerRepository
    {
        IEnumerable<ICustomer> GetCustomers();

        ICustomer GetCustomer(int id);

        void CreateCustomer(ICustomer customer);

        void UpdateCustomer(int id, ICustomer customer);

        void DeleteCustomer(int id);
    }
}
