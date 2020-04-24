using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Service.Core;
using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Service.Abstract
{
    public interface ICustomerService
    {        
        Customer Get(int id);
        IEnumerable<Customer> GetAll();
        bool Save(ref StringBuilder validationErrors, Customer customer, string user);
        bool Delete(ref StringBuilder validationErrors, Customer customer);
    }
}