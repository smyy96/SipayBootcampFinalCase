using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using WebApi.Data.Repository.Base;

namespace WebApi.Data.Repository
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        private readonly SiteManagementDbContext dbContext;
        public ApartmentRepository(SiteManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Apartment> GetAll()
        {
            return dbContext.Set<Apartment>().Include(x=>x.Resident).ToList();
        }

        public Apartment GetById(int id)
        {
            var entity = dbContext.Apartments.SingleOrDefault(x => x.ApartmentNumber == id.ToString());
            return entity;
        }
    }
}
