using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleControl.Core.Models;
using BattleControl.WebAPI.Helpers;
using BattleControl.WebAPI.Hubs;
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
      

        public CommandsController(IHubContext<RemoteHub, IRemoteHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendCommand(Command command)
        {
            await _hubContext.Clients.All.Send(command);

          return Ok();
        }

        [HttpGet]
        public IEnumerable<string> ListOfClients()
            => GetClientsConnectedHelper.ListClientsId();
    }
}
