using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;

namespace Solid.Core.Repositories
{
    public interface IEmployeeRoleRepository
    {
        public Task<IEnumerable<EmployeeRole>> GetAsync();

        public Task<EmployeeRole> GetAsync(int id);

        public Task<EmployeeRole> PostAsync(EmployeeRole value);

        public Task<EmployeeRole> PutAsync(int id, EmployeeRole value);

        public Task<EmployeeRole> DeleteAsync(int id);
    }
}
