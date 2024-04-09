using System.ComponentModel.Design;
using AutoMapper;
using Solid.API.models;
using Solid.Core.Entities;

namespace Solid.API.mappings
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>().ReverseMap();
            CreateMap<RolePostModel, Role>().ReverseMap();
            CreateMap<EmployeeRolePostModel, EmployeeRole>().ReverseMap();
        }
    }
}
