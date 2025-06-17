using CapaDatos;
using CapaNegocio;
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
    public partial class FormInternos : Form
    {
        public FormInternos()
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

        private async void btnBuscarApellido_Click(object sender, EventArgs e)
        {

            NInterno nInterno = new NInterno();
            (List<DInterno> listaInternos, string errorResponse) = await nInterno.ListaInternosXApellido(txtApellidoBusqueda.Text);

            if (listaInternos == null)
            {
                MessageBox.Show(errorResponse, "Internos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaInternos
                .Select(c => new
                {
                    ID = c.id_interno,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    Prontuario = c.prontuario,
                    Sexo = c.sexo.sexo
                    
                })
                .ToList();

            dtgvInternos.DataSource = datosFiltrados;

            if (listaInternos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvInternos.Columns[0].Width = 90;
                dtgvInternos.Columns[1].Width = 200;
                dtgvInternos.Columns[2].Width = 200;
                dtgvInternos.Columns[3].Width = 90;
                dtgvInternos.Columns[4].Width = 90;
            }
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
            btnBuscarApellido.Enabled = !habilitar;
        }

        //FIN HABILITAR CONTROLES...............................................
    }

}
