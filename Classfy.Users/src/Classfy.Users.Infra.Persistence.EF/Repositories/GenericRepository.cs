using Classfy.Users.Domain.BuildingBlocks;
using Classfy.Users.Domain.Exceptions;
using Classfy.Users.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Classfy.Users.Infra.Persistence.EF.Repositories
{
    public abstract class GenericRepository<AgreggateType, IdentifierType>: 
        IGenericRepository<AgreggateType, IdentifierType>, IRepository
        where AgreggateType : class
    {
        protected readonly ClassfyUsersContext _context;
        protected DbSet<AgreggateType> _aggregates => _context.Set<AgreggateType>();


        protected GenericRepository(ClassfyUsersContext context)
            => _context = context;

        public async Task Add(AgreggateType aggregate)
            => await _aggregates.AddAsync(aggregate);

        public async Task Delete(IdentifierType id)
        {
            var aggregate = await _aggregates.FindAsync(id);
            if (aggregate == null)
                throw new NotFoundException($"Aggregate {nameof(AgreggateType)} not found");
            _aggregates.Remove(aggregate);
        }

        public async Task<AgreggateType?> Get(IdentifierType id)
            => await _aggregates.FindAsync(id);

        public async Task Update(AgreggateType aggregate)
            =>_aggregates.Update(aggregate);
    }
}
