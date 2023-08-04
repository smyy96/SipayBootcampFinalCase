using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Base.Response;
using WebApi.Data.UoW;

namespace WebApi.Business.Generic
{
    public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> where TEntity : class
    {
        private readonly IMapper mapper;
        public IUnitOfWork unitOfWork;

        public GenericService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public virtual ApiResponse Delete(int Id)
        {
            try
            {
                var entity = unitOfWork.Repository<TEntity>().GetById(Id);
                if (entity == null)
                    return new ApiResponse("Not Found!");
                unitOfWork.Repository<TEntity>().DeleteById(Id);
                return new ApiResponse();
            }
            catch (Exception e)
            {
                Log.Error(e, "GenericService.Delete");
               return new ApiResponse(e.Message);
            }
        }

        public virtual ApiResponse<List<TResponse>> GetAll()
        {
            try
            {
                var entity = unitOfWork.Repository<TEntity>().GetAll();
                var map=mapper.Map<List<TEntity>,List<TResponse>>(entity);
                return new ApiResponse<List<TResponse>>(map);
            }
            catch (Exception e)
            {
                Log.Error(e, "GenericService.GetAll");
                return new ApiResponse<List<TResponse>>(e.Message);
            }
        }

        public virtual ApiResponse<TResponse> GetById(int id)
        {
            try
            {
                var entity = unitOfWork.Repository<TEntity>().GetById(id);
                if (entity == null)
                    return new ApiResponse<TResponse>("Not Found!");
                var map = mapper.Map<TEntity, TResponse>(entity);
                return new ApiResponse<TResponse>(map);
            }
            catch (Exception e)
            {
                Log.Error(e, "GenericService.GetById");
                return new ApiResponse<TResponse>(e.Message);
            }
        }

        public virtual ApiResponse Insert(TRequest request)
        {
            try
            {
                var entity = mapper.Map<TRequest, TEntity>(request);
                unitOfWork.Repository<TEntity>().Insert(entity);
                unitOfWork.Complete();

                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GenericService.Insert");
                return new ApiResponse(ex.Message);
            }
        }

        public virtual ApiResponse Update(int Id, TRequest request)
        {
            try
            {
                var val = unitOfWork.Repository<TEntity>().GetById(Id);
                if (val == null) return new ApiResponse();
                var entity = mapper.Map<TRequest, TEntity>(request);
                unitOfWork.Repository<TEntity>().Update(entity);
                unitOfWork.Complete();
                return new ApiResponse();
            }
            catch (Exception e)
            {
                Log.Error(e, "GenericService.Update");
                return new ApiResponse(e.Message); 
            }
        }
    }
}
