using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTablasDomicilioInterno
    {
        public List<DPais> paises { get; set; }
        public List<DProvincia> provincias { get; set; }
        public List<DDepartamento> departamentos { get; set; }
        public List<DMunicipio> municipios { get; set; }
        public List<DZonaResidencia> zona_residencia { get; set; }
    }
}
