using System;
using System.Collections.Generic;

namespace Acme.Ports.Manager.Core.Models
{
    public class Port : Entity
    {
        public string Name { get; set; }
        public ICollection<Ship> DockerShips { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}