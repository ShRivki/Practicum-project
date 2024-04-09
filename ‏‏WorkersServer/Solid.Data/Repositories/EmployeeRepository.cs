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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        private readonly IEmployeeRoleRepository _EmployeeRoleRepository;
        public EmployeeRepository(DataContext dd, IEmployeeRoleRepository role)
        {
            _context = dd;
            _EmployeeRoleRepository = role;
        }

        public async Task<IEnumerable<Employee>> GetAsync()
        {
            var list = await _context.Employees.Include(x => x.Roles).ThenInclude(role => role.Role).ToListAsync();
            return list;
        }

        public async Task<Employee> GetAsync(int id)
        {
            // Employee employee = new Employee();
            return await _context.Employees.Include(x => x.Roles).ThenInclude(role => role.Role).FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<Employee> PostAsync(Employee value)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e =>
         e.FirstName == value.FirstName && e.LastName == value.LastName && e.Identity == value.Identity && e.Password == value.Password);

            if (existingEmployee != null)
                return null;

            _context.Employees.Add(value);
            await _context.SaveChangesAsync();
            return await _context.Employees.FindAsync(value.Id);
        }

        public async Task<Employee> PutAsync(int id, Employee value)
        {
            Employee employee;
            employee = await GetAsync(id);
            if (employee != null)
            {
                employee.Active = value.Active;
                employee.FirstName = value.FirstName;
                employee.LastName = value.LastName;
                employee.DateOfBirth = value.DateOfBirth;
                employee.StartDate = value.StartDate;
                employee.Password = value.Password;
                for (int i = 0; i < employee.Roles.Count; i++)
                {
                    await _EmployeeRoleRepository.DeleteAsync(employee.Roles[i].Id);
                }
                employee.Roles = value.Roles;
                employee.Gender = value.Gender;
                employee.Identity = value.Identity;
                await _context.SaveChangesAsync();
            }
            return employee;
        }
        public async Task<Employee> DeleteAsync(int id)
        {
            Employee employee;
            employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Active = false;
                await _context.SaveChangesAsync();
            }
            return employee;
        }
    }
}
