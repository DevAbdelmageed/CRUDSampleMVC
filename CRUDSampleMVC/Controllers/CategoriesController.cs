using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDSampleMVC.Models;
using System.Globalization;
using CRUDSampleMVC.Models.Models.UnitOfWork;
//using CRUDSampleMVC.Models.Service;

namespace CRUDSampleMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly CategoryService _categoryService;


        #region Constructer 
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            //_categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }
        #endregion

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            return View(await _unitOfWork.Categories.GetAllAsync() );
            //return View(await _categoryService.GetAllAsync() );
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var category = await _unitOfWork.Categories.GetByIdAsync((int)id);
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
        public async Task<IActionResult> Create([Bind("Id,ArabicName,EnglishName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Add(category);

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

            var category = await _unitOfWork.Categories.FindAsync(c=> c.Id == (int)id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicName,EnglishName")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Categories.Update(category);
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

            var category = await _unitOfWork.Categories.FindAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var category = await _unitOfWork.Categories.FindAsync(c => c.Id ==id );
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
            }
            
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return _unitOfWork.Categories.Find(e => e.Id == id) != null;
        }
    }
}
