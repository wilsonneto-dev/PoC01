using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classfy.Users.Domain.BuildingBlocks
{
    public interface IGenericRepository<TAggregateType, TIdentifierType> : IRepository
    {
        Task Add(TAggregateType aggregate);

        Task Update(TAggregateType aggregate);
        
        Task<TAggregateType?> Get(TIdentifierType id);
        
        Task Delete(TIdentifierType id);
    }
}
