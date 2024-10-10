using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticaSRL.Models
{
    public class Sucursal
    {
        [Key]
        public int IdSucursal { get; set; }
        [Required]
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public int DomicilioId { get; set; }
        public Domicilio Domicilio { get; set; }
        public int CentralId { get; set; }
        public Central Central { get; set; }
    }
}