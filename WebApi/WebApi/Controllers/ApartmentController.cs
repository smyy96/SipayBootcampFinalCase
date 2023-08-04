using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using WebApi.Base.Response;
using WebApi.Business;
using WebApi.Data;
using WebApi.Data.UoW;
using WebApi.Schema.Apartment;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService service;

        public ApartmentController(IApartmentService service)
        {
            this.service = service;
        }


        [HttpGet]
        public ApiResponse<List<ApartmentResponse>> GetAll()
        {
            var entityList = service.GetAll();
            return entityList;
        }


        [HttpGet("id")]
        public ApiResponse<ApartmentResponse> GetById(int id)
        {
            var entityList = service.GetById(id);
            return entityList;
        }


        [HttpPost]
        public ApiResponse Post([FromBody] ApartmentRequest request)
        {
            
            var response = service.Insert(request);
            return response;

        }


        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] ApartmentRequest request)
        {
           var response=service.Update(id, request);
            return response;
        }


        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var delete = service.Delete(id);
            return delete;
        }



        //[HttpGet("DaireNumarası")]
        //public ApiResponse<ApartmentResponse> GetByReferans(string DaireNumarası)
        //{
        //    var entity = unitOfWork.ApartmentRepository.GetByReferans(DaireNumarası);
        //    var mapped = mapper.Map<Apartment, ApartmentResponse>(entity);
        //    return new ApiResponse<ApartmentResponse>(mapped);
        //}


        //[HttpGet("DaireNumarası")]
        //public ApiResponse<ApartmentResponse> GetByReferans(string ApartmentNumber)
        //{
        //    var entity = unitOfWork.ApartmentRepository.Where(x => x.ApartmentNumber == ApartmentNumber).ToList();
        //    var mapped = mapper.Map<Apartment, ApartmentResponse>(entity);
        //    return new ApiResponse<ApartmentResponse>(mapped);
        //}

    }
}
