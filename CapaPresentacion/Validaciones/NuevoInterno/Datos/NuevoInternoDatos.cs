using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.NuevoInterno.Datos
{
    public class NuevoInternoDatos
    {
        public int id_interno { get; set; }
        public string txtApellido { get; set; }
        public string txtNombre { get; set; }
        public string txtProntuario { get; set; }
        public string txtDni { get; set; }
        public string txtAlias { get; set; }
        public string cmbSexo { get; set; }
        public string txtTalla { get; set; }
        public string cmbPiel { get; set; }
        public string cmbOjosColor { get; set; }
        public string cmbOjosTamanio { get; set; }
        public string cmbNarizForma { get; set; }
        public string cmbNarizTamanio { get; set; }
        public string cmbPeloTipo { get; set; }
        public string cmbPeloColor { get; set; }
        public string cmbNacionalidad { get; set; }
        public string cmbProvinciaNacimiento { get; set; }
        public string cmbDepartamentoNacimiento { get; set; }
        public string txtCiudadNacimiento { get; set; }
        public DateTime dtpFechaNacimiento { get; set; }
        public string cmbEstadoCivil { get; set; }
        public string cmbZonaResidencia { get; set; }
        public string txtTelefono { get; set; }
        public string txtPadre { get; set; }
        public string txtMadre { get; set; }
        public string txtParientes { get; set; }
        public string organismo_id { get; set; }
        
    }
}
