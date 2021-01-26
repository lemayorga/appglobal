using System.Collections.Generic;

namespace Servicio.Entidad.Models.Comun
{
    public class Institucion
    {
        public int cod_institucion { get; set; }
        public string nombre { get; set; } 
        public string siglas { get; set; }
        public ICollection<Sucursales> Surcursales { get; set; }     
    }
}