
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required!!!")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The Price field is required!!!")]
        [Range(1, 1000)]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "The Stock field is required!!!")]
        [Range(1,200)]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "The Color field is required!!!")]
        public string? Color { get; set; }
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "The Expire field is required!!!")]
        public int? Expire { get; set; }
        [Required(ErrorMessage = "The Description field is required!!!")]
        [StringLength(300,MinimumLength = 50)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "The PublishDate field is required!!!")]
        public DateTime? PublishDate { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
