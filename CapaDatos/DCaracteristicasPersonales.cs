using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCaracteristicasPersonales
    {
        public List<DOjosColor> ojos_color { get; set; }
        public List<DNarizForma> nariz_forma { get; set; }
        public List<DPeloTipo> pelo_tipo { get; set; }
        public List<DPeloColor> pelo_color { get; set; }
        public List<DPiel> piel { get; set; }
        public List<DTamanio> tamanio { get; set; }
    }
}
