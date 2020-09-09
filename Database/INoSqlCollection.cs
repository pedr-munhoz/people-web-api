using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace people_web_api.Database
{
    public interface INoSqlCollection<T>
    {
        IFindFluent<T, T> Find(Expression<Func<T, bool>> filter);

        Task InsertOneAsync(T item);

        Task<ReplaceOneResult> ReplaceOneAsync(Expression<Func<T, bool>> filter, T item);

        Task<DeleteResult> DeleteOneAsync(Expression<Func<T, bool>> filter);
    }
}