using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using WebApi.Data.Repository;

namespace WebApi.Data
{
    public class SiteManagementDbContext : DbContext
    {
        public SiteManagementDbContext(DbContextOptions<SiteManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Dues> Dueses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<ManagerMessage> managerMessages { get; set; }
        public DbSet<ResidentMessage> residentMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentConfiguration());
            modelBuilder.ApplyConfiguration(new DuesConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerMessageConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentMessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
