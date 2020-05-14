using KokaarWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWebApi.DataAccess.Repository.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        void Update(Customer customer);
    }
}
