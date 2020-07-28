using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleControl.Core.Dtos;
using BattleControl.Core.Models;

namespace BattleControl.WebAPI.Hubs
{
    public interface IRemoteHub
    {
        Task SendCommand(CommandDto command);
        Task ReceiveResponseCommand(string response);
        Task SendInfoClientMachine(ClientMachineInfo clientMachineInfo, string user);
       
    }
}
