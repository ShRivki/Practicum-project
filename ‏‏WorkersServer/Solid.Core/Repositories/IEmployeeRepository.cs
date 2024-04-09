using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Entities;

namespace Solid.Core.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAsync();

        public Task<Employee> GetAsync(int id);

        public Task<Employee> PostAsync(Employee value);

        public Task<Employee> PutAsync(int id, Employee value);

        public Task<Employee> DeleteAsync(int id);
    }
}
