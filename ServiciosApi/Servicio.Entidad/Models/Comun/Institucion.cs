using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicio.Entidad.Models.Comun
{
    public class Institucion
    {
        public int cod_institucion { get; set; }
        public string  nombre { get; set; } 
        public string  siglas { get; set; } 
    }
}