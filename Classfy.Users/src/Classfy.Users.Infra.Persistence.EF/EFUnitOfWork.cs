using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classfy.Users.Application.Interfaces;
using Classfy.Users.Domain.BuildingBlocks;
using Microsoft.EntityFrameworkCore;

namespace Classfy.Users.Infra.Persistence.EF
{
    public abstract class EFUnitOfWork: IUnitOfWork
    {
        private readonly ClassfyUsersContext _context;
        
        protected EFUnitOfWork(ClassfyUsersContext context)
            => _context = context;
        
        public async Task<bool> Commit()
            => await _context.SaveChangesAsync() > 1;
    }
}
