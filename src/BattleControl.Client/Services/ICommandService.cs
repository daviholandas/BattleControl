using BattleControl.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BattleControl.Client.Services
{
    public interface ICommandService
    {
        Task<string> ExecuteCommand(CommandDto command);
    }
}
