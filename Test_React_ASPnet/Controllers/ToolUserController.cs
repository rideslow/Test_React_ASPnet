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
    public class ToolUserController : ControllerBase
    {
        private readonly ITool_UserService _tool_UserService;

        public ToolUserController(ITool_UserService tool_UserService)
        {
            _tool_UserService = tool_UserService;
        }

        #region Get
        [HttpGet]
        public async Task<List<Tool_UserVM>> Get()
        {
            var response = await _tool_UserService.GetAllTool_User();
            return response;
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task Post([FromBody] Tool_UserVM newToolUserVM)
        {
            await _tool_UserService.CreateTool_User(newToolUserVM);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tool_UserService.DeleteTool_UserById(id);
            return NoContent();
        }
        #endregion

    }
}
