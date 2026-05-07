using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTablasConductaConcepto
    {
        public List<DTrimestre> trimestres { get; set; }
        public List<DConducta> conducta { get; set; }
        public List<DConcepto> concepto { get; set; }
    }
}
