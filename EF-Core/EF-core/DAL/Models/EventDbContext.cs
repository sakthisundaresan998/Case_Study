using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    DatabaseHelper.GetConnectionString(),
                    options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionInfo>()
                .HasOne<EventDetails>()
                .WithMany()
                .HasForeignKey(s => s.EventId);

            modelBuilder.Entity<UserInfo>().HasData(new UserInfo
            {
                EmailId = "admin@gmail.com",
                UserName = "Admin",
                Password = "admin123",
                Role = "Admin"
            });

            modelBuilder.Entity<UserInfo>()
                .Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
