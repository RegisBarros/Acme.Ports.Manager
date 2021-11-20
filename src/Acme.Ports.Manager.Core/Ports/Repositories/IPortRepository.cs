using System.Threading.Tasks;

namespace Acme.Ports.Manager.Core.Ports.Repositories
{
    public interface IPortRepository
    {
        Task Save(Port port);
    }
}