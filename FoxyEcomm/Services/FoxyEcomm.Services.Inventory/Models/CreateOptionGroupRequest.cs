using System.ComponentModel.DataAnnotations;

namespace FoxyEcomm.Services.Inventory.Models
{

    public class CreateOptionGroupRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

      

    }


}
