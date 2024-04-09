using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;

namespace Solid.Core.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllAsync();


        public Task<Employee> GetEmployeeByIdAsync(int id);


        public Task<Employee> PostEmployeeAsync(Employee value);


        public Task<Employee> PutEmployeeAsync(int id, Employee value);


        public Task<Employee> DeleteEmployeeAsync(int id);
    }
}
