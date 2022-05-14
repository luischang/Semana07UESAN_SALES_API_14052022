using Semana07UESAN.DOMAIN.Core.Entities;

namespace Semana07UESAN.DOMAIN.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> Delete(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task Insert(Customer customer);
        Task<bool> Update(Customer customer);
    }
}