using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleControl.Core.Models;

namespace BattleControl.WebAPI.Hubs
{
    public interface IRemoteHub
    {
        Task Send(Command command);
       
    }
}
