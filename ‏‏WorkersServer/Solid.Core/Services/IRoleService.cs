using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;

namespace Solid.Core.Services
{
    public interface IRoleService
    {
        public Task<IEnumerable<Role>> GetAllAsync();


        public Task<Role> GetRoleByIdAsync(int id);


        public Task<Role> PostRoleAsync(Role value);


        public Task<Role> PutRoleAsync(int id, Role value);


        public Task<Role> DeleteRoleAsync(int id);
    }
}
