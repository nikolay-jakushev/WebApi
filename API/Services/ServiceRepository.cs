using System;
using System.Threading.Tasks;
using API.Entities;
using API.Repository;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace API.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IRepositoryDao _repository;
        private readonly IConfiguration _configuration;

        public ServiceRepository(IRepositoryDao repository, IConfiguration configuration)
        {
            this._repository = repository;
            this._configuration = configuration;
        }

        public async Task<ReportInfo> GetRequest(Guid requestId)
        {
            var report = new ReportInfo();
            var query = await _repository.GetRequest(requestId);
            
            if(query == null) { return report; }

            report.Percent = query.Percent;
            report.Query = query.QueryID;

            if(query.QueryID == null) { return report; }

            report.Result = new User
            {
                ID = query.UserID,
                CountSignIn = query.CountSignIn
            };

            return report;
        }

        public async Task<Guid> SaveUser(Guid userId, int from, int to)
        {
            var query = new Query
            {
                QueryID = new Guid(),
                CountSignIn = to -from,
                Percent = 0,
                UserID = userId
            };

            var result = await _repository.SaveUser(query);
            return result;
        }

        public async Task Update()
        {
            int delay = _configuration.GetValue<int>("Delay");
            int frequency = _configuration.GetValue<int>("Frequncy");
            int koef = frequency / delay * 100;
            var queries = await _repository.GetListQuery();
            foreach (var query in queries.Where(query => query.Percent <= 100))
            {
                query.Percent += koef;
                if (query.Percent > 100) { query.Percent = 100; }
                await _repository.UpdateRequest(query.QueryID, query);
            }
        }
    }
}