using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.InternoVer.Datos
{
    public class NuevoIngresoInternoVerDatos
    {
        public int id_interno { get; set; }
        public string cmbOrganismoExternoProcedencia { get; set; }
        public string txtDetalleProceExterno { get; set; }
        public DateTime dtpFechaPrimerIngreso { get; set; }
        public string txtProntuarioPolicial { get; set; }
        public string cmbOrganismoSppsProcesencia { get; set; }
        public string txtDetalleProceSpps { get; set; }
        public string cmbEstadoProcesal { get; set; }
        public string cmbJurisdiccion { get; set; }
        public string cmbOtraJurisdiccion { get; set; }
        public string cmbReingreso { get; set; }
        public string txtNumeroReingreso { get; set; }
        public DateTime dtpFechaAlojamiento { get; set; }
        public string cmbTipoDefensor { get; set; }
        public string txtAbogado { get; set; }
    }
}
