using System;
using System.Threading.Tasks;
using API.Entities;

namespace API.Services
{
    public interface IServiceRepository
    {
        public Task<ReportInfo> GetRequest(Guid userId);
        public Task<Guid> SaveUser(Guid userId, int from, int to);
        public Task Update();
    }
}