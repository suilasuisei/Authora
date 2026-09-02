using Backend.Models.Entities;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UsersRepo:IUsersRepo
    {
        private readonly TestDBContext _dbContext;
        public UsersRepo(TestDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ExistUserAsync(string Account)
        {
            var isOld = await _dbContext.Users.AnyAsync(user => user.Account == Account);

            return isOld;
        }

        public async Task<Users> CreateUserAsync(Users user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Users?> SearchUserAsync(string Keyword)
        {
            return await _dbContext.Users
                .Where(u => u.UserName.Contains(Keyword) || u.Account.Contains(Keyword))
                .FirstOrDefaultAsync();
        }

        public async Task<Users?> RemoveUserAsync(string UserName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == UserName);

            if (user == null)
            {
                return null;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<Users?> GetByLineIdAsync(string lineId)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(x => x.LineId == lineId);
        }

    }
}
