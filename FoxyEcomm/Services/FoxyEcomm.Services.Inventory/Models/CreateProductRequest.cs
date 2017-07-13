using System;
using System.ComponentModel.DataAnnotations;

namespace FoxyEcomm.Services.Inventory.Models
{

    public class CreateProductRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Code { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }


        [Required]
        public decimal Vat { get; set; }

        [Required]
        public Guid BrandId { get; set; }

        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Required]
        [MaxLength(1500)]
        public string LongDescription { get; set; }

    }


}
