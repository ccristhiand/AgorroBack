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
    public class BModule : IModule
    {
        readonly IConfiguration _configuration;
        public BModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Rmodule rmodule)
        {
            try
            {
                return await new DModule(_configuration).Add(rmodule);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await new DModule(_configuration).Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<EModule>> Get()
        {
            try
            {
                return await new DModule(_configuration).Get();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<EModule>> Search(string description)
        {
            try
            {
                return await new DModule(_configuration).Search(description);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> Update(Rmodule rmodule)
        {
            try
            {
                return await new DModule(_configuration).Update(rmodule);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
