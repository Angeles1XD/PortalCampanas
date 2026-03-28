using System;

namespace PortalCampanas.Models
{
    public class Campana
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; }
        public string Canal { get; set; }
        public int Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
    }
}