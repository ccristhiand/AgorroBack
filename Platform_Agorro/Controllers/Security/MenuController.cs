using Agorro.Identity.Business;
using Agorro.Identity.Data;
using Agorro.Identity.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Platform_Agorro.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class MenuController : Controller
    {
        readonly IConfiguration _configuration;
        public MenuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("list")]
        public async Task<ActionResult> Get([FromBody]int idRole)
        {
            try
            {
                return Ok(await new BMenu(_configuration).Get(idRole));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
