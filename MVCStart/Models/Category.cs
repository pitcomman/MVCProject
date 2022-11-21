using System.ComponentModel.DataAnnotations;

namespace MVCStart.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

    }
}
