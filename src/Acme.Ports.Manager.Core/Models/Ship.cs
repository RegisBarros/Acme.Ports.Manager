using System;

namespace Acme.Ports.Manager.Core.Models
{
    public class Ship : Entity
    {
        public string Name { get; set; }
        public Port CurrentPort  { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}