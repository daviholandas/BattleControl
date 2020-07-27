using System;
using System.Collections.Generic;
using System.Text;

namespace BattleControl.Core.Models
{
    public class Command : Entity
    {
        public string Argument { get; private set; }

        public Command(string argument)
        {
            Argument = argument;
        }

        public Command()
        {
            
        }
    }
}
