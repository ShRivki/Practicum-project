using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public enum Gender { male=1, female =2 }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Identity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set;}
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public List<EmployeeRole> Roles { get; set; }
    }
}
