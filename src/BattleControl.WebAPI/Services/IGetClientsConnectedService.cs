using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleControl.WebAPI.Services
{
    public interface IGetClientsConnectedService
    {
        IEnumerable<dynamic> ListClientsConnectionId();
        void AddIdClientToList(string clientContextId);
    }
}
