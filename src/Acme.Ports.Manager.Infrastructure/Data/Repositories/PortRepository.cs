using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Ports;
using Acme.Ports.Manager.Core.Ports.Repositories;

namespace Acme.Ports.Manager.Infrastructure.Data.Repositories
{
    public class PortRepository : IPortRepository
    {
        private readonly PortsManagerContext _context;

        public PortRepository(PortsManagerContext context)
        {
            _context = context;
        }

        public async Task Save(Port port)
        {
            await _context.Ports.AddAsync(port);

            await _context.SaveChangesAsync();
        }
    }
}