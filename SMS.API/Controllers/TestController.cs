using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Shared.Common.DTOs;
using SMS.Application.Shared.DTOs.Test;
using SMS.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestApplication _testApplication;
        public TestController(ITestApplication testApplication)
        {
            _testApplication = testApplication;

        }

        [Route("GetAll")]
        [Produces(typeof(TestOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _testApplication.GetAll();
            return Ok(response);
        }
        [Route("GetById/{id}")]
        [Produces(typeof(TestOutputDto))]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _testApplication.GetById(id);
            return Ok(response);
        }
        [Route("Add")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Add(TestInputDto testInputDto)
        {
            var response = await _testApplication.Add(testInputDto);
            return Ok(response);
        }
        [Route("Update")]
        [Produces(typeof(ResponseOutputDto))]
        [HttpPost]
        public async Task<IActionResult> Update(TestInputDto testInputDto)
        {
            var response = await _testApplication.Update(testInputDto);
            return Ok(response);
        }
    }
}
