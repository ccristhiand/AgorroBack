using Agorro.Identity.Business;
using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Platform_Agorro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubModuleController : Controller
    {
        readonly IConfiguration _configuration;
        public SubModuleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<ESubModule>>> Get()
        {
            try
            {
                return Ok(await new BSubModule(_configuration).Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("List/actives")]
        public async Task<ActionResult<IEnumerable<ESubModule>>> GetActives()
        {
            try
            {
                return Ok(await new BSubModule(_configuration).GetActives());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(RSubModule subModule)
        {
            try
            {
                return Ok(await new BSubModule(_configuration).Add(subModule));
            }
            catch ( Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await new BSubModule(_configuration).Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(RSubModule subModule)
        {
            try
            {
                return Ok(await new BSubModule(_configuration).Update(subModule));
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
                return Ok(await new BRole(_configuration).Search(description));
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
                return Ok(await new BSubModule(_configuration).UpdateActive(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
