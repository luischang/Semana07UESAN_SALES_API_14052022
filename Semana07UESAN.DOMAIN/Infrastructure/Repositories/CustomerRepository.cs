using Microsoft.EntityFrameworkCore;
using Semana07UESAN.DOMAIN.Core.Entities;
using Semana07UESAN.DOMAIN.Core.Interfaces;
using Semana07UESAN.DOMAIN.Infrastructure.Data;

namespace Semana07UESAN.DOMAIN.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesContext _context;

        public CustomerRepository(SalesContext context)
        {
            _context = context;
        }

        //public IEnumerable<Customer> GetCustomers()
        //{
        //    var data = new SalesContext();
        //    return data.Customer.ToList();
        //}

        public IEnumerable<Customer> GetCustomersSP()
        {
            return  _context.Customer.FromSqlInterpolated($"EXECUTE dbo.SP_GET_CUSTOMERS").ToList();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            //var data = new SalesContext();
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            //Validate if the customer exists
            var customer = await _context.Customer.FindAsync(id); 
            return customer;
            //return await _context.Customer.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Insert(Customer customer)
        {
            //var data = new SalesContext();
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Customer customer)
        {
            _context.Customer.Update(customer);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return false;
            }
            _context.Customer.Remove(customer);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }


    }
}
