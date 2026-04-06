using CapaDatos;
using CapaNegocio;
using CapaPresentacion.DomicilioEditar.Datos;
using CapaPresentacion.DomicilioEditar.Validacion;
using CapaPresentacion.DomicilioNuevo.Datos;
using CapaPresentacion.DomicilioNuevo.Validacion;
using CapaPresentacion.FuncionesGenerales;
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
    public partial class FormDomiclioEditar : Form
    {
        public bool isEditadoDomicilioGlobal { get; private set; }

        int idDomicilioGlobal = 0;
        bool isCargaInicialTerminadaGlobal = false;
        DDomicilioInterno dDomicilioInternoGlobal = new DDomicilioInterno();
        private ErrorProvider errorProvider = new ErrorProvider();
        DTablasDomicilioInterno dTablasDomicilioInternoGlobal = new DTablasDomicilioInterno();


        public FormDomiclioEditar(int idDomicilio)
        {
            this.idDomicilioGlobal = idDomicilio;
            InitializeComponent();
        }
        private async void FormDomiclioEditar_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            txtIdDomicilio.Text = this.idDomicilioGlobal.ToString();
            isEditadoDomicilioGlobal = false;

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

                //carga de datos del dimicilio
                NDomicilioInterno nDomicilioInterno = new NDomicilioInterno();
                gboxDomicilio.Enabled = false;
                (DDomicilioInterno dDomicilio, string errorDomicilioResponse) = await nDomicilioInterno.BuscarxIdDomicilio(this.idDomicilioGlobal);
                this.dDomicilioInternoGlobal = dDomicilio;
                gboxDomicilio.Enabled = true;

                if (this.dDomicilioInternoGlobal == null)
                {
                    MessageBox.Show(errorDomicilioResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //cargar combos para domicilio

                //carga combo pais
                cmbPais.ValueMember = "id_pais";
                cmbPais.DisplayMember = "pais";
                cmbPais.DataSource = dTablasDomicilioInternoGlobal.paises;

                //Carga de combo provincia
                string id_pais = Convert.ToString(this.dDomicilioInternoGlobal.pais_id);
                cmbProvincia.ValueMember = "id_provincia";
                cmbProvincia.DisplayMember = "provincia";
                List<DProvincia> provinciasFiltradas = dTablasDomicilioInternoGlobal.provincias
                        .Where(p => p.pais_id == id_pais)
                        .ToList();
                cmbProvincia.DataSource = provinciasFiltradas;

                //Carga de combo departamentos
                string idProvincia = Convert.ToString(this.dDomicilioInternoGlobal.provincia_id);
                cmbDepartamento.ValueMember = "id_departamento";
                cmbDepartamento.DisplayMember = "departamento";
                List<DDepartamento> departamentosFiltrados = dTablasDomicilioInternoGlobal.departamentos
                        .Where(p => p.provincia_id == idProvincia)
                        .ToList();
                cmbDepartamento.DataSource = departamentosFiltrados;

                //Carga de combo municipios
                string idDepartamento = Convert.ToString(this.dDomicilioInternoGlobal.departamento_id);
                cmbMunicipio.ValueMember = "id_municipio";
                cmbMunicipio.DisplayMember = "municipio";
                List<DMunicipio> municipiosFiltrados = dTablasDomicilioInternoGlobal.municipios
                        .Where(m => m.departamento_id == idDepartamento)
                        .ToList();
                cmbMunicipio.DataSource = municipiosFiltrados;

                //carga combo zona residencia
                cmbZonaResidencia.ValueMember = "id_zona_residencia";
                cmbZonaResidencia.DisplayMember = "zona_residencia";
                cmbZonaResidencia.DataSource = dTablasDomicilioInternoGlobal.zona_residencia;

                this.CargarControlesDomicilio();
                isCargaInicialTerminadaGlobal = true;

            }
            gboxDomicilio.Enabled = true;
            //fin Carga de combos sobre domicilio
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NDomicilioInterno nDomicilioInterno = new NDomicilioInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosformulario = new DomicilioInternoEditarDatos
            {
                cmbPais = cmbPais.SelectedValue?.ToString() ?? string.Empty,
                cmbProvincia = cmbProvincia.SelectedValue?.ToString() ?? string.Empty,
                cmbDepartamento = cmbDepartamento.SelectedValue?.ToString() ?? string.Empty,
                cmbMunicipio = cmbMunicipio.SelectedValue?.ToString() ?? string.Empty,
                txtCiudad = txtCiudad.Text,
                txtBarrio = txtBarrio.Text,
                txtDireccion = txtDireccion.Text,
                txtNumDomicilio = txtNumDomicilio.Text,
                cmbZonaResidencia = cmbZonaResidencia.SelectedValue?.ToString() ?? string.Empty,
                txtTelefono = txtTelefono.Text
            };

            var validator = new DomicilioInternoEditarValidacion();
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

            string dataDomicilioenviar = JsonConvert.SerializeObject(data);

            this.gboxDomicilio.Enabled = false;
            (bool respuestaEditar, string errorResponse) = await nDomicilioInterno.EditarDomicilio(Convert.ToInt32(txtIdDomicilio.Text), dataDomicilioenviar);
            this.gboxDomicilio.Enabled = true;

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isEditadoDomicilioGlobal = true;
                this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                this.Close();

            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
            this.Close();
        }

        private async void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isCargaInicialTerminadaGlobal == false)
            {
                return;
            }

            //Carga de combo provincia
            NProvincia nProvincia = new NProvincia();
            string id_paiss = Convert.ToString(this.cmbPais.SelectedValue);
            cmbProvincia.ValueMember = "id_provincia";
            cmbProvincia.DisplayMember = "provincia";
            (List<DProvincia> listaProvincia, string errorResponseListaProvincia) = await nProvincia.RetornarListaProvinciasXPais(id_paiss);
            cmbProvincia.DataSource = listaProvincia;
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isCargaInicialTerminadaGlobal == false)
            {
                return;
            }

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
            if (this.isCargaInicialTerminadaGlobal == false)
            {
                return;
            }

            //Carga de combo municipios
            string idDepartamento = Convert.ToString(this.cmbDepartamento.SelectedValue);
            cmbMunicipio.ValueMember = "id_municipio";
            cmbMunicipio.DisplayMember = "municipio";
            List<DMunicipio> municipiosFiltrados = dTablasDomicilioInternoGlobal.municipios
                    .Where(m => m.departamento_id == idDepartamento)
                    .ToList();
            cmbMunicipio.DataSource = municipiosFiltrados;
        }

        //CARGAR DATOS DE DOMICILIO
        private void CargarControlesDomicilio()
        {
            txtIdDomicilio.Text = this.idDomicilioGlobal.ToString();
            cmbPais.Text = this.dDomicilioInternoGlobal.pais.pais;
            cmbProvincia.Text = this.dDomicilioInternoGlobal.provincia.provincia;
            cmbDepartamento.Text = this.dDomicilioInternoGlobal.departamento.departamento;
            cmbMunicipio.Text = this.dDomicilioInternoGlobal.municipio.municipio;
            txtCiudad.Text = this.dDomicilioInternoGlobal.ciudad;
            txtBarrio.Text = this.dDomicilioInternoGlobal.barrio;
            txtDireccion.Text = this.dDomicilioInternoGlobal.direccion;
            txtNumDomicilio.Text = this.dDomicilioInternoGlobal.numero_dom.ToString();
            cmbZonaResidencia.Text = this.dDomicilioInternoGlobal.zona_residencia.zona_residencia;
            txtTelefono.Text = this.dDomicilioInternoGlobal.telefono;

        }//FIN CARGAR DATOS DE DOMICILIO ......................................

        


    }
}
