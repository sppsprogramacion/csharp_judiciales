using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.CausaNueva.Datos;
using CapaPresentacion.Validaciones.CausaNueva.Validacion;
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
    public partial class FormDomicilioNuevo : Form
    {
        public bool isCreadoDomicilioGlobal { get; private set; }

        int idInternoGlobal = 0;
        private ErrorProvider errorProvider = new ErrorProvider();
        DTablasDomicilioInterno dTablasDomicilioInternoGlobal = new DTablasDomicilioInterno();

        List<DProvincia> listaProvinciaGlobal = new List<DProvincia>();
        public FormDomicilioNuevo(int idInterno)
        {
            this.idInternoGlobal = idInterno;
            InitializeComponent();
        }

        private async  void FormDomicilioNuevo_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            txtIdInterno.Text = this.idInternoGlobal.ToString();
            isCreadoDomicilioGlobal = false;

            gboxDomicilio.Enabled = false;
            //Carga de combos sobre domicilio
            NListasGenerales nListasGenerales = new NListasGenerales();
            (DTablasDomicilioInterno dTablasDomicilioInterno, string errorResponseDomicilio) = await nListasGenerales.ListasTablasDomicilioInterno();

            if (dTablasDomicilioInterno == null)
            {
                MessageBox.Show("Advertencia al cargar los datos para domicilio del interno: " + errorResponseDomicilio, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                dTablasDomicilioInternoGlobal = dTablasDomicilioInterno;

                cmbPais.ValueMember = "id_pais";
                cmbPais.DisplayMember = "pais";
                cmbPais.DataSource = dTablasDomicilioInternoGlobal.paises;

                cmbZonaResidencia.ValueMember = "id_zona_residencia";
                cmbZonaResidencia.DisplayMember = "zona_residencia";
                cmbZonaResidencia.DataSource = dTablasDomicilioInternoGlobal.zona_residencia;

            }
            gboxDomicilio.Enabled = true;
            //fin Carga de combos sobre domicilio
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NDomicilioInterno nDomicilio = new NDomicilioInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            //var datosformulario = new CausaNuevaDatos
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

            //var validator = new CausaNuevaValidation();
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
                interno_id = Convert.ToInt32(txtIdInterno.Text),
                pais_id = cmbPais.SelectedValue.ToString(),
                provincia_id = cmbProvincia.SelectedValue.ToString(),
                departamento_id = Convert.ToInt32(cmbDepartamento.SelectedValue.ToString()),
                municipio_id = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString()),
                ciudad = txtCiudad.Text,
                barrio = txtBarrio.Text,
                direccion = txtDireccion.Text,
                numero_dom = Convert.ToInt32(txtNumDomicilio.Text),
                zona_residencia_id = cmbZonaResidencia.SelectedValue.ToString(),
                telefono = txtTelefono.Text,
            };

            string dataDomicilio = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DDomicilioInterno domicilioResponse, string errorDomicilio) = await nDomicilio.CrearDomicilio(dataDomicilio);

                if (domicilioResponse != null)
                {

                    MessageBox.Show("Domicilio creado correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isCreadoDomicilioGlobal = true;
                    this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                    this.Close();
                }
                else
                {

                    MessageBox.Show(errorDomicilio, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo provincia
            string id_pais = Convert.ToString(this.cmbPais.SelectedValue);
            cmbProvincia.ValueMember = "id_provincia";
            cmbProvincia.DisplayMember = "provincia";
            List<DProvincia> provinciasFiltradas = dTablasDomicilioInternoGlobal.provincias
                    .Where(p => p.pais_id == id_pais)
                    .ToList();
            cmbProvincia.DataSource = provinciasFiltradas;
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo departamentos
            string idProvincia = Convert.ToString(this.cmbProvincia.SelectedValue);
            cmbDepartamento.ValueMember = "id_departamento";
            cmbDepartamento.DisplayMember = "departamento";
            List<DDepartamento> departamentosFiltrados = dTablasDomicilioInternoGlobal.departamentos
                    .Where(p => p.provincia_id == idProvincia)
                    .ToList();
            cmbDepartamento.DataSource = departamentosFiltrados;
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo municipios
            string idDepartamento = Convert.ToString(this.cmbDepartamento.SelectedValue);
            cmbMunicipio.ValueMember = "id_municipio";
            cmbMunicipio.DisplayMember = "municipio";
            List<DMunicipio> municipiosFiltrados = dTablasDomicilioInternoGlobal.municipios
                    .Where(m => m.departamento_id == idDepartamento)
                    .ToList();
            cmbMunicipio.DataSource = municipiosFiltrados;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
            this.Close();
        }

        
    }
    
}
