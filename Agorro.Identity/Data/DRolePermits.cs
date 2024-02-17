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

namespace Agorro.Identity.Data
{
    internal class DRolePermits : IRolePermits
    {
        readonly IConfiguration _configuration;
        public DRolePermits(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(RRolePermits permits)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @id_sub_module = permits.id_sub_module, @id_role = permits.id_role, @id_user = permits.id_user});
                    var Response = dbConnection.Execute("sp_role_permits_add", parameters, commandType: CommandType.StoredProcedure);
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
                    var response = dbConnection.Execute("sp_role_permits_delete", parameters, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    return response;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    IEnumerable<ERolePermits> List = new List<ERolePermits>();
                    List = dbConnection.Query<ERolePermits>("sp_role_permits_list", parameters, commandType: CommandType.StoredProcedure);
                    return List;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    IEnumerable<ERolePermits> List = new List<ERolePermits>();
                    List = dbConnection.Query<ERolePermits>("sp_role_permits_list_actives", parameters, commandType: CommandType.StoredProcedure);

                    return List;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@descripcion", descripcion);
                    IEnumerable<ERolePermits> List = new List<ERolePermits>();
                    var list = dbConnection.Query<ERolePermits>("sp_role_permits_search", parameters, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    return list;
                }
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
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new {@id=permits.id, @id_sub_module = permits.id_sub_module, @id_role = permits.id_role, @id_user = permits.id_user });
                    var Response = dbConnection.Execute("sp_role_permits_update", parameters, commandType: CommandType.StoredProcedure);
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
                    int response = dbConnection.Execute("sp_role_permits_update_state", parameters, commandType: CommandType.StoredProcedure);

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
