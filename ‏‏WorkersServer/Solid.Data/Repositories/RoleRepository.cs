using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;

namespace Solid.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext dd)
        {
            _context = dd;
        }

        public async Task<IEnumerable<Role>> GetAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> PostAsync(Role value)
        {

            _context.Roles.Add(value);
            await _context.SaveChangesAsync();
            return await _context.Roles.FindAsync(value.Id);

        }

        public async Task<Role> PutAsync(int id, Role value)
        {

            Role role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                role.Name = value.Name;
                await _context.SaveChangesAsync();
            }
            return role;
        }
        public async Task<Role> DeleteAsync(int id)
        {
            Role role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
            return role;
        }
    }
}
