using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.models;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleService _EmployeeRoleService;
        private readonly IMapper _mapper;
        public EmployeeRoleController(IEmployeeRoleService ds, IMapper mapper)
        {
            _EmployeeRoleService = ds;
            _mapper = mapper;
        }
        // GET: api/<EmployeeRoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRole>>> Get()
        {
            return Ok(await _EmployeeRoleService.GetAllAsync());
        }

        // GET api/<EmployeeRoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _EmployeeRoleService.GetEmployeeRoleByIdAsync(id);
            // var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<EmployeeRoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeRole value)
        {
            var EmployeeRole = _mapper.Map<EmployeeRole>(value);
            var res = await _EmployeeRoleService.PostEmployeeRoleAsync(value);
            //var resDto = _mapper.Map<ArticleDto>(res);
            return res != null ? Ok(value) : NotFound(value);
        }

        // PUT api/<EmployeeRoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeRole value)
        {
            var e = _mapper.Map<EmployeeRole>(value);
            var res = await _EmployeeRoleService.PutEmployeeRoleAsync(id, e);
            return res != null ? Ok(res) : NotFound(res);
        }

        // DELETE api/<EmployeeRoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _EmployeeRoleService.DeleteEmployeeRoleAsync(id);
            return res != null ? Ok(res) : NotFound(res);
        }
    }
}
