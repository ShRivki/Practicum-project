using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.API.models;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _RoleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService ds, IMapper mapper)
        {
            _RoleService = ds;
            _mapper = mapper;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            var list = await _RoleService.GetAllAsync();
            var list1 = list/*.Select(d => _mapper.Map<ArticleDto>(d))*/;
            return Ok(list1);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await _RoleService.GetRoleByIdAsync(id);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolePostModel value)
        {
            var r = _mapper.Map<Role>(value);
            var res = await _RoleService.PostRoleAsync(r);
             return res != null ? Ok(res) : NotFound("התפקיד כבר קיים");
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RolePostModel value)
        {
             var r = _mapper.Map<Role>(value);
            var res = await _RoleService.PutRoleAsync(id, r);
            return res != null ? Ok(res) : NotFound(res);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _RoleService.DeleteRoleAsync(id);
            return res != null ? Ok(res) : NotFound(res);
        }
    }
}
