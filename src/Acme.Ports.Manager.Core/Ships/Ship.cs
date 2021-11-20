using System;
using Acme.Ports.Manager.Core.Ports;

namespace Acme.Ports.Manager.Core.Ships
{
    public class Ship : Entity
    {
        private Ship(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }
        
        public string Name { get; private set; }
        public Port CurrentPort  { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; }
        public DateTime DeletedAt { get; private set; }
        public string DeletedBy { get; private set; }

        public static Ship Create(string name)
        {
            return new Ship(name);
        }

        public void Dock(Port currentPort)
        {
            CurrentPort = currentPort;
        }
    }
}