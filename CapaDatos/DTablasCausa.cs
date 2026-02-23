using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTablasCausa
    {
        public List<DPrisionReclusion> prision_reclusion { get; set; }
        public List<DTipoDelito> tipos_delito { get; set; }
        public List<DEstadoProcesal> estado_procesal { get; set; }
        public List<DJurisdiccion> jurisdiccion { get; set; }
        public List<DJuzgado> juzgados { get; set; }
        public List<DReincidencia> reincidencia { get; set; }
        public List<DTipoDefensor> tipos_defensor { get; set; }
    }
}
