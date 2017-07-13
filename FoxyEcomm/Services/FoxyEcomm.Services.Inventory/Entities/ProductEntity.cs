using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoxyEcomm.Services.Inventory.Entities
{
    [Table("products")]
    public class ProductEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Key]
        [Column("brand_id")]
        public Guid BrandId { get; set; }
        [Required]
        [Column("code")]
        [MaxLength(200)]
        public string Code { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [Column("short_description")]
        [MaxLength(500)]
        public string ShortDesc { get; set; }

        [Required]
        [Column("long_description")]
        [MaxLength(1500)]
        public string LongDesc { get; set; }
        [Required]
        [Column("stock")]
        public int Stock { get; set; }

        [Required]
        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column("vat")]
        public decimal Vat { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}
