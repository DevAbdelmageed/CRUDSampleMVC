using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDSampleMVC.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ArabicTitle { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EnglishTitle { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string ArabicBody { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string EnglishBody { get; set; }

        public DateTime Date { get; set; }

        public  virtual Category Category { get; set; }
    }
}
