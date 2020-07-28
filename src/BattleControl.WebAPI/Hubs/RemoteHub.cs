using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleControl.Core.Dtos;
using BattleControl.Core.Interfaces;
using BattleControl.Core.Models;
using BattleControl.WebAPI.Helpers;
using BattleControl.WebAPI.Services;
using Microsoft.AspNetCore.SignalR;

namespace BattleControl.WebAPI.Hubs
{
    public class RemoteHub : Hub<IRemoteHub>
    {
        private readonly IGetClientsConnectedService _getClientsConnectedService;

        public RemoteHub(IGetClientsConnectedService getClientsConnectedService)
        {
            _getClientsConnectedService = getClientsConnectedService;
        }

        public async Task Send(CommandDto command)
        {
            await Clients.All.SendCommand(command);
        }

        public async Task Receive(string response)
            => await Clients.All.ReceiveResponseCommand(response);

        public async Task SendMachineInfo(ClientMachineInfo clientMachineInfo, string user)
            => await Clients.All.SendInfoClientMachine(clientMachineInfo, user);
        
        public override Task OnConnectedAsync()
        {
            _getClientsConnectedService.AddIdClientToList(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
