using Classfy.Users.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Classfy.Users.Infra.Persistence.EF.Repositories
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository 
    {
        public UserRepository(ClassfyUsersContext context) : base(context)
        {}

        public async Task<User?> FindByEmail(string email)
            => await _aggregates.AsNoTracking().Where(x => x.Email.ToString() == email).FirstOrDefaultAsync();
    }
}
