using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.CausaNueva.Datos;
using CapaPresentacion.Validaciones.CausaNueva.Validacion;
using CapaPresentacion.Validaciones.HistorialProcesalNuevo.Datos;
using CapaPresentacion.Validaciones.HistorialProcesalNuevo.Validacion;
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
    public partial class FormHistorialProcesalNuevo : Form
    {
        public bool isCreadoHistorialGlobal { get; private set; }

        int idIngresoGlobal = 0;
        private ErrorProvider errorProvider = new ErrorProvider();

        public FormHistorialProcesalNuevo(int idIngreso)
        {
            this.idIngresoGlobal = idIngreso;

            InitializeComponent();
        }

        private async void FormHistorialProcesalNuevo_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            txtIdIngreso.Text = this.idIngresoGlobal.ToString();
            isCreadoHistorialGlobal = false;

            gboxDatosHistorial.Enabled = false;
            //Carga de combos sobre Historial Procesal
            NListasGenerales nListasGenerales = new NListasGenerales();
            (DTablasHistorialProcesal tablasHistorialProcesalResponse, string errorResponseHistorialProcesal) = await nListasGenerales.ListasTablasHistorialProcesal();
            
            if (tablasHistorialProcesalResponse == null)
            {
                MessageBox.Show("Advertencia al cargar los datos para historial procesal: " + errorResponseHistorialProcesal, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                cmbTipoNovedad.ValueMember = "id_tipo_historial_procesal";
                cmbTipoNovedad.DisplayMember = "tipo_historial_procesal";
                cmbTipoNovedad.DataSource = tablasHistorialProcesalResponse.tipos_historial_procesal;

            }
            gboxDatosHistorial.Enabled = true;
            //fin Carga de combos sobre Historial Procesal
        }

        private async void btnGuardarHistorial_Click(object sender, EventArgs e)
        {
            NHistorialPRocesal nHistorialPRocesal = new NHistorialPRocesal();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosformulario = new HistorialProcesalNuevoDatos
            {
                cmbTipoNovedad = cmbTipoNovedad.SelectedValue?.ToString() ?? string.Empty,
                txtDetalleNovedad = txtDetalleNovedad.Text,
                
            };

            var validator = new HistorialProcesalNuevoValidation();
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
                ingreso_interno_id = Convert.ToInt32(txtIdIngreso.Text),
                tipo_historial_procesal_id = Convert.ToInt32(cmbTipoNovedad.SelectedValue.ToString()),
                fecha = dtpFechaNovedad.Value,
                detalle = txtDetalleNovedad.Text,                
            };

            string dataHistorial = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DHistorialProcesal historialResponse, string errorHistorialResponse) = await nHistorialPRocesal.CrearHistorial(dataHistorial);

                if (historialResponse != null)
                {

                    MessageBox.Show("Historial creado correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isCreadoHistorialGlobal = true;
                    this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                    this.Close();
                }
                else
                {

                    MessageBox.Show(errorHistorialResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelarHistorial_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
            this.Close();
        }
    }
}
