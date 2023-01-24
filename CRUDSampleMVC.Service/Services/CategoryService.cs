using CRUDSampleMVC.Models;
using CRUDSampleMVC.Models.IRepository.CategoryRep;
using CRUDSampleMVC.Models.ViewModels.Category;
using CRUDSampleMVC.Service.Iservices;
using System.Data.SqlTypes;
using System.Linq;


namespace CRUDSampleMVC.Service.Services
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _Categories { get; private set; }
        //private readonly CategoryService _categoryService;


        #region Constructer 
        public CategoryService(ICategoryRepository Categories)
        {
            //_categoryService = categoryService;
            //_unitOfWork = unitOfWork;
            _Categories = Categories;
        }
        #endregion


        public async Task<IEnumerable<CategoryVM>> GetAllCategories()
        {
            var categories = await _Categories.GetAllAsync();
            return categories.Select(c =>
                new CategoryVM
                {
                    Id = c.Id,
                    EnglishName = c.EnglishName,
                    ArabicName = c.ArabicName,
                });
        }
        public async Task<CategoryVM> GetCategory(int id)
        {
            var category = await _Categories.GetByIdAsync(id);

            return new CategoryVM
            {
                ArabicName = category?.ArabicName,
                EnglishName = category.EnglishName,
                Id = category.Id
            };
        }

        public async Task AddCategory(CategoryPostVM category)
        {
            var categoryToAdd = new Category
            {
                Id = category.Id,
                ArabicName = category.ArabicName,
                EnglishName = category.EnglishName,

            };

            await _Categories.AddAsync(categoryToAdd);
        }

        public void UpdateCategory(CategoryVM category)
        {
            var categoryToAdd = new Category
            {
                Id = category.Id,
                ArabicName = category.ArabicName,
                EnglishName = category.EnglishName,

            };

            _Categories.Update(categoryToAdd);
        }
        public void DeleteCategory(CategoryVM category)
        {
            var deletedCategory = new Category
            {
                Id = category.Id,
                ArabicName = category.ArabicName,
                EnglishName = category.EnglishName,
            };
            _Categories.Delete(deletedCategory);
        }
        public bool CategoryExists(int id)
        {
             return _Categories.Find(c => c.Id == id) != null;
        }
    }
}
