using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.CausaAdministrar.Datos;
using CapaPresentacion.Validaciones.CausaAdministrar.Validacon;
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

            //Carga de combos sobre Historial Procesal
            NListasGenerales nListasGenerales = new NListasGenerales();
            (DTablasHistorialProcesal tablasHistorialProcesalResponse, string errorResponseHistorialProcesal) = await nListasGenerales.ListasTablasHistorialProcesal();

            isModificadoHistorialGlobal = false;

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
            cmbTipoNovedad.Text = this.dHistorialProcesalGlobal.tipo_historial_procesal.tipo_historial_procesal;
            txtDetalleNovedad.Text = this.dHistorialProcesalGlobal.detalle;

        }//FIN CARGAR DATOS DE HISTORIAL ......................................

        private void btnCancelarHistorial_Click(object sender, EventArgs e)
        {
            this.CargarControlesHistorial();
        }

        private async void btnGuardarHistorial_Click(object sender, EventArgs e)
        {
            NHistorialPRocesal nHistorialPRocesal = new NHistorialPRocesal();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            //var datosformulario = new CausaAdministrarDatos
            //{
            //    txtCausa = txtCausa.Text,
            //    cmbPrisionReclusion = cmbPrisionReclusion.SelectedValue?.ToString() ?? string.Empty,
            //    txtExpediente = txtExpediente.Text,
            //    cmbTipoDelito = cmbTipoDelito.SelectedValue?.ToString() ?? string.Empty,
            //    cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
            //    cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbJuzgado = cmbJuzgado.SelectedValue?.ToString() ?? string.Empty,
            //    cmbOtroJuzgado = cmbOtroJuzgado.SelectedValue?.ToString() ?? string.Empty,
            //    cmbReincidencia = cmbReincidencia.SelectedValue?.ToString() ?? string.Empty,
            //    cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
            //    txtAbogado = txtAbogado.Text
            //};

            //var validator = new CausaEditarDatosGeneralesValidation();
            //var result = validator.Validate(datosformulario);

            //if (!result.IsValid)
            //{
            //    MessageBox.Show("Complete correctamente los campos del formulario", "judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    foreach (var failure in result.Errors)
            //    {
            //        Control control = Controls.Find(failure.PropertyName, true)[0];
            //        errorProvider.SetError(control, failure.ErrorMessage);
            //    }
            //    return;
            //}
            //fin validar formulario

            var data = new
            {
                tipo_historial_procesal_id = Convert.ToInt32(cmbTipoNovedad.SelectedValue.ToString()),
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
    }
}
