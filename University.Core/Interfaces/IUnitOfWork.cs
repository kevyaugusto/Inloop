using System.Threading.Tasks;

namespace University.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Save();
    }
}
