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
    public class BRolePermits : IRolePermits
    {
        readonly IConfiguration _configuration;
        public BRolePermits(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(RRolePermits permits)
        {
            try
            {
                return await new DRolePermits(_configuration).Add(permits);
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
                return await new DRolePermits(_configuration).Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ERolePermits>> Get()
        {
            try
            {
                return await new DRolePermits(_configuration).Get();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ERolePermits>> GetActives()
        {
            try
            {
                return await new DRolePermits(_configuration).GetActives();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ERolePermits>> Search(string descripcion)
        {
            try
            {
                return await new DRolePermits(_configuration).Search(descripcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> Update(RRolePermits permits)
        {
            try
            {
                return await new DRolePermits(_configuration).Update(permits);
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
                return await new DRolePermits(_configuration).UpdateActive(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
