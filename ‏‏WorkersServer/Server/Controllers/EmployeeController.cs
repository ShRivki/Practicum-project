using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.models;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        private readonly IEmployeeService _EmployeeService;
        private readonly IRoleService _RoleService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IRoleService roleService, IMapper mapper)
        {
            _EmployeeService = employeeService;
            _RoleService = roleService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            var list = await _EmployeeService.GetAllAsync();
            var list1 = list.Select(d => _mapper.Map<EmployeeDto>(d));
            return Ok(list1);
        }
        [HttpGet("name={name}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get(string name)
        {
            var list = await _EmployeeService.GetAllAsync();
            if (name == null)
            {
                return Ok(list);
            }
            var list1 = list.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name) || x.Identity.Contains(name) || x.DateOfBirth.ToString("d.M.yyyy").Contains(name) || x.StartDate.ToString("d.M.yyyy").Contains(name) || x.Roles.Any(x => x.Role.Name.Contains(name) || x.StartDate.ToString("d.M.yyyy").Contains(name)));
            var list2 = list1.Select(d => _mapper.Map<EmployeeDto>(d));
            return Ok(list2);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _EmployeeService.GetEmployeeByIdAsync(id);
            return res != null ? Ok(res) : NotFound();

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Get(LogIn user)
        {
            var list = await _EmployeeService.GetAllAsync();
            Employee foundEmployee = null;

            foreach (var employee in list)
            {
                if (employee.Password == user.Password && (user.Name.Equals(employee.FirstName) || user.Name.Equals(employee.LastName)))
                {
                    foundEmployee = employee;
                    if (!foundEmployee.Active)
                        throw new ArgumentException("המשתמש לא פעיל");
                    break;
                }
            }
            return foundEmployee != null ? Ok(foundEmployee) : NotFound("שם משתמש או סיסמא שגוי");
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel value)
        {

            var roleNames = new Dictionary<string, bool>();
            var list = new List<EmployeeRole>();
            foreach (var role in value.Roles)
            {
                var r = await _RoleService.GetRoleByIdAsync(role.RoleId);
                if (r is null)
                {
                    return NotFound();
                }
                if (roleNames.ContainsKey(r.Name))
                {
                    continue;
                }
                roleNames[r.Name] = true;
                EmployeeRole e = new EmployeeRole();
                e.IsManagement = role.IsManagement;
                e.Role = r;
                e.RoleId = role.RoleId;
                e.StartDate = role.StartDate;
                list.Add(e);
            }
            var employee = _mapper.Map<Employee>(value);
            employee.Roles = list;
            var res = await _EmployeeService.PostEmployeeAsync(employee);
            var resDto = _mapper.Map<EmployeeDto>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeePostModel value)

        {
            var e1 = _mapper.Map<Employee>(value);

            var list = new List<EmployeeRole>();
            foreach (var role in value.Roles)
            {
                var r = await _RoleService.GetRoleByIdAsync(role.RoleId);
                if (r is null)
                {
                    return NotFound();
                }
                EmployeeRole e = new EmployeeRole();
                e.IsManagement = role.IsManagement;
                e.Role = r;
                e.RoleId = role.RoleId;
                e.StartDate = role.StartDate;
                list.Add(e);
            }
            e1.Roles = list;
            var res = await _EmployeeService.PutEmployeeAsync(id, e1);
            var resDto = _mapper.Map<EmployeeDto>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _EmployeeService.DeleteEmployeeAsync(id);
            var resDto = _mapper.Map<EmployeeDto>(res);
            return res != null ? Ok(resDto) : NotFound(resDto);
        }
    }
}




