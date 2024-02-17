using Agorro.Identity.Business;
using Agorro.Identity.Entity.Request;
using Agorro.Identity.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Platform_Agorro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolePermitsController : Controller
    {
        readonly IConfiguration _configuration;
        public RolePermitsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<ERolePermits>>> Get()
        {
            try
            {
                return Ok(await new BRolePermits(_configuration).Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("List/actives")]
        public async Task<ActionResult<IEnumerable<ERolePermits>>> GetActives()
        {
            try
            {
                return Ok(await new BRolePermits(_configuration).GetActives());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(RRolePermits permits)
        {
            try
            {
                return Ok(await new BRolePermits(_configuration).Add(permits));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await new BRolePermits(_configuration).Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(RRolePermits permits)
        {
            try
            {
                return Ok(await new BRolePermits(_configuration).Update(permits));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("Search")]
        public async Task<ActionResult> Search(string description)
        {
            try
            {
                return Ok(await new BRolePermits(_configuration).Search(description));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPatch("UpdateActive")]
        public async Task<ActionResult<int>> UpdateActive(int id)
        {
            try
            {
                return Ok(await new BRolePermits(_configuration).UpdateActive(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
