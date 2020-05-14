using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWebApi.DataAccess.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        void Save();
    }
}
