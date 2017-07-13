using System;
using System.ComponentModel.DataAnnotations;

namespace FoxyEcomm.Services.Inventory.Models
{

    public class CreateProductPropertyRequest
    {

        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Key { get; set; }

        [Required]
        [StringLength(1200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Value { get; set; }

      

    }


}
