using KokaarWebApi.DataAccess.Data;
using KokaarWebApi.DataAccess.Repository.Contracts;

namespace KokaarWebApi.DataAccess.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CustomerRepository = new CustomerRepository(_db);           
        }

        public ICustomerRepository CustomerRepository { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
