using Acme.Ports.Manager.Core.Dtos;

namespace Acme.Ports.Manager.Core.Ports.Mappers
{
    public static class PortMapper
    {
        public static PortDto ToDto(Port port)
        {
            return new PortDto(port.Id, port.Name);
        }
    }
}