using System.Collections.Generic;
using System.Threading.Tasks;
using Test_React_ASPnet.Domain.ViewModels;

namespace Test_React_ASPnet.Service.Interfaces
{
    public interface ITool_UserService
    {
        Task<List<Tool_UserVM>> GetAllTool_User();
        Task<bool> CreateTool_User(Tool_UserVM newToolUserVM);
        Task<bool> DeleteTool_UserById(int id);
    }
}
