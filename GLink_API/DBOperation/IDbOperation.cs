namespace GLink_API
{
    public interface IDbOperation
    {
        Task<IEnumerable<T>> ExecuteStoredProcedureListAsync<T>(string storedProcedureName, object parameters = null);
        Task<T> ExecuteStoredProcedureSingleAsync<T>(string storedProcedureName, object parameters = null);
        Task<int> ExecuteStoredProcedureNonQueryAsync(string storedProcedureName, object parameters = null);
        Task<object> ExecuteStoredProcedureScalarAsync(string storedProcedureName, object parameters = null);
    }
}
