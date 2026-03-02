using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DInterno
    {
        public int id_interno { get; set; }
        public string codigo { get; set; }
        public int prontuario { get; set; }
        public int dni { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string alias { get; set; }
        public int sexo_id { get; set; }
        public DSexo sexo { get; set; }
        public string talla { get; set; }
        public string ojos_color_id { get; set; }
        public DOjosColor ojos_color { get; set; }
        public string ojos_tamanio_id { get; set; }
        public DTamanio ojos_tamanio { get; set; }
        public string nariz_tamanio_id { get; set; }
        public DTamanio nariz_tamanio { get; set; }
        public string nariz_forma_id { get; set; }
        public DNarizForma nariz_forma { get; set; }
        public string pelo_tipo_id { get; set; }
        public DPeloTipo pelo_tipo { get; set; }
        public string pelo_color_id { get; set; }
        public DPeloColor pelo_color { get; set; }
        public string piel_id { get; set; }
        public DPiel piel { get; set; }
        public string nacionalidad_id { get; set; }
        public DNacionalidad nacionalidad { get; set; }
        public string provincia_nacimiento_id { get; set; }
        public DProvincia provincia_nacimiento { get; set; }
        public int departamento_nacimiento_id { get; set; }
        public DDepartamento departamento_nacimiento { get; set; }
        public string ciudad { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int estado_civil_id { get; set; }
        public DEstadoCivil estado_civil { get; set; }
        public string zona_residencia_id { get; set; }
        public DZonaResidencia zona_residencia { get; set; }
        public string telefono { get; set; }
        public string padre { get; set; }
        public string madre { get; set; }
        public string parientes { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }        
        public string foto { get; set; }
        public string fotoPI { get; set; }
        public string fotoPD { get; set; }
        public DateTime fecha_carga { get; set; }
        public int usuario_carga_id { get; set; }
        public DUsuario usuario_carga { get; set; }
        public int organismo_carga_id { get; set; }
        public DOrganismo organismo_carga { get; set; }

    }
}
