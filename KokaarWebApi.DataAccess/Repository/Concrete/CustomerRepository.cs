using KokaarWebApi.DataAccess.Data;
using KokaarWebApi.DataAccess.Repository.Abstract;
using KokaarWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KokaarWebApi.DataAccess.Repository
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
