using System.Threading.Tasks;

namespace BattleControl.Core.Interfaces
{
    public interface IRemoteControl
    {
        Task GetMachineInfo();
        Task SendCommand(string command);
    }
}