using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleControl.Core.Dtos;
using BattleControl.Core.Models;
using BattleControl.WebAPI.Helpers;
using BattleControl.WebAPI.Hubs;
using BattleControl.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BattleControl.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly IHubContext<RemoteHub, IRemoteHub> _hubContext;
        private readonly IGetClientsConnectedService _getClientsConnectedService;
      

        public CommandsController(IHubContext<RemoteHub, IRemoteHub> hubContext,
            IGetClientsConnectedService getClientsConnectedService)
        {
            _hubContext = hubContext;
            _getClientsConnectedService = getClientsConnectedService;
        }

        [HttpPost]
        public async Task<IActionResult> SendCommand(CommandDto commandDto)
        {
            
            await _hubContext.Clients.All.SendCommand(commandDto);

          return Ok();
        }

        [HttpGet]
        public IEnumerable<dynamic> ListOfClients()
            => _getClientsConnectedService.ListClientsConnectionId();
    }
}
