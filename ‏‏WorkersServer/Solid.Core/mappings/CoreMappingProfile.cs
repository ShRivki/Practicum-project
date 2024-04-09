using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Solid.Core.DTOs;
using Solid.Core.Entities;

namespace Solid.Core.mappings
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<EmployeeRoleDto, EmployeeRole>().ReverseMap();

        }
    }
}
