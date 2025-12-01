using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.TrasladoNuevo.Datos;
using CapaPresentacion.Validaciones.TrasladoNuevo.Validacion;
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
    public partial class FormTrasladoNuevo : Form
    {
        int idIngresoGlobal=0;
        private ErrorProvider errorProvider = new ErrorProvider();
        public FormTrasladoNuevo(int idIngreso)
        {
            this.idIngresoGlobal = idIngreso;

            InitializeComponent();
        }

        private async void FormTrasladoNuevo_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            txtIdIngreso.Text = this.idIngresoGlobal.ToString();
            //Carga de combos sobre listas
            DTablasIngresoInterno tablasIngresoInterno = null;

            NListasGenerales nListasGenerales = new NListasGenerales();
            (DTablasIngresoInterno tablasIngresoInternoResponse, string errorResponse) = await nListasGenerales.ListasTablasIngresoInterno();
            tablasIngresoInterno = tablasIngresoInternoResponse;

            if (tablasIngresoInterno == null)
            {
                MessageBox.Show("Advertencia al cargar las lista de organismos: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {                
                //ORGANISMOS
                cmbOrganismoDestino.ValueMember = "id_organismo";
                cmbOrganismoDestino.DisplayMember = "organismo";
                cmbOrganismoDestino.DataSource = tablasIngresoInterno.organismos_spps.ToList();

            }
            //fin Carga de combos sobre  listas para ingreso
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {

            NTrasladoInterno nTraslado = new NTrasladoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new TrasladoNuevoDatos
            {
                txtIdIngreso = txtIdIngreso.Text,
                dtpFechaEgreso = dtpFechaEgreso.Value,
                txtDetalleTraslado = txtDetalleTraslado.Text,
                cmbOrganismoDestino = cmbOrganismoDestino.SelectedValue?.ToString() ?? string.Empty,
                
            };

            var validator = new CrearTrasladoValidacion();
            var result = validator.Validate(datosFormulario);

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
                fecha_egreso_origen = dtpFechaEgreso.Value,
                detalle_traslado = txtDetalleTraslado.Text,
                organismo_destino_id = Convert.ToInt32(cmbOrganismoDestino.SelectedValue.ToString())
            };

            string dataTraslado = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DTrasladoInterno traslado, string errorTraslado) = await nTraslado.CrearTraslado(dataTraslado);

                if (traslado != null)
                {

                    MessageBox.Show("Traslado creado correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {

                    MessageBox.Show(errorTraslado, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
