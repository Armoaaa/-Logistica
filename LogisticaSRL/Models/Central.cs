using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class Central
    {
        [Key]
        public int IdCentral { get; set; }

        public string Nombre { get; set; }
        [ForeignKey("IdDomicilio")]
        public int DomicilioId { get; set; }
        [Required]
        public Domicilio domicilio { get; set; }
        public ICollection<Sucursal> Sucursales { get; set; }
    }
}