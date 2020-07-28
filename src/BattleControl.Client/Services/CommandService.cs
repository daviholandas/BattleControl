using BattleControl.Core.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BattleControl.Client.Services
{
    public class CommandService : ICommandService
    {
        private readonly ILogger<CommandService> _logger;

        public CommandService(ILogger<CommandService> logger)
        {
            _logger = logger;
        }

        public Task<IEnumerable<string>> ExecuteCommand(CommandDto command)
        {
            try
            {
                Process cmd = new Process();

                cmd.StartInfo.FileName = "cmd.exe";
            }catch(Exception e)
            {

            }
        }
    }
}
