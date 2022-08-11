using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Services
{
    public class HostService : IHostedService
    {
        private readonly IServiceRepository _service;
        private readonly IConfiguration _configuration;
        private Timer _timer;

        public HostService(IServiceScopeFactory service, IConfiguration configuration)
        {
            var serviceProvider = service.CreateScope().ServiceProvider;
            _service = serviceProvider.GetRequiredService<IServiceRepository>();
            this._configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var frequency = _configuration.GetValue<int>("Frequncy");
            _timer = new Timer(UpdatePercents, null, TimeSpan.FromSeconds(frequency), TimeSpan.FromSeconds(frequency));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private  void UpdatePercents(object o)
        {
            _service.Update();
        }

    }
}