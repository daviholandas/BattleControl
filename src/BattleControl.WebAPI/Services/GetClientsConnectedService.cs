using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleControl.WebAPI.Services
{
    public class GetClientsConnectedService : IGetClientsConnectedService
    {
        private List<dynamic> _clientsId = new List<dynamic>();

        public void AddIdClientToList(string clientContextId)
        {
            _clientsId.Add(new {id = clientContextId});
        }

        public IEnumerable<dynamic> ListClientsConnectionId()
            => _clientsId;
    }
}
