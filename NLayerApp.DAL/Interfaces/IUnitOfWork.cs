using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Phone> Phones { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
