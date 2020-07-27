using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BattleControl.Core.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BattleControl.Client
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HubConnection _hubConnection;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:49175/commands")
                .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ExecuteCommand();
            try
            {
                await _hubConnection.StartAsync(stoppingToken);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
               
                throw;
            }
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(_hubConnection.ConnectionId);
                await Task.Delay(10000, stoppingToken);
            }
        }

        private async Task ExecuteCommand()
        {
            _hubConnection.On<Command>("Send",  command =>
            {
                _logger.LogInformation($"{command.Id} - {command.Argument}");
            });

            await Task.CompletedTask;
        }

    }
}
