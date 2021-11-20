using System;

namespace Acme.Ports.Manager.Core.Dtos
{
    public class PortDto
    {
        public PortDto() { }
        
        public PortDto(Guid portId, string portName)
        {
            Id = portId.ToString();
            Name = portName;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}