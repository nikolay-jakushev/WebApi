using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repository
{
    public interface IRepositoryDao
    {
        public Task<Query> GetRequest(Guid userId);
        public Task<Guid> SaveUser(Query query);
        public Task<IEnumerable<Query>> GetListQuery();

        public Task UpdateRequest(Guid queryGuid, Query reportInfo);
        
    }
}