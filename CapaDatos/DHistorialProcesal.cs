using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DHistorialProcesal
    {
        public int id_historial_procesal { get; set; }
        public int ingreso_interno_id { get; set; }
        public DIngresoInterno ingreso_interno { get; set; }
        public int tipo_historial_procesal_id { get; set; }
        public DTipoHistorialProcesal tipo_historial_procesal { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public string detalle { get; set; }
        public bool is_eliminado { get; set; }
        public string detalle_eliminado { get; set; }
        public DateTime fecha_carga { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
    }
}
