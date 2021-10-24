using System;

namespace Acme.Ports.Manager.Core.Dtos
{
    public class PortDto
    {
        public PortDto(Guid portId, string portName)
        {
            Id = portId;
            Name = portName;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}