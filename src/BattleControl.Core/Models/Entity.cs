using System;

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