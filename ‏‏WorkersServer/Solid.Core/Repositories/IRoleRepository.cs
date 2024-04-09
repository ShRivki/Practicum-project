using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;

namespace Solid.Core.Repositories
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetAsync();

        public Task<Role> GetAsync(int id);

        public Task<Role> PostAsync(Role value);

        public Task<Role> PutAsync(int id, Role value);

        public Task<Role> DeleteAsync(int id);
    }
}
