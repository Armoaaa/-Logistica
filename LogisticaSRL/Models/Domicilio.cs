using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogisticaSRL.Models
{
    public class Domicilio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Pais { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(100)]
        public string Calle { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [StringLength(20)]
        public string CodigoPostal { get; set; }
    }
}