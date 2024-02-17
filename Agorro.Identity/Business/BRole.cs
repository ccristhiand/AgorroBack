using Agorro.Identity.Data;
using Agorro.Identity.Entity;
using Agorro.Identity.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Business
{
    public class BRole : IRole
    {
        readonly IConfiguration _configuration;
        public BRole(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> Add(string description, int id_user)
        {
            try
            {
                return await new DRole(_configuration).Add(description, id_user);
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
                return await new DRole(_configuration).Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ERole>> Get()
        {
            try
            {
                return await new DRole(_configuration).Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<ERole>> GetActives()
        {
            try
            {
                return await new DRole(_configuration).GetActives();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ERole>> Search(string description)
        {
            try
            {
                return await new DRole(_configuration).Search(description);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> Update(string description , int id_user, int id)
        {
            try
            {
                return await new DRole(_configuration).Update(description, id_user , id);
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
                return await new DRole(_configuration).UpdateActive(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
