using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;

namespace Solid.Core.DTOs
{
    public class EmployeeRoleDto
    {
        public RoleDto Role { get; set; }
        public bool IsManagement { get; set; }
        public DateTime StartDate { get; set; }
    }
}
