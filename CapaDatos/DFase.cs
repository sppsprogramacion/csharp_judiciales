using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DFase
    {
        public int id_fase { get; set; }
        public string fase { get; set; }
        public bool activo { get; set; }
        public string progresividad_id { get; set; }
        public DProgresividad Progresividad { get; set; }

    }
}
