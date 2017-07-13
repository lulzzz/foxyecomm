using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoxyEcomm.Services.Inventory.Entities
{
    [Table("product_properties")]
    public class ProductPropertyEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Key]
        [Column("product_id")]
        public Guid ProductId { get; set; }
        [Required]
        [Column("key")]
        [MaxLength(200)]
        public string Key { get; set; }

        [Required]
        [Column("value")]
        [MaxLength(1200)]
        public string Value { get; set; }

        
    }
}
