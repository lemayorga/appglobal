namespace Servicio.Entidad.Models.Comun
{
    public class Sucursales
    {
        public int cod_sucursal { get; set; }
        public string sucursal { get; set; } 
        public int cod_institucion { get; set; }
        public Institucion Institucion { get; set; }
    }
}