using System.Collections.Generic;

namespace BattleControl.WebAPI.Services
{
    public interface IGetClientsConnectedService
    {
        IEnumerable<dynamic> ListClientsConnectionId();

        void AddIdClientToList(string clientContextId);
    }
}