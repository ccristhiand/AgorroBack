using Agorro.Identity.Business;
using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Platform_Agorro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class ModuleController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public ModuleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("Add")]
        public async Task<ActionResult<int>> Add(Rmodule rmodule)
        {
            try
            {
                return Ok(await new BModule(_configuration).Add(rmodule));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                return Ok(await new BModule(_configuration).Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<EModule>>> Get()
        {
            try
            {
                return Ok(await new BModule(_configuration).Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<EModule>>> Search(string description)
        {
            try
            {
                return Ok(await new BModule(_configuration).Search(description));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<int>> Update(Rmodule rmodule)
        {
            try
            {
                return Ok(await new BModule(_configuration).Update(rmodule));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

       

    }
}
