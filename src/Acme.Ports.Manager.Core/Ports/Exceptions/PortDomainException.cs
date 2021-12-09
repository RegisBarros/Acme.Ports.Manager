using System;

namespace Acme.Ports.Manager.Core.Ports.Exceptions
{
    public class PortDomainException : Exception
    {
        public PortDomainException() { }

        public PortDomainException(string message) : base(message) { }

        public PortDomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
