using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_React_ASPnet.Domain.Entity;
using Test_React_ASPnet.Domain.ViewModels;

namespace Test_React_ASPnet.Domain.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<Tool, ToolVM>().ReverseMap();
            CreateMap<Tool_User, Tool_UserVM>().ReverseMap();
        }
    }
}
