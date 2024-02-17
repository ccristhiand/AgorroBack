using Agorro.Identity.Data;
using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using Agorro.Identity.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Agorro.Identity.Business
{
    public class BUser:IUser
    {
        readonly IConfiguration _configuration;
        private string _userKey;
        private string _secret;
        private string _email;
        private string _password;
        public BUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BUser(IConfiguration configuration, String userKey)
        {
            _configuration = configuration;
            _userKey = userKey;
        }

        public BUser(IConfiguration configuration, string userKey, string secret, string email, string password)
        {
            _configuration = configuration;
            _userKey = userKey;
            _secret = secret;
            _email = email;
            _password = password;
        }


        public async Task <string> Add(RUser rUser)
        {
            return await new DUser(_configuration,_userKey,_secret,_email,_password).Add(rUser);
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EUser>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EUser>> GetActives()
        {
            throw new NotImplementedException();
        }

        public async Task<EUser> Login(string user, string password)
        {
            return await new DUser(_configuration ,_userKey).Login(user, password);
        }

        public Task<IEnumerable<EUser>> Search(string descripcion)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateActive(int id)
        {
            throw new NotImplementedException();
        }






    }
}
