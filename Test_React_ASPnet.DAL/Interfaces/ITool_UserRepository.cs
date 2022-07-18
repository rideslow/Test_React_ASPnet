﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Test_React_ASPnet.Domain.Entity;

namespace Tess_React_ASPnet.DAL.Interfaces
{
    public interface ITool_UserRepository : IRepositoryBase<Tool_User>
    {
        Task<ICollection<Tool_User>> GetTool_UserGroupByToolId();
    }
}