using CRUDSampleMVC.Models;
using CRUDSampleMVC.Models.IRepository.CategoryRep;
using CRUDSampleMVC.Models.ViewModels.Category;
using System.Security.Cryptography;

namespace CRUDSampleMVC.Service.Iservices
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryVM>> GetAllCategories();

        Task<CategoryVM> GetCategory(int id);
        Task AddCategory(CategoryPostVM category);
        void UpdateCategory(CategoryVM category);
        void DeleteCategory(CategoryVM category);
        bool CategoryExists(int id);
    }
}
