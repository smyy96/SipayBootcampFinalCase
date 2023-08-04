using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using WebApi.Data.Repository;

namespace WebApi.Data.UoW
{
    public interface IUnitOfWork
    {
        void Complete();
        void CompleteWithTransaction();
         
        IGenericRepository<Entity> Repository <Entity>() where Entity : class;
        IGenericRepository<Apartment> ApartmentRepository { get; }
        IGenericRepository<Resident> ResidentRepository { get; }
    }
}
