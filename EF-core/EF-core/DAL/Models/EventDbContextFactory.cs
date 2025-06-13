using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Models
{
    public class EventDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
    {
        public EventDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventDbContext>();

            var connectionString = "Server=SAKTHI\\SQLEXPRESS;Database=EventDb;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

            return new EventDbContext(optionsBuilder.Options);
        }
    }
}
