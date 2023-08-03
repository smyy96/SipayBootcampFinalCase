using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Base.Response;
using WebApi.Data.Entities;
using WebApi.Data.Repository;
using WebApi.Schema.Apartment;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentRepository repository;
        private readonly IMapper mapper;

        public ApartmentController(IApartmentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet]
        public ApiResponse<List<ApartmentResponse>> GetAll()
        {
            var entityList= repository.GetAll();
            var mapped= mapper.Map<List<Apartment>,List<ApartmentResponse>>(entityList);
            return new ApiResponse<List<ApartmentResponse>>(mapped);
        }

        [HttpGet("DaireNumarası")]
        public ApiResponse<ApartmentResponse> GetById(int DaireNumarası)
        {
            var entityList = repository.GetById(DaireNumarası);
            var mapped = mapper.Map<Apartment, ApartmentResponse>(entityList);
            return new ApiResponse<ApartmentResponse>(mapped);
        }


        [HttpPost]
        public ApiResponse Post([FromBody] ApartmentRequest request)
        {
            var entity = mapper.Map<ApartmentRequest, Apartment>(request);
            repository.Insert(entity);
            return new ApiResponse();

        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] ApartmentRequest request)
        {
            var entity = mapper.Map<ApartmentRequest, Apartment>(request);
            entity.ApartmentID = id;
            repository.Update(entity);
            return new ApiResponse();
        }


        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            repository.DeleteById(id);
            return new ApiResponse();
        }

    }
}
