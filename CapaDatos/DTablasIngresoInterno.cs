using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTablasIngresoInterno
    {
        public List<DOrganismoExterno> organismos_externos { get; set; }
        public List<DOrganismo> organismos_spps { get; set; }
        public List<DJurisdiccion> jurisdiccion { get; set; }
        public List<DEstadoProcesal> estado_procesal { get; set; }
        public List<DReingreso> reingreso { get; set; }
    }
}
