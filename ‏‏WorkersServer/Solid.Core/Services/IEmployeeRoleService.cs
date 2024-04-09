using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;

namespace Solid.Core.Services
{
    public interface IEmployeeRoleService
    {
        public Task<IEnumerable<EmployeeRole>> GetAllAsync();


        public Task<EmployeeRole> GetEmployeeRoleByIdAsync(int id);


        public Task<EmployeeRole> PostEmployeeRoleAsync(EmployeeRole value);


        public Task<EmployeeRole> PutEmployeeRoleAsync(int id, EmployeeRole value);


        public Task<EmployeeRole> DeleteEmployeeRoleAsync(int id); 
    }
}
