using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using WebApi.Base.Response;
using WebApi.Data;
using WebApi.Data.UoW;
using WebApi.Schema.Apartment;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ApartmentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ApartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public ApiResponse<List<ApartmentResponse>> GetAll()
        {
            var entityList= unitOfWork.ApartmentRepository.GetAll();
            var mapped= mapper.Map<List<Apartment>,List<ApartmentResponse>>(entityList);
            return new ApiResponse<List<ApartmentResponse>>(mapped);
        }

        [HttpGet("id")]
        public ApiResponse<ApartmentResponse> GetById(int id)
        {
            var entityList = unitOfWork.ApartmentRepository.GetById(id);
            var mapped = mapper.Map<Apartment, ApartmentResponse>(entityList);
            return new ApiResponse<ApartmentResponse>(mapped);
        }

        //[HttpGet("DaireNumarası")]
        //public ApiResponse<ApartmentResponse> GetByReferans(string DaireNumarası)
        //{
        //    var entity = repository.GetByReferans(DaireNumarası);
        //    var mapped = mapper.Map<Apartment, ApartmentResponse>(entity);
        //    return new ApiResponse<ApartmentResponse>(mapped);
        //}



        [HttpPost]
        public ApiResponse Post([FromBody] ApartmentRequest request)
        {
            var entity = mapper.Map<ApartmentRequest, Apartment>(request);
            unitOfWork.ApartmentRepository.Insert(entity);
            return new ApiResponse();

        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] ApartmentRequest request)
        {
            var entity = mapper.Map<ApartmentRequest, Apartment>(request);
            entity.ApartmentID = id;
            unitOfWork.ApartmentRepository.Update(entity);
            return new ApiResponse();
        }


        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            unitOfWork.ApartmentRepository.DeleteById(id);
            return new ApiResponse();
        }

    }
}
