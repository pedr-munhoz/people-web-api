using System.Collections.Generic;
using System.Threading.Tasks;

namespace people_web_api.Services
{
    public interface IService<T>
    {
        Task<List<T>> Get();

        Task<T> Get(string id);

        Task<T> Create(T item);

        Task Update(string id, T item);

        Task Remove(string id);

        Task Remove(T item);
    }
}