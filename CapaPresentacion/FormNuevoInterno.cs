using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormNuevoInterno : Form
    {
        public FormNuevoInterno()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesNuevo(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesNuevo(false);
        }

        //HABILITAR CONTROLES
        private void HabilitarControlesNuevo(bool habilitar)
        {
            txtApellido.Enabled = habilitar;
            txtApellido.Text = "";
            txtNombre.Enabled = habilitar;
            txtNombre.Text = "";
            txtProntuario.Enabled = habilitar;
            txtProntuario.Text = "";
            txtDni.Enabled = habilitar;
            txtDni.Text = "";
            cmbSexo.Enabled = habilitar;
            dtpFechaNscimiento.Enabled = habilitar;
            dtpFechaNscimiento.ResetText();
            txtTelefono.Enabled = habilitar;
            txtTelefono.Text = "";
            cmbEstadoCivil.Enabled = habilitar;
            cmbNacionalidad.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        //FIN HABILITAR CONTROLES...............................................
    }
}
