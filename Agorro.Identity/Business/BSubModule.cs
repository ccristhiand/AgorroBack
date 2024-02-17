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
    public class BSubModule : ISubModule
    {
        readonly IConfiguration _configuration;
        public BSubModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(RSubModule subModule)
        {
            try
            {
                return await new DSubModule(_configuration).Add(subModule);
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
                return await new DSubModule(_configuration).Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ESubModule>> Get()
        {
            try
            {
                return await new DSubModule(_configuration).Get();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ESubModule>> GetActives()
        {
            try
            {
                return await new DSubModule(_configuration).GetActives();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ESubModule>> Search(string descripcion)
        {
            try
            {
                return await new DSubModule(_configuration).Search(descripcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> Update(RSubModule subModule)
        {
            try
            {
                return await new DSubModule(_configuration).Update(subModule);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> UpdateActive(int id)
        {
            try
            {
                return await new DSubModule(_configuration).UpdateActive(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
