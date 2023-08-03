using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Repository.Base;

namespace WebApi.Data.Repository.Resident
{
    public class ResidentRepository : GenericRepository<Entities.Resident>, IResidentRepository
    {
        public ResidentRepository(SiteManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
