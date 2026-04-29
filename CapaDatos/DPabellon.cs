using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPabellon
    {
        public int id_pabellon { get; set; }
        public string pabellon { get; set; }
        public bool activo { get; set; }
        public string organismo_id { get; set; }
        public DOrganismo organismo { get; set; }

    }
}
