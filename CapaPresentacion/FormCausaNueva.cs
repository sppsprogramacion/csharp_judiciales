using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.CausaNueva.Datos;
using CapaPresentacion.Validaciones.CausaNueva.Validacion;
using CapaPresentacion.Validaciones.NuevoInterno.Datos;
using CapaPresentacion.Validaciones.NuevoInterno.Validacion;
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
    public partial class FormCausaNueva : Form
    {
        public bool isCreadoCausa { get; private set; }

        int idIngresoGlobal = 0;
        private ErrorProvider errorProvider = new ErrorProvider();

        DTablasCausa tablasCausa = null;

        public FormCausaNueva(int idIngreso)
        {
            this.idIngresoGlobal = idIngreso;

            InitializeComponent();
        }

        private async void FormCausaNueva_Load(object sender, EventArgs e)
        {
            txtIdIngreso.Text = this.idIngresoGlobal.ToString();
            groupNueva.Enabled = false;

            //Carga de combos sobre listas para ingreso
            NListasGenerales nListasGenerales = new NListasGenerales();
            (DTablasCausa tablasCausaResponse, string errorResponse) = await nListasGenerales.ListasTablasCausa();
            this.tablasCausa = tablasCausaResponse;

            if (this.tablasCausa == null)
            {
                MessageBox.Show("Advertencia al cargar las listas: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //PRISION RECLUSION
                cmbPrisionReclusion.ValueMember = "id_prision_reclusion";
                cmbPrisionReclusion.DisplayMember = "prision_reclusion";
                cmbPrisionReclusion.DataSource = this.tablasCausa.prision_reclusion;

                //TIPOS DELITO
                cmbTipoDelito.ValueMember = "id_tipo_delito";
                cmbTipoDelito.DisplayMember = "tipo_delito";
                cmbTipoDelito.DataSource = this.tablasCausa.tipos_delito.ToList();

                //ESTADO PROCESAL
                cmbEstadoProcesal.ValueMember = "id_estado_procesal";
                cmbEstadoProcesal.DisplayMember = "estado_procesal";
                cmbEstadoProcesal.DataSource = this.tablasCausa.estado_procesal;

                //JURISDICCION
                cmbJurisdiccion.ValueMember = "id_jurisdiccion";
                cmbJurisdiccion.DisplayMember = "jurisdiccion";
                cmbJurisdiccion.DataSource = this.tablasCausa.jurisdiccion.ToList();

                //JUZGADOS
                cmbJuzgado.ValueMember = "id_juzgado";
                cmbJuzgado.DisplayMember = "juzgado";
                cmbJuzgado.DataSource = this.tablasCausa.juzgados.ToList();

                //OTROS JUZGADOS
                cmbOtroJuzgado.ValueMember = "id_juzgado";
                cmbOtroJuzgado.DisplayMember = "juzgado";
                cmbOtroJuzgado.DataSource = this.tablasCausa.juzgados.ToList();

                //REINCIDENCIA
                cmbReincidencia.ValueMember = "id_reincidencia";
                cmbReincidencia.DisplayMember = "reincidencia";
                cmbReincidencia.DataSource = this.tablasCausa.reincidencia;

                //Tipos defensor
                cmbTipoDefensor.ValueMember = "id_tipo_defensor";
                cmbTipoDefensor.DisplayMember = "tipo_defensor";
                cmbTipoDefensor.DataSource = this.tablasCausa.tipos_defensor;

            }
            //fin Carga de combos sobre  listas para ingreso

            groupNueva.Enabled = true;

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosformulario = new CausaNuevaDatos
            {
                txtCausa = txtCausa.Text,
                cmbPrisionReclusion = cmbPrisionReclusion.SelectedValue?.ToString() ?? string.Empty,
                txtExpediente = txtExpediente.Text,
                cmbTipoDelito = cmbTipoDelito.SelectedValue?.ToString() ?? string.Empty,
                cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
                cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
                cmbJuzgado = cmbJuzgado.SelectedValue?.ToString() ?? string.Empty,
                cmbOtroJuzgado = cmbOtroJuzgado.SelectedValue?.ToString() ?? string.Empty,
                cmbReincidencia = cmbReincidencia.SelectedValue?.ToString() ?? string.Empty,
                cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
                txtAbogado = txtAbogado.Text
            };

            var validator = new CausaNuevaValidation();
            var result = validator.Validate(datosformulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                causa = txtCausa.Text,
                prision_reclusion_id = cmbPrisionReclusion.SelectedValue.ToString(),
                expediente = txtExpediente.Text,
                tipo_delito_id = Convert.ToInt32(cmbTipoDelito.SelectedValue.ToString()),
                estado_procesal_id = cmbEstadoProcesal.SelectedValue.ToString(),
                jurisdiccion_id = cmbJurisdiccion.SelectedValue.ToString(),
                juzgado_id = cmbJuzgado.SelectedValue.ToString(),
                otro_juzgado_id = cmbOtroJuzgado.SelectedValue.ToString(),
                reincidencia_id = cmbReincidencia.SelectedValue.ToString(),
                fecha_ultima_detencion = dtpFechaUltimaDetencion.Value,
                tipo_defensor_id = Convert.ToInt32(cmbTipoDefensor.SelectedValue.ToString()),
                abogado = txtAbogado.Text
            };

            string dataCausa = JsonConvert.SerializeObject(data);

            try
            {
                groupNueva.Enabled = false;
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DCausa causa, string errorCausa) = await nCausa.CrearCausa(dataCausa);
                groupNueva.Enabled = true;
                if (causa != null)
                {

                    MessageBox.Show("Causa creada correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isCreadoCausa = true;
                    this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                    this.Close();
                }
                else
                {

                    MessageBox.Show(errorCausa, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
