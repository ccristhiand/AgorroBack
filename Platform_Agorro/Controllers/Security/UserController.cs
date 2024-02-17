using Agorro.Identity.Business;
using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using Microsoft.AspNetCore.Http;
using Agorro.Identity.Entity.Request;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using System.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Agorro.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Platform_Agorro.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IConfiguration _configuration;
        private string _userKey;
        private string _secret;
        private string _email;
        private string _password;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _userKey = configuration.GetValue<string>("ApiSettings:keyUser");
            _secret = configuration.GetValue<string>("ApiSettings:secret");
            _email = configuration.GetValue<string>("ApiSettings:email");
            _password = configuration.GetValue<string>("ApiSettings:password");
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

               return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]RUser ruser)
        {
            try
            {
                return Ok(await new BUser(_configuration,_userKey,_secret,_email,_password).Add(ruser));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string user , string password)
        {
            try
            {
                RLogin rLogin = new RLogin();
                EUser usuario = new EUser();
                usuario = await new BUser(_configuration, _userKey).Login(user, password);

                rLogin = new()
                {
                    token = null,
                    User = usuario
                };
        
                if (usuario.result == "Inicio de sesion Exitoso")
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, usuario.usuario_usuario.ToString()),
                        new Claim(ClaimTypes.Role, usuario.role_description)
                        }),

                        Expires = DateTime.UtcNow.AddHours(10),
                        SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    rLogin = new()
                    {
                        token = tokenHandler.WriteToken(token),
                        User = usuario
                    };
                }
                
                return Ok(rLogin);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
