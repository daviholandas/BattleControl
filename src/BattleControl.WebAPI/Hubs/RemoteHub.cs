using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleControl.Core.Interfaces;
using BattleControl.Core.Models;
using BattleControl.WebAPI.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace BattleControl.WebAPI.Hubs
{
    public class RemoteHub : Hub<IRemoteHub>
    {
        public List<string> ClientsId { get; set; }
        public async Task Send(Command command)
        {
            await Clients.All.Send(command);
        }
        
        public override Task OnConnectedAsync()
        {
            GetClientsConnectedHelper.AddClientId(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
