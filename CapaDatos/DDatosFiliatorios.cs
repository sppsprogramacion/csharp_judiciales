using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDatosFiliatorios
    {
        public List<DEstadoCivil> estado_civil { get; set; }
        public List<DNacionalidad> nacionalidad { get; set; }
        public List<DNivelEducacion> niveles_educacion { get; set; }
        public List<DOcupacion> ocupaciones { get; set; }
        public List<DReligion> religiones { get; set; }

    }
}
