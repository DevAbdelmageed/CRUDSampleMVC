using CRUDSampleMVC.Models.IRepository.CategoryRep;

namespace CRUDSampleMVC.Models.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task CompleteAsync();
    }
}