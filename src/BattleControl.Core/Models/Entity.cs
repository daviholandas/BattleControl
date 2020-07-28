using System;
using System.Collections.Generic;
using System.Text;

namespace BattleControl.Core.Models
{
    public class Entity
    {
        public Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }

    }
}
