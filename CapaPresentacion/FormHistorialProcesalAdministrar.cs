using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.CausaAdministrar.Datos;
using CapaPresentacion.Validaciones.CausaAdministrar.Validacon;
using CapaPresentacion.Validaciones.HistorialProcesalAdministrar.Datos;
using CapaPresentacion.Validaciones.HistorialProcesalAdministrar.Validacion;
using Newtonsoft.Json;
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
    public partial class FormHistorialProcesalAdministrar : Form
    {
        public bool isModificadoHistorialGlobal { get; private set; }

        int idHistorialGlobal = 0;
        DHistorialProcesal dHistorialProcesalGlobal = new DHistorialProcesal();
        private ErrorProvider errorProvider = new ErrorProvider();

        public FormHistorialProcesalAdministrar(int idHistorial)
        {
            InitializeComponent();
            idHistorialGlobal = idHistorial;
        }

        private async void FormHistorialProcesalAdministrar_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            

            //carga de datos del historial
            NHistorialPRocesal nHistorialPRocesal = new NHistorialPRocesal();
            gboxDatosHistorial.Enabled = false;
            (DHistorialProcesal dHistorialProcesalX, string errorHistorialResponse) = await nHistorialPRocesal.BuscarxIdHistorial(this.idHistorialGlobal);
            this.dHistorialProcesalGlobal = dHistorialProcesalX;
            gboxDatosHistorial.Enabled = true;

            if (this.dHistorialProcesalGlobal == null)
            {
                MessageBox.Show(errorHistorialResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.CargarControlesHistorial();

        }


        //CARGAR DATOS DE HISTORIAL
        private void CargarControlesHistorial()
        {
            txtIdHistorial.Text = this.idHistorialGlobal.ToString();
            txtUsuarioCarga.Text = this.dHistorialProcesalGlobal.usuario.apellido + " " + this.dHistorialProcesalGlobal.usuario.nombre;
            txtOrganismoCarga.Text = this.dHistorialProcesalGlobal.organismo.organismo;
            txtFechaCarga.Text = this.dHistorialProcesalGlobal.fecha_carga.ToString();

            //datos generales
            dtpFechaNovedad.Text = this.dHistorialProcesalGlobal.fecha.ToShortDateString();
            txtMotivo.Text = this.dHistorialProcesalGlobal.motivo.ToString();
            txtTipoNovedad.Text = this.dHistorialProcesalGlobal.tipo_historial_procesal.tipo_historial_procesal;
            txtDetalleNovedad.Text = this.dHistorialProcesalGlobal.detalle;

        }//FIN CARGAR DATOS DE HISTORIAL ......................................

        private void btnCancelarHistorial_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
            this.Close();
            //this.CargarControlesHistorial();
        }

        private async void btnGuardarHistorial_Click(object sender, EventArgs e)
        {
            NHistorialPRocesal nHistorialPRocesal = new NHistorialPRocesal();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosformulario = new HistorialProcesalAdministrarDatos
            {
                //cmbTipoNovedad = cmbTipoNovedad.SelectedValue?.ToString() ?? string.Empty,
                txtDetalleNovedad = txtDetalleNovedad.Text,
                
            };

            var validator = new HistorialProcesalAdministrarValidation();
            var result = validator.Validate(datosformulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {
                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validar formulario

            var data = new
            {
                
                fecha = dtpFechaNovedad.Value,
                detalle = txtDetalleNovedad.Text,
            };

            string dataHistorialEnviar = JsonConvert.SerializeObject(data);

            this.gboxDatosHistorial.Enabled = false;
            (bool respuestaEditar, string errorResponse) = await nHistorialPRocesal.EditarHistorial(Convert.ToInt32(txtIdHistorial.Text), dataHistorialEnviar);
            this.gboxDatosHistorial.Enabled = true;

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isModificadoHistorialGlobal = true;
                this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                this.Close();

            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gboxDatosHistorial_Enter(object sender, EventArgs e)
        {

        }
    }
}
