using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace people_web_api.Database
{
    /// <summary>
    /// Interface for different NoSQL collection implementations.
    /// </summary>
    /// <typeparam name="T">Type of the document managed by the collection.</typeparam>
    public interface INoSqlCollection<T>
    {
        /// <summary>
        /// Begins a fluent find interface.
        /// </summary>
        /// <param name="filter">The expression by which to filter the collection.</param>
        /// <returns>A fluent find interface.</returns>
        IFindFluent<T, T> Find(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Inserts one element into the collection.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        /// <returns>void.</returns>
        Task InsertOneAsync(T item);

        /// <summary>
        /// Replaces one element in the collection. Replaces the first occurrence.
        /// </summary>
        /// <param name="filter">
        /// The expression by which to compare the new element against the existing ones.
        /// </param>
        /// <param name="item">The item to replace.</param>
        /// <returns>The result of an update operation.</returns>
        Task<ReplaceOneResult> ReplaceOneAsync(Expression<Func<T, bool>> filter, T item);

        /// <summary>
        /// Deletes one element from the collection. Deletes the first occurrence.
        /// </summary>
        /// <param name="filter">
        /// The expression by which to determine which element to delete.</param>
        /// <returns>The result of a delete operation.</returns>
        Task<DeleteResult> DeleteOneAsync(Expression<Func<T, bool>> filter);
    }
}