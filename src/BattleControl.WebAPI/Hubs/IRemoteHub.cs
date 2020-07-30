using BattleControl.Core.Dtos;
using BattleControl.Core.Models;
using System.Threading.Tasks;

namespace BattleControl.WebAPI.Hubs
{
    public interface IRemoteHub
    {
        Task SendCommand(CommandDto command);

        Task ReceiveResponseCommand(string response);

        Task SendInfoClientMachine(ClientMachineInfo clientMachineInfo, string user);
    }
}