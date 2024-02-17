using Agorro.Identity.Data;
using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using Agorro.Identity.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Business
{
    public class BMenu : IMenu
    {
        readonly IConfiguration _configuration;
        public BMenu(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<EMenu>> Get(int idRole)
        {
            try
            {
                return await new DMenu(_configuration).Get(idRole);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
