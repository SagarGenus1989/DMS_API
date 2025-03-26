using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GLink_API
{
    public class DbOperation : IDbOperation
    {
        private readonly IConfiguration _configuration;

        public DbOperation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("GMitraConnection"));
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureListAsync<T>(string storedProcedureName, object parameters = null)
        {
            using var connection = CreateConnection();

            return await connection.QueryAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> ExecuteStoredProcedureSingleAsync<T>(string storedProcedureName, object parameters = null)
        {
            using var connection = CreateConnection();
            try
            {
                return await connection.QueryFirstOrDefaultAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching single record from stored procedure: {storedProcedureName}", ex);
            }
        }

        public async Task<int> ExecuteStoredProcedureNonQueryAsync(string storedProcedureName, object parameters = null)
        {
            using var connection = CreateConnection();
            try
            {
                return await connection.ExecuteAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing {storedProcedureName} operation", ex);
            }
        }

        public async Task<object> ExecuteStoredProcedureScalarAsync(string storedProcedureName, object parameters = null)
        {
            using var connection = CreateConnection();
            try
            {
                return await connection.ExecuteScalarAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing scalar stored procedure: {storedProcedureName}", ex);
            }
        }
    }
}
