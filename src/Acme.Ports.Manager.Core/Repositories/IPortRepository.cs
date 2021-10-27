using System.Threading.Tasks;
using Acme.Ports.Manager.Core.Models;

namespace Acme.Ports.Manager.Core.Repositories
{
    public interface IPortRepository
    {
        Task Save(Port port);
    }
}