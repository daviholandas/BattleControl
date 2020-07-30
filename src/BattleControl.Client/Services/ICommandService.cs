using BattleControl.Core.Dtos;
using System.Threading.Tasks;

namespace BattleControl.Client.Services
{
    public interface ICommandService
    {
        Task<string> ExecuteCommand(CommandDto command);
    }
}