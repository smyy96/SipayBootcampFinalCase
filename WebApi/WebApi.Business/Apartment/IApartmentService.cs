using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business.Generic;
using WebApi.Data;
using WebApi.Schema.Apartment;

namespace WebApi.Business
{
    public interface IApartmentService : IGenericService<Apartment, ApartmentRequest, ApartmentResponse>
    {
    }
}
