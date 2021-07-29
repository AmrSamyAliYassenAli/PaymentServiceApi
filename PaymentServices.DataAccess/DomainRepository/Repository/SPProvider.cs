using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PaymentServices.DataAccess.DomainRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.Repository
{
    public class SPProvider : ISPProvider
    {

        private readonly MiddlewareDbContext _context;
        private static string _connectionString = string.Empty;

        public SPProvider(MiddlewareDbContext context)
        {
            _context = context;
            _connectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public async Task<T> ExecuteScaler<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();

                return (T)Convert.ChangeType(await con.ExecuteScalarAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public async Task<int> ExecuteWithStatus(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.ExecuteAsync(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryAsync<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<string> ReturnString(string procedureName, DynamicParameters param = null)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                return await con.QueryFirstOrDefaultAsync<string>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
