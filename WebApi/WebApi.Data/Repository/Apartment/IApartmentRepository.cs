using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using WebApi.Data.Repository.Base;

namespace WebApi.Data.Repository
{
    public interface IApartmentRepository : IGenericRepository<Apartment>
    {
    }
}
