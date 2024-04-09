using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;

namespace Solid.Data.Repositories
{
    public class EmployeeRoleRepository: IEmployeeRoleRepository
    {
        private readonly DataContext _context;
        public EmployeeRoleRepository(DataContext dd)
        {
            _context = dd;
        }

        public async Task<IEnumerable<EmployeeRole>> GetAsync()
        {
            var list = await _context.EmployeeRole.Include(x => x.Role).ToListAsync();
            return list;
        }

        public async Task<EmployeeRole> GetAsync(int id)
        {
            var employeeRole = await _context.EmployeeRole.Include(x => x.Employee).Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
            return employeeRole;

        }

        public async Task<EmployeeRole> PostAsync(EmployeeRole value)
        {
            _context.EmployeeRole.Add(value);
            await _context.SaveChangesAsync();
            return await _context.EmployeeRole.FindAsync(value);
        }

        public async Task<EmployeeRole> PutAsync(int id, EmployeeRole value)
        {
            EmployeeRole employee;
            employee = await _context.EmployeeRole.FindAsync(id);
            if (employee != null)
            {
                employee.StartDate=value.StartDate;
                employee.Role=value.Role;
                employee.IsManagement=value.IsManagement;
                await _context.SaveChangesAsync();
            }
            return employee;
        }
        public async Task<EmployeeRole> DeleteAsync(int id)
        {
            EmployeeRole employee;
            employee = await _context.EmployeeRole.FindAsync(id);
            if (employee != null)
            {
                _context.EmployeeRole.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }
    }
}
