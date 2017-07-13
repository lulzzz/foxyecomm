using System;
using System.ComponentModel.DataAnnotations;

namespace FoxyEcomm.Services.Inventory.Models
{

    public class CreateProductOptionRequest
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid OptionGroupId { get; set; }

        [Required]
        public Guid OptionId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }


}
