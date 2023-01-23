using CRUDSampleMVC.Models.IRepository.CategoryRep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSampleMVC.Models.Repository.CategoryRep
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly CDRUDContext _context;

        public CategoryRepository(CDRUDContext context) : base(context)
        {
        }

       
    }
}
