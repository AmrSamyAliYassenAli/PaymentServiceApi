using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository
{
    public interface ISPProvider : IDisposable
    {
        Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null);

        Task<int> ExecuteWithStatus(string procedureName, DynamicParameters param = null);

        Task<string> ReturnString(string procedureName, DynamicParameters param = null);

        Task<T> ExecuteScaler<T>(string procedureName, DynamicParameters param = null);

    }
}
