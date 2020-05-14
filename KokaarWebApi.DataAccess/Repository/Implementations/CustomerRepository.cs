using KokaarWebApi.DataAccess.Data;
using KokaarWebApi.DataAccess.Repository.Contracts;
using KokaarWebApi.Domain.Entities;

namespace KokaarWebApi.DataAccess.Repository.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Customer customer)
        {
            _db.Update(customer);
        }
    }
}
