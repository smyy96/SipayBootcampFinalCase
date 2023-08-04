using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace WebApi.Data.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly SiteManagementDbContext dbContext;

        public GenericRepository(SiteManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
            Save();
        }

        public void DeleteById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            Delete(entity);
        }

        public List<Entity> GetAll()
        {
            return dbContext.Set<Entity>().ToList();
        }

        public IQueryable<Entity> GetAllAsQueryable()
        {
            return dbContext.Set<Entity>().AsQueryable();
        }

        public Entity GetById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            return entity;
        }

        public void Insert(Entity entity)
        {
            dbContext.Set<Entity>().Add(entity);
            Save();
        }

        public void Update(Entity entity)
        {
            dbContext.Set<Entity>().Update(entity);
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        //public abstract Entity GetByReferans(string value)
        //{
        //    var entity = dbContext.Set<Entity>().Find(id);
        //    return entity;
        //}
    }
}
