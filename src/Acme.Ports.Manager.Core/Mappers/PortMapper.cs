using Acme.Ports.Manager.Core.Dtos;
using Acme.Ports.Manager.Core.Models;

namespace Acme.Ports.Manager.Core.Mappers
{
    public static class PortMapper
    {
        public static PortDto ToDto(Port port)
        {
            return new PortDto(port.Id, port.Name);
        }
    }
}