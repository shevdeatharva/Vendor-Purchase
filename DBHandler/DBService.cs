using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace VendorPurchaseProject.DBHandler
{
    public class DBService:IDBService
    {
        private readonly IConfiguration _configuration;

        public DBService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("IED_DEV_CON"));
        }

        public async Task<T> GetAsync<T>(string procedureName, object parameter = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(
                    procedureName,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );
            }

        }

        public async Task<List<T>> GetAll<T>(string procedureName, object parameter = null)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QueryAsync<T>(
                    procedureName,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );
                return result.ToList();
            }
        }

        public async Task<int> EditData(string procedureName, DynamicParameters parameter = null)
        {
            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(
                    procedureName,
                    parameter,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}

