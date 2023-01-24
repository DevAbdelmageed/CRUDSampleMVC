using CRUDSampleMVC.Models.IRepository.CategoryRep;
using CRUDSampleMVC.Models.Repository.CategoryRep;

namespace CRUDSampleMVC.Models.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CDRUDContext _context;

        //public ICategoryRepository Categories { get; private set; }

        public UnitOfWork(CDRUDContext context)
        {
            _context = context;

            //Categories = new CategoryRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
