using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWebApi.DataAccess.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        void Save();
    }
}
