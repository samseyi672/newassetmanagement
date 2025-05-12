using NewAsset.Domain.Common.Models;
using System;
using System.Collections.Generic;


namespace NewAsset.Application.Common.Interfaces.Persistence
{

    /// <summary>
    /// This Abstraction set up the basic crud operation can be performed on any entity
    /// in the application layer without repeating any any sql query .
    /// This action is performed with dynamic stored procedures for crud operations
    /// And this also prevent sql injection
    /// </summary>
    public interface IGenericRepository<T> where T : IDbEntity
    {
        Task<IEnumerable<T>> GetAsync(QueryParameters queryParameters, params string[] selectData);
        Task<T> GetByIdAsync(string guid, params string[] selectData);
        Task<IEnumerable<T>> GetBySpecificColumnAsync(string columnName, string columnValue, params string[] selectData);
        Task<string> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(string id, bool softDeleteFromRelatedChildTables = false);
        Task<int> GetTotalCountAsync();
        Task<bool> IsExistingAsync(string distinguishingUniqueKeyValue);
    }
}
