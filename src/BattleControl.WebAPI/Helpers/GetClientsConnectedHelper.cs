using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleControl.WebAPI.Helpers
{
    public static class GetClientsConnectedHelper
    {
        private static List<string> _clientsId = new List<string>();

        public static void AddClientId(string clientId)
        {
            _clientsId.Add(clientId);
        }

        public static List<string> ListClientsId()
            => _clientsId;
    }
}
