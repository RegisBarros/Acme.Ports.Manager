using System;
using System.Collections.Generic;

namespace Acme.Ports.Manager.Core.Models
{
    public class Port : Entity
    {
        private Port(string name) 
            : base()
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }
        
        public string Name { get; private set; }
        public ICollection<Ship> DockedShips { get; set; } = new List<Ship>();
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; }
        public DateTime DeletedAt { get; private set; }
        public string DeletedBy { get; private set; }

        public static Port Create(string name)
        {
            return new Port(name);
        }

        public void DockShip(Ship ship)
        {
            if (DockedShips.Contains(ship)) return;
            
            DockedShips.Add(ship);
            ship.Dock(this);
        }
    }
}