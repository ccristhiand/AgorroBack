using Agorro.Backend.Util;
using Agorro.Identity.Entity;
using Agorro.Identity.Entity.Request;
using Agorro.Identity.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Agorro.Identity.Data
{
    public class DModule : IModule
    {
        readonly IConfiguration _configuration;
        public DModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Rmodule rmodule)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @description = rmodule.description, @id_user = rmodule.id_user, @url = rmodule.url, @icon = rmodule.icon });
                    var response = dbConnection.Execute("sp_module_add", parameters, commandType: CommandType.StoredProcedure);

                    return response;
                } 
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open ();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id",id);
                    var response = dbConnection.Execute("sp_module_delete", parameters, commandType: CommandType.StoredProcedure);
                    return response;

                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open ();
                    IEnumerable<EModule> response= new List<EModule>();
                    response = dbConnection.Query<EModule>("sp_module_list",new DynamicParameters(),commandType:CommandType.StoredProcedure);
                    return response;

                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@description",description);
                    IEnumerable<EModule> response = new List<EModule>();
                    response = dbConnection.Query<EModule>("sp_module_search", parameters, commandType: CommandType.StoredProcedure);
                    return response;

                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @id = rmodule.id, @description = rmodule.description, @id_user = rmodule.id_user, @url = rmodule.url, @icon = rmodule.icon });
                    var response = dbConnection.Execute("sp_module_update", parameters, commandType: CommandType.StoredProcedure);
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
