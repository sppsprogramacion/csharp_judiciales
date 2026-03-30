using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDomicilioInterno
    {
        public int id_domicilio_interno { get; set; }
        public int interno_id { get; set; }
        public DInterno interno { get; set; }
        public string pais_id { get; set; }
        public DPais pais { get; set; }
        public string provincia_id { get; set; }
        public DProvincia provincia { get; set; }
        public int departamento_id { get; set; }
        public DDepartamento departamento { get; set; }
        public int municipio_id { get; set; }
        public DMunicipio municipio { get; set; }
        public string ciudad { get; set; }
        public string barrio { get; set; }
        public string direccion { get; set; }
        public int numero_dom { get; set; }
        public bool vigente { get; set; }
        public bool is_eliminado { get; set; }
        public string detalle_eliminado { get; set; }
        public DateTime fecha_carga { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
    }
}
