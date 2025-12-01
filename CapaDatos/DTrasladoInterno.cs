using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTrasladoInterno
    {
        public int id_traslado_interno { get; set; }
        public int ingreso_interno_id { get; set; }
        public DIngresoInterno ingreso_interno { get; set; }
        public int organismo_origen_id { get; set; }
        public DOrganismo organismo_origen { get; set; }
        public DateTime fecha_egreso_origen { get; set; }
        public string detalle_traslado { get; set; }
        public int organismo_destino_id { get; set; }
        public DOrganismo organismo_destino { get; set; }
        public DateTime? fecha_ingreso_destino { get; set; }
        public string estado_traslado { get; set; }
        public string obs_traslado { get; set; }
        public DateTime fecha_carga { get; set; }
        public string hora_carga { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
               
    }
}
