using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoxyEcomm.Services.Inventory.Entities
{
    [Table("options")]
    public class OptionEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        

        [Required]
        [Column("name")]
        [MaxLength(200)]
        public string Name { get; set; }

    }
}
