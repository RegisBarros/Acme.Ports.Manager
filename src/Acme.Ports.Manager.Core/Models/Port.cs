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
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }

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