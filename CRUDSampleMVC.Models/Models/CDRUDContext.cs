using Microsoft.EntityFrameworkCore;

namespace CRUDSampleMVC.Models
{
    public class CDRUDContext :DbContext
    {

        #region Constructor
        public CDRUDContext(DbContextOptions<CDRUDContext> options):base(options) 
        {

        }
        #endregion

        #region DB_Sets

        public DbSet<Category> Category { get; set; }
        public DbSet<News> News { get; set; }

        #endregion

    }
}
