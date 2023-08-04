using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using WebApi.Data.Repository;

namespace WebApi.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiteManagementDbContext dbContext;

        public UnitOfWork(SiteManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
            ApartmentRepository = new GenericRepository<Apartment>(dbContext);
        }


        public void Complete()
        {
           dbContext.SaveChanges();
        }

        public void CompleteWithTransaction()
        {
            using (var dbTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    //  Log.Error(ex, "CompleteWithTransaction");
                }
            }
        }

        public IGenericRepository<Entity> Repository<Entity>() where Entity : class
        {
            return new GenericRepository<Entity>(dbContext);
        }

        public IGenericRepository<Apartment> ApartmentRepository{get; private set;}
        public IGenericRepository<Resident> ResidentRepository { get; private set;}

        
    }
}
