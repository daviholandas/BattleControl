using BattleControl.Core.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
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

        public async Task<string> ExecuteCommand(CommandDto command)
        {
            try
            {
                using (Runspace runspace = RunspaceFactory.CreateRunspace())
                {
                    runspace.Open();
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript(command.Argument);
                    pipeline.Commands.Add("Out-String");
                    Collection<PSObject> results = pipeline.Invoke();
                    runspace.CloseAsync();
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var result in results)
                        stringBuilder.AppendLine(result.ToString());

                    _logger.LogInformation(stringBuilder.ToString());
                    return stringBuilder.ToString();
                }
                    
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return e.Message;
            }
            

        }
    }
}
