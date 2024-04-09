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
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _RoleRepository;
        public RoleService(IRoleRepository dd)
        {
            _RoleRepository = dd;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _RoleRepository.GetAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _RoleRepository.GetAsync(id);
        }

        public async Task<Role> PostRoleAsync(Role value)
        {
          List<Role> a= (List<Role>)await _RoleRepository.GetAsync();
            var b=a.Find(x=>x.Name==value.Name);
            if(b==null)
                 return await _RoleRepository.PostAsync(value);
            else
                return null;

        }

        public async Task<Role> PutRoleAsync(int id, Role value)
        {
            return await _RoleRepository.PutAsync(id, value);
        }
        public async Task<Role> DeleteRoleAsync(int id)
        {
            return await _RoleRepository.DeleteAsync(id);
        }
    }
}
