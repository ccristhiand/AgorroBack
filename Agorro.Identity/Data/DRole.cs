using Agorro.Backend.Util;
using Agorro.Identity.Entity;
using Agorro.Identity.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Agorro.Identity.Data
{
    public class DRole : IRole
    {
        readonly IConfiguration _configuration;
        public DRole(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(string description, int id_user)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameter = new DynamicParameters();
                    parameter.AddDynamicParams(new { @description = description, @id_user = id_user });
                    var response = dbConnection.Execute("sp_role_add", parameter, commandType: CommandType.StoredProcedure);
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
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                    int response = dbConnection.Execute("sp_role_delete", parameters, commandType: CommandType.StoredProcedure);

                    return response;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    IEnumerable<ERole> List = new List<ERole>();
                    List = dbConnection.Query<ERole>("sp_role_list", parameters, commandType: CommandType.StoredProcedure);

                    return List;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    IEnumerable<ERole> List = new List<ERole>();
                    List = dbConnection.Query<ERole>("sp_role_list_actives", parameters, commandType: CommandType.StoredProcedure);

                    return List;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@description", description);

                    IEnumerable<ERole> List = new List<ERole>();
                    List = dbConnection.Query<ERole>("sp_role_search", parameters, commandType: CommandType.StoredProcedure);

                    return List;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<int> Update(string description, int id_user , int id)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new {@description = description, @id_user =id_user, @id = id});
                    int response = dbConnection.Execute("sp_role_Update", parameters, commandType: CommandType.StoredProcedure);

                    return response;
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
                    parameters.Add("@id",id );
                    int response = dbConnection.Execute("sp_role_update_state", parameters, commandType: CommandType.StoredProcedure);

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
