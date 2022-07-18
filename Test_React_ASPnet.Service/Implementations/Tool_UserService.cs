using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tess_React_ASPnet.DAL.Interfaces;
using Test_React_ASPnet.Domain.Entity;
using Test_React_ASPnet.Domain.ViewModels;
using Test_React_ASPnet.Service.Interfaces;

namespace Test_React_ASPnet.Service.Implementations
{
    public class Tool_UserService : ITool_UserService
    {
        private readonly ITool_UserRepository _tool_UserRepo;
        private readonly IMapper _mapper;

        public Tool_UserService(ITool_UserRepository tool_UserRepo,
            IMapper mapper)
        {
            _tool_UserRepo = tool_UserRepo;
            _mapper = mapper;
        }

        #region GetAllTool_User
        public async Task<List<Tool_UserVM>> GetAllTool_User()
        {
            try
            {
                var toolUser = await _tool_UserRepo.FindAll();
                var toolUserVM = _mapper.Map<List<Tool_UserVM>>(toolUser);
                return toolUserVM;
            }
            catch (Exception ex)
            {
                return new List<Tool_UserVM>();
            }
        }
        #endregion

        #region CreateTool_User
        public async Task<bool> CreateTool_User(Tool_UserVM newToolUserVM)
        {
            try
            {
                var newToolUser = _mapper.Map<Tool_User>(newToolUserVM);
                return await _tool_UserRepo.Create(newToolUser);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region DeleteTool_UserById
        public async Task<bool> DeleteTool_UserById(int id)
        {
            try
            {
                var toolUser = await _tool_UserRepo.FindById(id);
                if (toolUser != null)
                    return await _tool_UserRepo.Delete(toolUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

    }
}
