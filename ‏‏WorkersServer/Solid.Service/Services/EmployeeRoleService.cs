using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;

namespace Solid.Service.Services
{
    public class EmployeeRoleService: IEmployeeRoleService
    {

        private readonly IEmployeeRoleRepository _EmployeeRoleRepository;
        public EmployeeRoleService(IEmployeeRoleRepository dd)
        {
            _EmployeeRoleRepository = dd;
        }
        public async Task<IEnumerable<EmployeeRole>> GetAllAsync()
        {
            return await _EmployeeRoleRepository.GetAsync();
        }

        public async Task<EmployeeRole> GetEmployeeRoleByIdAsync(int id)
        {
            return await _EmployeeRoleRepository.GetAsync(id);
        }

        public async Task<EmployeeRole> PostEmployeeRoleAsync(EmployeeRole value)
        {
            return await _EmployeeRoleRepository.PostAsync(value);
        }

        public async Task<EmployeeRole> PutEmployeeRoleAsync(int id, EmployeeRole value)
        {
            return await _EmployeeRoleRepository.PutAsync(id, value);
        }
        public async Task<EmployeeRole> DeleteEmployeeRoleAsync(int id)
        {
            return await _EmployeeRoleRepository.DeleteAsync(id);
        }
    }
}
