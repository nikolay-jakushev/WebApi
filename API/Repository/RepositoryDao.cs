using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class RepositoryDao : IRepositoryDao
    {
        private readonly StoreContext _context;

        public RepositoryDao(StoreContext context)
        {
            this._context = context;
        }

        public async Task<Query> GetRequest(Guid userId)
        {
            return await _context.Query.FindAsync(userId);
        }

        public async Task<Guid> SaveUser(Query query)
        {
            await _context.Query.AddAsync(query);
            var result = await _context.SaveChangesAsync();
            return query.QueryID;
        }

        public async Task<IEnumerable<Query>> GetListQuery()
        {
            return await _context.Query.ToListAsync();
        }

        public async Task UpdateRequest(Guid queryGuid, Query reportInfo)
        {
            Query query = await _context.Query.FirstOrDefaultAsync(q => q.QueryID == queryGuid);
            query = reportInfo;
             _context.Update(query);
            await _context.SaveChangesAsync();
        }
    }
}