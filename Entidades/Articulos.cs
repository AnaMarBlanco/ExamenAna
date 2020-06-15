using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnaMPrimerParcial.Entidades
{
    class Articulos
    {
        [Key]
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public int Existencias { get; set; }
        public decimal Costo { get; set; }
        public decimal Valor { get; set; }
    }
}
