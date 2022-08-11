using System;
using System.Collections.Generic;
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
            var result = await _context.Query.ToListAsync();
            return result;
        }

        public async Task UpdateRequest(Guid queryGuid, Query reportInfo)
        {
            Query queryToUpdate = await _context.Query.FirstOrDefaultAsync(q => q.QueryID == queryGuid);
            reportInfo = queryToUpdate;
            await _context.SaveChangesAsync();
        }
    }
}