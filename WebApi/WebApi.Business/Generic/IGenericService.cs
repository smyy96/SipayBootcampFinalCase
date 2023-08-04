﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Base.Response;

namespace WebApi.Business.Generic
{
    public interface IGenericService <TEntity,TRequest,TResponse>
    {
        ApiResponse<List<TResponse>> GetAll();
        ApiResponse<TResponse> GetById(int id);
        ApiResponse Insert(TRequest request);
        ApiResponse Update(int Id, TRequest request);
        ApiResponse Delete(int Id);

        
    }
}
