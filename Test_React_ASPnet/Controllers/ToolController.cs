using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_React_ASPnet.Domain.ViewModels;
using Test_React_ASPnet.Service.Interfaces;

namespace Test_React_ASPnet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolService _toolService;

        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }

        #region Get
        [HttpGet("{value}")]
        public async Task<List<ToolVM>> Get(int value = 1)
        {
            var response = await _toolService.GetToolMoreCount(value);
            return response;
        }
        #endregion
    }
}
