using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Repository.Base
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        void Save();
        List<Entity> GetAll();
        Entity GetById(int id);
        void Insert(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        void DeleteById(int id);
        
        IQueryable<Entity> GetAllAsQueryable();
    }
}
