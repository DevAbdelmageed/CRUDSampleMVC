using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDSampleMVC.Models;
using System.Globalization;
using CRUDSampleMVC.Models.Models.UnitOfWork;
using CRUDSampleMVC.Service.Services;
using CRUDSampleMVC.Service.Iservices;
using CRUDSampleMVC.Resources;
using CRUDSampleMVC.Models.ViewModels.Category;
//using CRUDSampleMVC.Models.Service;

namespace CRUDSampleMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;


        #region Constructer 
        public CategoriesController(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }
        #endregion

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            //var cc = await _unitOfWork.Categories.GetAllAsync();
            //return View( );
            return View(await _categoryService.GetAllCategories());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetCategory((int)id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicName,EnglishName")] CategoryPostVM category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(category);

                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var category = await _categoryService.GetCategory((int)id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicName,EnglishName")] CategoryVM category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.UpdateCategory(category);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            //var category = await _unitOfWork.Categories.FindAsync(m => m.Id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
            return View();

        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var category = await _categoryService.GetCategory(id);
            if (category != null)
            {
                _categoryService.DeleteCategory(category);
            }

            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _categoryService.CategoryExists(id);
        }
    }
}
