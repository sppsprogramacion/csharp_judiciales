using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
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
    public partial class FormInternoVer : Form
    {
        //VARIABLES GLOBALES
        private ErrorProvider errorProvider = new ErrorProvider();

        int idInternoGlobal = 0;
        DIngresoInterno ingresoInternoGlobal = new DIngresoInterno();
        DInterno dInternoGlobal = new DInterno();

        public FormInternoVer(DIngresoInterno ingresoInternoX, int idInternoX, string motivo)
        {
            InitializeComponent();
            this.ingresoInternoGlobal = ingresoInternoX;
            this.idInternoGlobal = idInternoX;
        }

        private async void FormInternoVer_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            //CARGAR DATOS DEL INTERNO     
            if (this.ingresoInternoGlobal != null)
            {
                this.dInternoGlobal = this.ingresoInternoGlobal.interno;

                //cargar datos de ingreso
                this.CargarDatosIngreso();
            }
            else
            {
                lblMensajeIngreso.Text = "No se encuentra alojado en el S.P.P.S.";

                //BUSCAR INTERNO CON EL ID PASADO DESDE EL FORMULARIO DE BUSQUEDA (FormInternos)
                NInterno nInterno = new NInterno();   
                
                (DInterno dInternoResponse, string errorInternoResponse) = await nInterno.BuscarInternoXID(this.idInternoGlobal);

                if (dInternoResponse != null)
                {
                    this.dInternoGlobal = dInternoResponse;
                }
                else
                {
                    MessageBox.Show("no se encontró el interno: " + errorInternoResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //CARGAR DATOS DEL INTERNO
            txtIdInterno.Text = this.dInternoGlobal.id_interno.ToString();
            txtApellido.Text = this.dInternoGlobal.apellido;
            txtNombre.Text = this.dInternoGlobal.nombre;
            txtProntuario.Text = this.dInternoGlobal.prontuario.ToString();
            txtDni.Text = this.dInternoGlobal.dni.ToString();
            txtAlias.Text = this.dInternoGlobal.alias;
            txtSexo.Text = this.dInternoGlobal.sexo.sexo;
            txtTalla.Text = this.dInternoGlobal.talla.ToString();
            txtPiel.Text = this.dInternoGlobal.piel.piel;
            txtOjosColor.Text = this.dInternoGlobal.ojos_color.ojo_color;
            txtOjosTamanio.Text = this.dInternoGlobal.ojos_tamanio.tamanio;
            txtNarizForma.Text = this.dInternoGlobal.nariz_forma.nariz_forma;
            txtNarizTamanio.Text = this.dInternoGlobal.nariz_tamanio.tamanio;
            txtPeloTipo.Text = this.dInternoGlobal.pelo_tipo.pelo_tipo;
            txtPeloColor.Text = this.dInternoGlobal.pelo_color.pelo_color;
            txtNacionalidad.Text = this.dInternoGlobal.nacionalidad.nacionalidad;
            txtProvinciaNacimiento.Text = this.dInternoGlobal.provincia_nacimiento.provincia;
            txtDepartamentoNacimiento.Text = this.dInternoGlobal.departamento_nacimiento.departamento;
            dtpFechaNacimiento.Text = this.dInternoGlobal.fecha_nacimiento.ToShortDateString();
            txtEstadoCivil.Text = this.dInternoGlobal.estado_civil.estado_civil;
            txtZonaResidencia.Text = this.dInternoGlobal.zona_residencia.zona_residencia;
            txtTelefono.Text = this.dInternoGlobal.telefono;
            txtPadre.Text = this.dInternoGlobal.padre;
            txtMadre.Text = this.dInternoGlobal.madre;
            txtParientes.Text = this.dInternoGlobal.parientes;

        }

        private async void btnDarIngresar_Click(object sender, EventArgs e)
        {
            //**---cuando el interno esta alojado en otra unidad---**
            if (this.ingresoInternoGlobal != null)
            {
                bool trasladoMiunidad = false;
                //verificar si la unidad tiene autorizacion para ingresar al interno
                //hacer control al API....

                trasladoMiunidad = true;
                //el interno esta alojado en otra unidad y NO tiene autorizacion para ingresarlo a mi unidad
                if (!trasladoMiunidad)
                {
                    MessageBox.Show("El interno ya se encuentra alojado en una unidad", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                                
                //el interno esta alojado en otra unidad y SI tiene autorizacion para ingresarlo a mi unidad
                MessageBox.Show("Tiene autorizacion para ingresar el interno a su unidad", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chkIngresarMiunidad.Checked = true;
                chkIngresarMiunidad.Visible = true;
                lblFechaAlojamientoMiUnidad.Visible = true;
                dtpFechaAlojamientoMiUnidad.Visible = true;
                lblDetalleProcedenciaSpps2.Visible = true;
                txtDetalleProcedenciaSpps2.Visible = true;

                return;
            }

            //**---Cuando el interno no esta alojadoe en una unidad---**
            //Carga de combos sobre listas para ingreso
            DTablasIngresoInterno tablasIngresoInterno = null;

            NListasGenerales nListasGenerales = new NListasGenerales();
            (DTablasIngresoInterno tablasIngresoInternoResponse, string errorResponse) = await nListasGenerales.ListasTablasIngresoInterno();
            tablasIngresoInterno = tablasIngresoInternoResponse;

            if (tablasIngresoInterno == null)
            {
                MessageBox.Show("Advertencia al cargar las listas para el ingreso: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //ORGANISMOS EXTERNOS
                cmbOrganismoExternoProcedencia.ValueMember = "id_organismo_externo";
                cmbOrganismoExternoProcedencia.DisplayMember = "organismo_externo";
                cmbOrganismoExternoProcedencia.DataSource = tablasIngresoInterno.organismos_externos;

                //ORGANISMOS
                cmbOrganismoSppsProcesencia.ValueMember = "id_organismo";
                cmbOrganismoSppsProcesencia.DisplayMember = "organismo";
                cmbOrganismoSppsProcesencia.DataSource = tablasIngresoInterno.organismos_spps.ToList();

                //ESTADO PROCESAL
                cmbEstadoProcesal.ValueMember = "id_estado_procesal";
                cmbEstadoProcesal.DisplayMember = "estado_procesal";
                cmbEstadoProcesal.DataSource = tablasIngresoInterno.estado_procesal;

                //JURISDICCION
                cmbJurisdiccion.ValueMember = "id_jurisdiccion";
                cmbJurisdiccion.DisplayMember = "jurisdiccion";
                cmbJurisdiccion.DataSource = tablasIngresoInterno.jurisdiccion.ToList();

                //OTRA JURISDICCION
                cmbOtraJurisdiccion.ValueMember = "id_jurisdiccion";
                cmbOtraJurisdiccion.DisplayMember = "jurisdiccion";
                cmbOtraJurisdiccion.DataSource = tablasIngresoInterno.jurisdiccion.ToList();

                //REINGRESO
                cmbReingreso.ValueMember = "id_reingreso";
                cmbReingreso.DisplayMember = "reingreso";
                cmbReingreso.DataSource = tablasIngresoInterno.reingreso;

                //Tipos defensor
                cmbTipoDefensor.ValueMember = "id_tipo_defensor";
                cmbTipoDefensor.DisplayMember = "tipo_defensor";
                cmbTipoDefensor.DataSource = tablasIngresoInterno.tipos_defensor;

            }
            //fin Carga de combos sobre  listas para ingreso

            this.HabilitarControlesIngreso(true);
            //cargar datos de ingreso
            //this.CargarDatosIngreso();
        }

        private async void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosformulario = new NuevoIngresoNuevoIntDatos
            {
                cmbOrganismoExternoProcedencia = cmbOrganismoExternoProcedencia.SelectedValue?.ToString() ?? string.Empty,
                txtDetalleProceExterno = txtDetalleProceExterno.Text,
                txtProntuarioPolicial = txtProntuarioPolicial.Text,
                cmbOrganismoSppsProcesencia = cmbOrganismoSppsProcesencia.SelectedValue?.ToString() ?? string.Empty,
                txtDetalleProceSpps = txtDetalleProceSpps.Text,
                cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
                cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
                cmbOtraJurisdiccion = cmbOtraJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
                cmbReingreso = cmbReingreso.SelectedValue?.ToString() ?? string.Empty,
                txtNumeroReingreso = txtNumeroReingreso.Text,
                cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
                txtAbogado = txtAbogado.Text,
            };

            var validator = new CrearIngresoNuevoIntValidation();
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
                interno_id = Convert.ToInt32(txtIdInterno.Text),
                fecha_primer_ingreso = dtpFechaIngresoSpps.Value,
                organismo_externo_id = Convert.ToInt32(cmbOrganismoExternoProcedencia.SelectedValue.ToString()),
                obs_organismo_externo = txtDetalleProceExterno.Text,
                organismo_procedencia_id = Convert.ToInt32(cmbOrganismoSppsProcesencia.SelectedValue.ToString()),
                obs_organismo_procedencia = txtDetalleProceSpps.Text,
                fecha_alojamiento = dtpFechaAlojamiento.Value,
                estado_procesal_id = cmbEstadoProcesal.SelectedValue.ToString(),
                jurisdiccion_id = cmbJurisdiccion.SelectedValue.ToString(),
                otra_jurisdiccion_id = cmbOtraJurisdiccion.SelectedValue.ToString(),
                reingreso_id = Convert.ToInt32(cmbReingreso.SelectedValue.ToString()),
                numero_reingreso = Convert.ToInt32(txtNumeroReingreso.Text),
                prontuario_policial = txtProntuarioPolicial.Text,
                tipo_defensor_id = Convert.ToInt32(cmbTipoDefensor.SelectedValue.ToString()),
                abogado = txtAbogado.Text

            };

            string dataIngreso = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DIngresoInterno ingreso, string errorIngreso) = await nIngreso.CrearIngreso(dataIngreso);


                if (ingreso != null)
                {

                    MessageBox.Show("Ingreso creado correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.HabilitarControlesIngreso(false);                    
                }
                else
                {

                    MessageBox.Show(errorIngreso, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //CARGAR DATOS DE INGRESO
        private void CargarDatosIngreso()
        {
            //cargar datos de ingreso
            lblMensajeIngreso.Text = "Alojado en: " + this.ingresoInternoGlobal.organismo_alojamiento.organismo;
            cmbOrganismoExternoProcedencia.Text = ingresoInternoGlobal.organismo_externo.organismo_externo.ToString();
            txtDetalleProceExterno.Text = ingresoInternoGlobal.obs_organismo_externo;
            dtpFechaIngresoSpps.Text = this.ingresoInternoGlobal.fecha_primer_ingreso.ToShortDateString();
            cmbOrganismoSppsProcesencia.Text = ingresoInternoGlobal.organismo_procedencia.organismo.ToString();
            txtDetalleProceSpps.Text = this.ingresoInternoGlobal.obs_organismo_procedencia;
            txtProntuarioPolicial.Text = this.ingresoInternoGlobal.prontuario_policial.ToString();
            cmbEstadoProcesal.Text = this.ingresoInternoGlobal.estado_procesal.estado_procesal;
            cmbJurisdiccion.Text = this.ingresoInternoGlobal.jurisdiccion.jurisdiccion;
            cmbOtraJurisdiccion.Text = this.ingresoInternoGlobal.otra_jurisdiccion.jurisdiccion;
            cmbReingreso.Text = this.ingresoInternoGlobal.reingreso.reingreso;
            txtNumeroReingreso.Text = this.ingresoInternoGlobal.numero_reingreso.ToString();
            dtpFechaAlojamiento.Text = this.ingresoInternoGlobal.fecha_alojamiento.ToShortDateString();
            cmbTipoDefensor.Text = this.ingresoInternoGlobal.tipo_defensor.tipo_defensor;
            txtAbogado.Text = this.ingresoInternoGlobal.abogado;
        }
        //FIN CARGAR DATOS DE INGRESO

        //HABILITAR CONTROLES INGRESO
        private void HabilitarControlesIngreso(bool valor)
        {
            cmbOrganismoExternoProcedencia.Enabled = valor;
            txtDetalleProceExterno.Enabled = valor;
            cmbOrganismoSppsProcesencia.Enabled = valor;
            txtDetalleProceSpps.Enabled = valor;
            txtProntuarioPolicial.Enabled = valor;
            cmbEstadoProcesal.Enabled = valor;
            cmbJurisdiccion.Enabled = valor;
            cmbOtraJurisdiccion.Enabled = valor;
            cmbReingreso.Enabled = valor;
            txtNumeroReingreso.Enabled = valor;
            dtpFechaAlojamiento.Enabled = valor;
            cmbTipoDefensor.Enabled = valor;
            txtAbogado.Enabled = valor;
        }//FIN HABILITAR CONTROLES INGRESO...........................................

        private void btnCancelarIngreso_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesIngreso(false);
        }
        
    }
}
