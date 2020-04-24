using KokaarWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KokaarWebApi.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = 1,
                    City = "Berry",
                    Name = "Griffin Beak Eldritch",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    Country = "Mali",
                    Email = "armand@gmail.com",
                    PhoneNumber = "+15149969897"
                },
                new Customer()
                {
                    Id = 2,
                    City = "Nancy",
                    Name = "Swashbuckler Rye",
                    DateOfBirth = new DateTime(1668, 5, 21),
                    Country = "Cameroun",
                    Email = "armand@gmail.com",
                    PhoneNumber = "+15149969897"
                },
                new Customer()
                {
                    Id = 3,
                    City = "Eli",
                    Name = "Ivory Bones Sweet",
                    DateOfBirth = new DateTime(1701, 12, 16),
                    Country = "Canada",
                    Email = "armand@gmail.com",
                    PhoneNumber = "+15149969897"
                },
                new Customer()
                {
                    Id = 4,
                    City = "Arnold",
                    Name = "The Unseen Stafford",
                    DateOfBirth = new DateTime(1702, 3, 6),
                    Country = "Canada",
                    Email = "armand@gmail.com",
                    PhoneNumber = "+15149969897"
                },
                new Customer()
                {
                    Id = 5,
                    City = "Seabury",
                    Name = "Toxic Reyson",
                    DateOfBirth = new DateTime(1690, 11, 23),
                    Country = "Maps",
                    Email = "armand@gmail.com",
                    PhoneNumber = "+15149969897"
                },
                new Customer()
                {
                    Id = 6,
                    City = "Rutherford",
                    Name = "Fearless Cloven",
                    DateOfBirth = new DateTime(1723, 4, 5),
                    Country = "France",
                    Email = "armand@gmail.com",
                    PhoneNumber = "+15149969897"
                },
                new Customer()
                {
                    Id = 7,
                    City = "Atherton",
                    Name = "Crow Ridley",
                    DateOfBirth = new DateTime(1721, 10, 11),
                    Country = "Cameroun",
                    Email = "armand@gmail.com",
                    PhoneNumber = "+15149969897"
                }
                );

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
