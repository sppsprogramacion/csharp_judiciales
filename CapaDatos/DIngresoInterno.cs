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
        public string obs_organismo_externo { get; set; }
        public int organismo_procedencia_id { get; set; }
        public DOrganismo organismo_procedencia { get; set; }
        public string obs_organismo_procedencia { get; set; }
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
        public int tipo_defensor_id { get; set; }
        public DTipoDefensor tipo_defensor { get; set; }
        public string abogado { get; set; }
        public int pabellon_id { get; set; }
        public DPabellon pabellon { get; set; }
        public string celda { get; set; }
        public bool tiene_programa_puerta { get; set; }
        public int situacion_provisoria_id { get; set; }
        public DSituacionProvisoria situacion_provisoria { get; set; }
        public string situacion_provisoria_detalle { get; set; }
        public int trimestre_id { get; set; }
        public DTrimestre trimestre { get; set; }
        public int conducta_id { get; set; }
        public DConducta conducta { get; set; }
        public int concepto_id { get; set; }
        public DConcepto concepto { get; set; }
        public int progresividad_id { get; set; }
        public DProgresividad progresividad { get; set; }
        public int fase_id { get; set; }
        public DFase fase { get; set; }
        public bool tiene_extramuro { get; set; }
        public bool tiene_granja { get; set; }
        public bool tiene_semilibertad { get; set; }
        public bool tiene_transitoria { get; set; }
        public bool esta_liberado { get; set; }
        public DateTime? fecha_egreso { get; set; }
        public int motivo_egreso_id { get; set; }
        public DMotivoEgreso motivo_egreso { get; set; }
        public string juzgado_libera_id { get; set; }
        public DJuzgado juzgado_libera { get; set; }
        public string domicilio_libertad { get; set; }
        public string detalles_egreso { get; set; }

        public DateTime fecha_carga { get; set; }
        public int organismo_carga_id { get; set; }
        public DOrganismo organismo_carga { get; set; }
        public int usuario_carga_id { get; set; }
        public DUsuario usuario_carga { get; set; }
        public bool eliminado { get; set; }
        
    }
}
