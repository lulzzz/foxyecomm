using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoxyEcomm.Services.Inventory.Entities
{
    [Table("product_options")]
    public class ProductOptionEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }


        [Required]
        [Column("product_id")]
        public Guid ProductId { get; set; }

        [Required]
        [Column("option_group_id")]
        public Guid OptionGroupId { get; set; }

        [Required]
        [Column("option_id")]
        public Guid OptionId { get; set; }

        
        [Column("price")]
        public decimal Price { get; set; }

    }
}
