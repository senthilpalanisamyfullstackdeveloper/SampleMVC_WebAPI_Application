namespace Customer.Web.Api.Controllers
{
    using Customer.WebApp.Repository;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    public class CustomerController : ApiController
    {
        CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        // GET: api/Customer
        public IEnumerable<Models.Customer> Get()
        {
            var data = _customerRepository.GetCustomers().ToList().Select(x => new Models.Customer
            {
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerName,
                Address = x.Address,
                Category = x.Category,
                VehicleType = x.VehicleType,
                CountryName = x.CountryName,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            });
            return data.ToList();
        }

        // GET: api/Customer/5
        public Models.Customer Get(int id)
        {
            var data = _customerRepository.GetCustomer(id);
            
            var customer = new Models.Customer
            {
                CustomerID = data.CustomerID,
                CustomerName = data.CustomerName,
                Address = data.Address,
                Category = data.Category,
                VehicleType = data.VehicleType,
                CountryName = data.CountryName,
                CreatedBy = data.CreatedBy,
                CreatedOn = data.CreatedOn,
                UpdatedBy = data.UpdatedBy,
                UpdatedOn = data.UpdatedOn
            };
            return customer;
        }

        // POST: api/Customer
        public void Post([FromBody]Models.Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]Models.Customer customer)
        {
            _customerRepository.UpdateCustomer(id, customer);
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }
    }
}
