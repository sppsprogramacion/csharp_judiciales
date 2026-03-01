using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.CausaAdministrar.Datos
{
    public class CausaAdministrarDatos
    {
        public int idtxtIdCausa { get; set; }
        public string txtCausa { get; set; }
        public string cmbPrisionReclusion { get; set; }
        public string txtExpediente { get; set; }
        public string cmbTipoDelito { get; set; }
        public string cmbEstadoProcesal { get; set; }
        public string cmbJurisdiccion { get; set; }
        public string cmbJuzgado { get; set; }
        public string cmbOtroJuzgado { get; set; }
        public string cmbReincidencia { get; set; }
        public DateTime dtpFechaUltimaDetencion { get; set; }
        public string cmbTipoDefensor { get; set; }
        public string txtAbogado { get; set; }

        //datos de condena
        public DateTime dtpFechaCondena { get; set; }
        public DateTime dtpFechaCumple { get; set; }
        public string cmbTribunalCondena { get; set; }
        public string txtPenaAnios { get; set; }
        public string txtPenaMeses { get; set; }
        public string txtPenaDias { get; set; }

    }
}
