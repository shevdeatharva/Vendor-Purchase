using Dapper;

namespace VendorPurchaseProject.DBHandler
{
    public interface IDBService
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GetAll<T>(string command, object parms);
        Task<int> EditData(string command, DynamicParameters parms);
    }
}
