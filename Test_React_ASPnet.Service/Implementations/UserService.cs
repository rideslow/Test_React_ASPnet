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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        #region GetAllUser
        public async Task<List<UserVM>> GetAllUser()
        {
            try
            {
                var user = await _userRepo.FindAll();
                var userVM = _mapper.Map<List<UserVM>>(user);
                return userVM;
            }
            catch (Exception ex)
            {
                return new List<UserVM>();
            }
        }
        #endregion

    }
}
