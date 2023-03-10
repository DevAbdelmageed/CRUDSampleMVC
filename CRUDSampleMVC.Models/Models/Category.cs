using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDSampleMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ArabicName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EnglishName { get; set; }
    }
}
