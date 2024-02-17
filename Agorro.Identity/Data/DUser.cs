using Agorro.Identity.Entity;
using Agorro.Identity.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agorro.Identity.Entity.Request;
using Agorro.Identity.Business;
using System.Net.Mail;
using System.Net;
using Agorro.Backend.Util;

namespace Agorro.Identity.Data
{
    public class DUser:IUser
    {
        readonly IConfiguration _configuration;
        private string _userKey;
        private string _secret;
        private string _email;
        private string _password;
        public DUser(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }
        public DUser(IConfiguration configuration, String userKey)
        {
            _configuration = configuration;
            _userKey = userKey;
        }

        public DUser(IConfiguration configuration, string userKey, string secret, string email, string password)
        {
            _configuration = configuration;
            _userKey = userKey;
            _secret = secret;
            _email = email;
            _password = password;
        }

        public async Task<string> Add(RUser rUser)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var verificationCode = new Random().Next(100000, 999999).ToString();

                    string key = _userKey;
                    var parameter = new DynamicParameters();
                    parameter.AddDynamicParams(new { @id_role = rUser.id_role, @first_name = rUser.first_name,
                        @last_name = rUser.last_name, @mother_last_name = rUser.mother_last_name, @birt_day = rUser.birt_day,
                        @email = rUser.email, @usuario = rUser.usuario, @password = rUser.password, @verification_code = verificationCode,
                        @cellphone = rUser.cellphone, @id_user = rUser.id_user, @KEY = key
                    });

                    string response = dbConnection.QuerySingleOrDefault<string>("sp_user_add", parameter, commandType: CommandType.StoredProcedure).ToString();

                    if (response =="Se registro exitosamente")
                    {

                        string mensaje = new templates().templateEmailConfirmUser(rUser.usuario,verificationCode);

                        MailMessage oMailMessage = new MailMessage(_email, rUser.email, "Codigo de verificación Agorro", mensaje);
                        oMailMessage.IsBodyHtml = true;
                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new System.Net.NetworkCredential(_email, _password);
                        smtpClient.Send(oMailMessage);
                        smtpClient.Dispose();
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new
                    {
                        @user = user,
                        @password = password,
                        @KEY = _userKey
                    };

                    var response = dbConnection.QuerySingleOrDefault<EUser>("sp_user_login",parameters,commandType:CommandType.StoredProcedure);
                    return response;
                 }
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
