using Solid.Core.Entities;

namespace Solid.API.models
{
    public class EmployeePostModel
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password {  get; set; }
        public string Identity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDate { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public List<EmployeeRolePostModel> Roles { get; set; }
    }
}
