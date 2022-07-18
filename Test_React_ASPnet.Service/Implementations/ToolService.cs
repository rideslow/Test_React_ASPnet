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
    public class ToolService : IToolService
    {
        private readonly IToolRepository _toolRepo;
        private readonly ITool_UserRepository _tool_UserRepo;
        private readonly IMapper _mapper;

        public ToolService(IToolRepository toolRepo,
            ITool_UserRepository tool_UserRepo,
            IMapper mapper)
        {
            _toolRepo = toolRepo;
            _tool_UserRepo = tool_UserRepo;
            _mapper = mapper;
        }

        #region GetToolMoreCount
        public async Task<List<ToolVM>> GetToolMoreCount(int count)
        {
            try
            {

                var toolUser = await _tool_UserRepo.GetTool_UserGroupByToolId();

                var tool = await _toolRepo.FindAll();
                List<Tool> newList = new List<Tool>(tool);

                foreach (var item in tool)
                {
                    foreach (var item2 in toolUser)
                    {
                        if((item.Id == item2.Tool_id && (item.Count - item2.CountTools) < count) 
                            )
                        {
                            newList.Remove(item);
                        }
                    }
                }

                var toolVM = _mapper.Map<List<ToolVM>>(newList);

                return toolVM;
            }
            catch (Exception ex)
            {
                return new List<ToolVM>();
            }
        }
        #endregion

    }
}
