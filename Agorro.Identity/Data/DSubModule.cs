using Agorro.Identity.Entity;
using Agorro.Identity.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Agorro.Identity.Entity.Request;

namespace Agorro.Identity.Data
{
    internal class DSubModule : ISubModule
    {
        readonly IConfiguration _configuration;
        public DSubModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(RSubModule subModule)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @id_module = subModule.id_module, @description = subModule.description, @id_user = subModule.id_user, @url = subModule.url, @icon = subModule.icon });
                    var Response = dbConnection.Execute("sp_sub_module_add",parameters,commandType: CommandType.StoredProcedure);
                    return Response;
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
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                    var response = dbConnection.Execute("sp_sub_module_delete", parameters, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    return response;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    IEnumerable<ESubModule> List = new List<ESubModule>();
                    List = dbConnection.Query<ESubModule>("sp_sub_module_list", parameters, commandType: CommandType.StoredProcedure);
                    return List;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    IEnumerable<ESubModule> List = new List<ESubModule>();
                    List = dbConnection.Query<ESubModule>("sp_sub_module_list_actives", parameters, commandType: CommandType.StoredProcedure);

                    return List;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion", descripcion);
                    IEnumerable<ESubModule> List = new List<ESubModule>();
                    var list = dbConnection.Query<ESubModule>("sp_role_search", parameters, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    return list;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open ();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new {@id=subModule.id, @id_module=subModule.id_module, @description = subModule.description, @id_user=subModule.id_user, @url=subModule.url, @icon=subModule.icon});
                    var Response = dbConnection.Execute("sp_sub_module_update", parameters, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    return Response;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                    int response = dbConnection.Execute("sp_sub_module_update_state", parameters, commandType: CommandType.StoredProcedure);

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
