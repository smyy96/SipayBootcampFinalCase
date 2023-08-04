using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Business.Generic;
using WebApi.Data;
using WebApi.Data.UoW;
using WebApi.Schema.Apartment;

namespace WebApi.Business
{
    public class ApartmentService : GenericService<Apartment, ApartmentRequest, ApartmentResponse>, IApartmentService
    {


        private readonly IMapper mapper;
        public IUnitOfWork unitOfWork;


        public ApartmentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
