using SMS.Application.Shared.Common.DTOs;
using SMS.Application.Shared.DTOs.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Shared.Interfaces
{
    public interface ITestApplication
    {
        Task<ResponseOutputDto> GetAll();
        Task<ResponseOutputDto> GetById(int id);
        Task<ResponseOutputDto> Add(TestInputDto testInputDto);
        Task<ResponseOutputDto> Update(TestInputDto testInputDto);
    }
}
