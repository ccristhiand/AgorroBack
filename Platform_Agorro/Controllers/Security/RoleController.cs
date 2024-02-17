using Agorro.Identity.Business;
using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using Agorro.Identity.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Platform_Agorro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public RoleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<ERole>>> Get() {
            try
            {
                return Ok(await new BRole(_configuration).Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("List/actives")]
        public async Task<ActionResult<IEnumerable<ERole>>> GetActives()
        {
            try
            {
                return Ok(await new BRole(_configuration).GetActives());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(string description, int id_user)
        {
            try
            {
                return Ok(await new BRole(_configuration).Add(description,id_user));
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
                return Ok(await new BRole(_configuration).Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(string description , int id_user , int id)
        {
            try
            {
                return Ok(await new BRole(_configuration).Update(description,id_user,id));
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
                return Ok(await new BRole(_configuration).UpdateActive(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
