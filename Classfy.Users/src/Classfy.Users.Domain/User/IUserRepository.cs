using Classfy.Users.Domain.BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classfy.Users.Domain.User
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
        Task<User?> FindByEmail(string email);
    }
}
