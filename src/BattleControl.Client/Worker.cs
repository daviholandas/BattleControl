using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BattleControl.Client.Services;
using BattleControl.Core.Dtos;
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
        private readonly ClientMachineInfo _clientMachineInfo;
        private ICommandService _commandService;

        public Worker(ILogger<Worker> logger, ICommandService commandService)
        {
            _commandService = commandService;
            _clientMachineInfo = new ClientMachineInfo();
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
                await _hubConnection.InvokeAsync("SendMachineInfo", _clientMachineInfo, _hubConnection.ConnectionId);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
               
                throw;
            }
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(_clientMachineInfo.IP);
                await Task.Delay(10000, stoppingToken);
            }
        }

        private async Task ExecuteCommand()
        {
            _hubConnection.On<CommandDto>("SendCommand", async command =>
            {
                _logger.LogInformation($"{command.Argument}");
                await _hubConnection.InvokeAsync("Receive", await _commandService.ExecuteCommand(command));
            });
           
            await Task.CompletedTask;
        }

    }
}
