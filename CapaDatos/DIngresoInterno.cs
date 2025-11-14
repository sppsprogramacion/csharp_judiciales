using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DIngresoInterno
    {
        public int id_ingreso_interno { get; set; }
        public int interno_id { get; set; }
        public DInterno interno { get; set; }
        public DateTime fecha_primer_ingreso { get; set; }
        public int organismo_externo_id { get; set; }
        public DOrganismoExterno organismo_externo { get; set; }
        public int organismo_procedencia_id { get; set; }
        public DOrganismo organismo_procedencia { get; set; }
        public int organismo_alojamiento_id { get; set; }
        public DOrganismo organismo_alojamiento { get; set; }
        public DateTime fecha_alojamiento { get; set; }
        public string estado_procesal_id { get; set; }
        public DEstadoProcesal estado_procesal { get; set; }
        public string jurisdiccion_id { get; set; }
        public DJurisdiccion jurisdiccion { get; set; }
        public string otra_jurisdiccion_id { get; set; }
        public DJurisdiccion otra_jurisdiccion { get; set; }
        public int reingreso_id { get; set; }
        public DReingreso reingreso { get; set; }
        public int numero_reingreso { get; set; }
        public string prontuario_policial { get; set; }
        public bool esta_liberado { get; set; }
        public DateTime? fecha_egreso { get; set; }
        public DateTime fecha_carga { get; set; }
        public int organismo_carga_id { get; set; }
        public DOrganismo organismo_carga { get; set; }
        public int usuario_carga_id { get; set; }
        public DUsuario usuario_carga { get; set; }
        public bool eliminado { get; set; }
        
    }
}
