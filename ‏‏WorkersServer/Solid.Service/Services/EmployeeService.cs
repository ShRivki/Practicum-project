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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeService(IEmployeeRepository dd)
        {
            _EmployeeRepository = dd;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {

            var list = await _EmployeeRepository.GetAsync();
            return list.Where(d => d.Active);

        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _EmployeeRepository.GetAsync(id);
        }

        public async Task<Employee> PostEmployeeAsync(Employee value)
        {
            if (value.StartDate < value.DateOfBirth)
            {
                throw new ArgumentException("תאריך תחילת העבודה חייב להיות לאחר תאריך הלידה");
            }
            foreach (var role in value.Roles)
            {
                if (role.StartDate < value.StartDate)
                {
                    throw new ArgumentException("תאריך תחילת התפקיד חייב להיות לאחר תאריך תחילת העבודה");
                }
            }

            return await _EmployeeRepository.PostAsync(value);
        }

        public async Task<Employee> PutEmployeeAsync(int id, Employee value)
        {
            if (value.StartDate < value.DateOfBirth)
            {
                throw new ArgumentException("תאריך תחילת העבודה חייב להיות לאחר תאריך הלידה");
            }
            foreach (var role in value.Roles)
            {
                if (role.StartDate < value.StartDate)
                {
                    throw new ArgumentException("תאריך תחילת התפקיד חייב להיות לאחר תאריך תחילת העבודה");
                }
            }
            return await _EmployeeRepository.PutAsync(id, value);
        }
        public async Task<Employee> DeleteEmployeeAsync(int id)
        {
            return await _EmployeeRepository.DeleteAsync(id);
        }
    }
}
