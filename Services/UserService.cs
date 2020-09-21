using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using people_web_api.Database.SQL;
using people_web_api.Models.SQL;

namespace people_web_api.Services
{
    public class UserService : IUserService
    {
        private readonly ServerDbContext _dbContext;

        public UserService(ServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<User>> Get()
            => await _dbContext.Set<User>().ToListAsync();

        public async Task<User> Get(string id)
            => await _dbContext.Set<User>().AsQueryable().Where(x => x.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task Remove(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(User item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(string id, User item)
        {
            throw new System.NotImplementedException();
        }
    }
}