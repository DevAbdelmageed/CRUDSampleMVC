using System.ComponentModel.DataAnnotations;

namespace CRUDSampleMVC.Models.ViewModels.Category
{
    public class CategoryPostVM
    {
        public int Id { get; set; }
        [Required]
        public string ArabicName { get; set; }
        [Required]
        public string EnglishName { get; set; }
    }
}
