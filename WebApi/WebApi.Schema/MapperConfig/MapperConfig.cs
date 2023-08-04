using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Schema;
using WebApi.Schema.Apartment;
using WebApi.Schema.Resident;

namespace WebApi.Schema
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        
        {
            CreateMap<ResidentRequest, Data.Entities.Resident > ();
            CreateMap<Data.Entities.Resident, ResidentResponse>();

            CreateMap<ApartmentRequest, Data.Apartment>();
            CreateMap<Data.Apartment, ApartmentResponse >();

        }
    }
}
