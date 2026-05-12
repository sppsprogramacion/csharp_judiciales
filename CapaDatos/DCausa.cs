using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCausa
    {
        public int id_causa { get; set; }
        public int ingreso_interno_id { get; set; }
        public DIngresoInterno ingreso_interno { get; set; }
        public string causa { get; set; }
        public string prision_reclusion_id { get; set; }
        public DPrisionReclusion prision_reclusion { get; set; }
        public string expediente { get; set; }
        public int tipo_delito_id { get; set; }
        public DTipoDelito tipo_delito { get; set; }
        public string estado_procesal_id { get; set; }
        public DEstadoProcesal estado_procesal { get; set; }
        public string jurisdiccion_id { get; set; }
        public DJurisdiccion jurisdiccion { get; set; }
        public string juzgado_id { get; set; }
        public DJuzgado juzgado { get; set; }
        public string otro_juzgado_id { get; set; }
        public DJuzgado otro_juzgado { get; set; }
        public string reincidencia_id { get; set; }
        public DReincidencia reincidencia { get; set; }
        public DateTime fecha_ultima_detencion { get; set; }
        public bool tiene_computo { get; set; }
        public DateTime? fecha_condena { get; set; }
        public string tribunal_condena_id { get; set; }
        public DJuzgado tribunal_condena { get; set; }
        public int pena_anios { get; set; }
        public int pena_meses { get; set; }
        public int pena_dias { get; set; }
        public DateTime? fecha_cumple_pena { get; set; }
        public bool esta_unificada { get; set; }
        public bool agoto_condena { get; set; }
        public int tipo_defensor_id { get; set; }
        public DTipoDefensor tipo_defensor { get; set; }
        public string abogado { get; set; }
        public bool vigente { get; set; }
        public DateTime fecha_carga { get; set; }
        public bool eliminado { get; set; }
        public int organismo_carga_id { get; set; }
        public DOrganismo organismo_carga { get; set; }
        public int usuario_carga_id { get; set; }
        public DUsuario usuario_carga { get; set; }

    }
}
