using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Brand { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        [Required]
        public string Model { get; set; }

        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool New { get; set; }
    }
}
