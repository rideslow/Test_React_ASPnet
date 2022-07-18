using System.Collections.Generic;
using System.Threading.Tasks;
using Test_React_ASPnet.Domain.ViewModels;

namespace Test_React_ASPnet.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<UserVM>> GetAllUser();
    }
}
