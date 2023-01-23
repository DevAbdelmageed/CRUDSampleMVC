using CRUDSampleMVC.Models.IRepository.CategoryRep;

namespace CRUDSampleMVC.Models.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository  Categories { get; }

        int Complete();
        Task CompleteAsync();
    }
}