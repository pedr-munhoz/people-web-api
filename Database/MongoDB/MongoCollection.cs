using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace people_web_api.Database.MongoDB
{
    public class MongoCollection<T> : INoSqlCollection<T>
    {
        private readonly IMongoCollection<T> _collection;
        public Task<DeleteResult> DeleteOneAsync(Expression<Func<T, bool>> filter)
            => _collection.DeleteOneAsync(filter);

        public IFindFluent<T, T> Find(Expression<Func<T, bool>> filter)
            => _collection.Find(filter);

        public Task InsertOneAsync(T item)
            => _collection.InsertOneAsync(item);

        public Task<ReplaceOneResult> ReplaceOneAsync(Expression<Func<T, bool>> filter, T item)
            => _collection.ReplaceOneAsync(filter, item);
    }
}