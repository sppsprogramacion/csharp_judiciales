using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.InternoAdministrar.Datos;
using CapaPresentacion.Validaciones.InternoAdministrar.Validacion;
using CommonCache;
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
    public partial class FormInternoAdministrar : Form
    {
        //VARIABLES GLOBALES
        private ErrorProvider errorProvider = new ErrorProvider();
        DInterno dInternoGlobal = new DInterno();
        DIngresoInterno ingresoInternoGlobal = new DIngresoInterno();
        DCaracteristicasPersonales tablasCaracteristicasPersonalesGlogal = null;
        DDatosFiliatorios  tablasDatosFiliatoriosGlobal = null;

        public FormInternoAdministrar(DIngresoInterno ingresoInternox)
        {

            InitializeComponent();
            this.ingresoInternoGlobal = ingresoInternox;
        }

        private async void FormInternoAdministrar_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            

            //CARGAR DATOS DEL INTERNO  
            tabInterno.Enabled = false;
            
            this.dInternoGlobal = this.ingresoInternoGlobal.interno;

            if (this.dInternoGlobal == null)
            {
                tabInterno.Enabled = false;

                MessageBox.Show("No se encontro informaciòn del interno solicitado", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //datos de ingreso en pestaña DATOS PRINCIPALES
            txtIdIngresoVer.Text = this.ingresoInternoGlobal.id_ingreso_interno.ToString();
            txtReingresoVer.Text = this.ingresoInternoGlobal.reingreso.reingreso;
            txtNumReingresoVer.Text = this.ingresoInternoGlobal.numero_reingreso.ToString();
            txtOrganismoAlojamientoVer.Text = this.ingresoInternoGlobal.organismo_alojamiento.organismo;
            dtpFechaAlojamientoVer.Text = this.ingresoInternoGlobal.fecha_alojamiento.ToShortDateString();
            txtEstadoProcesalVer.Text = this.ingresoInternoGlobal.estado_procesal.estado_procesal;
            txtJurisdiccionVer.Text = this.ingresoInternoGlobal.jurisdiccion.jurisdiccion;

            //cargar datos del interno
            this.CargarControlesInformacionInterno();
            //cargar fotos del interno
            if (!string.IsNullOrEmpty(this.dInternoGlobal.foto))
            {
                pictureFoto.Load(this.dInternoGlobal.foto);
            }
            if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPI))
            {
                pictureFotoPI.Load(this.dInternoGlobal.fotoPI);
            }
            if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPD))
            {
                pictureFotoPD.Load(this.dInternoGlobal.fotoPD);
            }

            //txtFechaAlta.Text = this.dCiudadanoGlo.fecha_alta.ToShortDateString();
            //txtOrganismoAlta.Text = this.dCiudadanoGlo.organismo_alta.organismo;
            //pictureFoto.Load(this.dCiudadanoGlo.foto);

            tabInterno.Enabled = true;


            //cargar datos de ingreso en pestaña DATOS DE INGRESO           
            this.CargarControlesIngreso();
        }
                

        //CARGAR CONTROLES DATOS DE INTERNO
        private void CargarControlesInformacionInterno()
        {
            //CARGAR DATOS DEL INTERNO
            txtIdInterno.Text = this.dInternoGlobal.id_interno.ToString();
            txtApellido.Text = this.dInternoGlobal.apellido;
            txtNombre.Text = this.dInternoGlobal.nombre;
            txtProntuario.Text = this.dInternoGlobal.prontuario.ToString();
            txtDni.Text = this.dInternoGlobal.dni.ToString();
            txtAlias.Text = this.dInternoGlobal.alias;
            cmbSexo.Text = this.dInternoGlobal.sexo.sexo;
            txtTalla.Text = this.dInternoGlobal.talla.ToString();
            cmbPiel.Text = this.dInternoGlobal.piel.piel;
            cmbOjosColor.Text = this.dInternoGlobal.ojos_color.ojo_color;
            cmbOjosTamanio.Text = this.dInternoGlobal.ojos_tamanio.tamanio;
            cmbNarizForma.Text = this.dInternoGlobal.nariz_forma.nariz_forma;
            cmbNarizTamanio.Text = this.dInternoGlobal.nariz_tamanio.tamanio;
            cmbPeloTipo.Text = this.dInternoGlobal.pelo_tipo.pelo_tipo;
            cmbPeloColor.Text = this.dInternoGlobal.pelo_color.pelo_color;
            cmbNacionalidad.Text = this.dInternoGlobal.nacionalidad.nacionalidad;
            cmbProvinciaNacimiento.Text = this.dInternoGlobal.provincia_nacimiento.provincia;
            cmbDepartamentoNacimiento.Text = this.dInternoGlobal.departamento_nacimiento.departamento;
            txtCiudadNacimiento.Text = this.dInternoGlobal.ciudad;
            dtpFechaNacimiento.Text = this.dInternoGlobal.fecha_nacimiento.ToShortDateString();
            cmbEstadoCivil.Text = this.dInternoGlobal.estado_civil.estado_civil;
            cmbNivelEducacion.Text = this.dInternoGlobal.nivel_educacion.nivel_educacion;
            cmbReligion.Text = this.dInternoGlobal.religion.religion;
            cmbUltimaOcupacion.Text = this.dInternoGlobal.ocupacion.ocupacion;
            txtProfesion.Text = this.dInternoGlobal.profesion;
            txtPadre.Text = this.dInternoGlobal.padre;
            txtMadre.Text = this.dInternoGlobal.madre;
            txtParientes.Text = this.dInternoGlobal.parientes;

            //if (!string.IsNullOrEmpty(this.dInternoGlobal.foto))
            //{
            //    pictureFoto.Load(this.dInternoGlobal.foto);
            //}
            //if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPI))
            //{
            //    pictureFotoPI.Load(this.dInternoGlobal.fotoPI);
            //}
            //if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPD))
            //{
            //    pictureFotoPD.Load(this.dInternoGlobal.fotoPD);
            //}
        }
        //FIN CARGAR CONTROLES DATOS DE INTERNO...................................................

        //CARGAR DATOS DE INGRESO EN PESTAÑA DATOS DE INGRESO, EGRESO, PROGRESIVIDAD
        private void CargarControlesIngreso()
        {
            cmbOrganismoExternoProcedencia.Text = ingresoInternoGlobal.organismo_externo.organismo_externo.ToString();
            txtDetalleProceExterno.Text = ingresoInternoGlobal.obs_organismo_externo;
            dtpFechaIngresoSpps.Value = this.ingresoInternoGlobal.fecha_primer_ingreso;
            cmbOrganismoSppsProcesencia.Text = ingresoInternoGlobal.organismo_procedencia.organismo.ToString();
            txtProntuarioPolicial.Text = this.ingresoInternoGlobal.prontuario_policial.ToString();
            txtDetalleProceSpps.Text = this.ingresoInternoGlobal.obs_organismo_procedencia;
            cmbEstadoProcesal.Text = this.ingresoInternoGlobal.estado_procesal.estado_procesal;
            cmbJurisdiccion.Text = this.ingresoInternoGlobal.jurisdiccion.jurisdiccion;
            cmbOtraJurisdiccion.Text = this.ingresoInternoGlobal.otra_jurisdiccion.jurisdiccion;
            cmbReingreso.Text = this.ingresoInternoGlobal.reingreso.reingreso;
            txtNumeroReingreso.Text = this.ingresoInternoGlobal.numero_reingreso.ToString();
            dtpFechaAlojamiento.Value = this.ingresoInternoGlobal.fecha_alojamiento;
            cmbTipoDefensor.Text = this.ingresoInternoGlobal.tipo_defensor.tipo_defensor;
            txtAbogado.Text = this.ingresoInternoGlobal.abogado;

            //datos egreso
            this.CargarControlesEgreso();

            //datos alojamiento
            this.CargarControlesAlojamiento();

            //datos progresividad
            this.CargarControlesProgresividad();

            //datos conducta/concepto
            this.CargarControlesConductaConcepto();

        }

        //FIN CARGAR DATOS DE INGRESO EN PESTAÑA DATOS DE INGRESO......................................

        //CARGAR DATOS DE EGRESO EN PESTAÑA EGRESOS
        private void CargarControlesEgreso()
        {
            //datos egreso
            dtpFechaEgreso.Text = this.ingresoInternoGlobal.fecha_egreso?.ToShortDateString();
            cmbMotivoEgreso.Text = this.ingresoInternoGlobal.motivo_egreso.motivo_egreso;
            cmbJuzgadoLibera.Text = this.ingresoInternoGlobal.juzgado_libera.juzgado;
            txtDomicilioLibertad.Text = this.ingresoInternoGlobal.domicilio_libertad;
            txtDetallesEgreso.Text = this.ingresoInternoGlobal.detalles_egreso;

        }
        //FIN CARGAR DATOS DE EGRESO EN PESTAÑA EGRESOS......................................

        //CARGAR DATOS DE PROGRESIVIDAD EN PESTAÑA PROGRESIVIDAD
        private void CargarControlesProgresividad()
        {
            
            //datos progresividad
            cmbProgresividad.Text = this.ingresoInternoGlobal.progresividad.progresividad;
            cmbFase.Text = this.ingresoInternoGlobal.fase.fase;
            chkExtramuro.Checked = this.ingresoInternoGlobal.tiene_extramuro;
            chkGranja.Checked = this.ingresoInternoGlobal.tiene_granja;
            chkSemilibertad.Checked = this.ingresoInternoGlobal.tiene_semilibertad;
            chkTransitoria.Checked = this.ingresoInternoGlobal.tiene_transitoria;

        }
        //FIN CARGAR DATOS DE PROGRESIVIDAD EN PESTAÑA PROGRESIVIDAD......................................

        //CARGAR DATOS DE CONDUCTA/CONCEPTO EN PESTAÑA PROGRESIVIDAD
        private void CargarControlesConductaConcepto()
        {
            //datos conducta concepto
            cmbTrimestre.Text = this.ingresoInternoGlobal.trimestre.trimestre;
            cmbConducta.Text = this.ingresoInternoGlobal.conducta.conducta;
            cmbConcepto.Text = this.ingresoInternoGlobal.concepto.concepto;

        }
        //FIN CARGAR DATOS DE ONDUCTA/CONCEPTO EN PESTAÑA PROGRESIVIDAD......................................

        //CARGAR DATOS ALOJAMIENTO
        private void CargarControlesAlojamiento()
        {
            //datos alojamiento
            cmbPabellon.Text = this.ingresoInternoGlobal.pabellon.pabellon;
            txtCelda.Text = this.ingresoInternoGlobal.celda;
            chkProgramaPuerta.Checked = this.ingresoInternoGlobal.tiene_programa_puerta;
            cmbSituacionProvisoria.Text = this.ingresoInternoGlobal.situacion_provisoria.situacion_provisoria;
           
        }
        //FIN CARGAR DATOS ALOJAMIENTO......................................


        //REGION DATOS_PRINCIPALES
        #region DATOS_PRINCIPALES
        private async void btnGuardarEditarDatosPrincipales_Click(object sender, EventArgs e)
        {
            NInterno nInterno = new NInterno();
            string dataEnviar;

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new InternoAdministarDatos
            {
                txtApellido = txtApellido.Text,
                txtNombre = txtNombre.Text,
                txtProntuario = txtProntuario.Text,
                txtDni = txtDni.Text,
                txtAlias = txtAlias.Text
            };

            var validator = new InternoEditarDatosPrincipalesValidation();
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

            this.tabInterno.Enabled = false;
            var dataInterno = new
            {
                prontuario = Convert.ToInt32(txtProntuario.Text),
                dni = Convert.ToInt32(txtDni.Text),
                apellido = txtApellido.Text,
                nombre = txtNombre.Text,
                alias = txtAlias.Text,
            };

            dataEnviar = JsonConvert.SerializeObject(dataInterno);

            (bool respuestaEditar, string errorResponse) = await nInterno.EditarDatosPersonales(Convert.ToInt32(txtIdInterno.Text), dataEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("La edición de se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarInterno();             
                this.HabilitarDatosPersonales(false);
                this.tabInterno.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }

        private void btnEditarDatosPrincipales_Click(object sender, EventArgs e)
        {
            this.HabilitarDatosPersonales(true);
            txtProntuario.Focus();
        }

        private void btnCancelarEditarDatosPrincipales_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();
            //cargar datos del interno
            this.CargarControlesInformacionInterno();
            this.HabilitarDatosPersonales(false);
        }

        private async void btnEditarCaracteristicasPersonales_Click(object sender, EventArgs e)
        {
            if (this.tablasCaracteristicasPersonalesGlogal == null)
            {

                tabInterno.Enabled = false;

                //Carga de combos sobre listas para ingreso
                NListasGenerales nListasGenerales = new NListasGenerales();
                (DCaracteristicasPersonales caracteristicasPersonales, string errorResponse) = await nListasGenerales.ListaCaracteristicasPersonales();

                this.tablasCaracteristicasPersonalesGlogal = caracteristicasPersonales;

                tabInterno.Enabled = true;

                if (this.tablasCaracteristicasPersonalesGlogal == null)
                {
                    MessageBox.Show("Advertencia al cargar las listas: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //PIEL
            cmbPiel.ValueMember = "id_piel";
            cmbPiel.DisplayMember = "piel";
            cmbPiel.DataSource = tablasCaracteristicasPersonalesGlogal.piel;

            //OJOS COLOR
            cmbOjosColor.ValueMember = "id_ojo_color";
            cmbOjosColor.DisplayMember = "ojo_color";
            cmbOjosColor.DataSource = tablasCaracteristicasPersonalesGlogal.ojos_color;

            //OJOS TAMAÑO
            cmbOjosTamanio.ValueMember = "id_tamanio";
            cmbOjosTamanio.DisplayMember = "tamanio";
            cmbOjosTamanio.DataSource = tablasCaracteristicasPersonalesGlogal.tamanio;

            //NARIZ FORMA
            cmbNarizForma.ValueMember = "id_nariz_forma";
            cmbNarizForma.DisplayMember = "nariz_forma";
            cmbNarizForma.DataSource = tablasCaracteristicasPersonalesGlogal.nariz_forma;

            //NARIZ TAMAÑO
            cmbNarizTamanio.ValueMember = "id_tamanio";
            cmbNarizTamanio.DisplayMember = "tamanio";
            cmbNarizTamanio.DataSource = tablasCaracteristicasPersonalesGlogal.tamanio;

            //PELO COLOR
            cmbPeloColor.ValueMember = "id_pelo_color";
            cmbPeloColor.DisplayMember = "pelo_color";
            cmbPeloColor.DataSource = tablasCaracteristicasPersonalesGlogal.pelo_color;

            //PELO TIPO
            cmbPeloTipo.ValueMember = "id_pelo_tipo";
            cmbPeloTipo.DisplayMember = "pelo_tipo";
            cmbPeloTipo.DataSource = tablasCaracteristicasPersonalesGlogal.pelo_tipo;

            //SEXO
            cmbSexo.ValueMember = "id_sexo";
            cmbSexo.DisplayMember = "sexo";
            cmbSexo.DataSource = tablasCaracteristicasPersonalesGlogal.sexo;

            //fin Carga de combos sobre Caracteristicas generales

            this.CargarControlesInformacionInterno();
            this.HabilitarCarasteristicasPersonales(true);
            cmbSexo.Focus();
        }

        private async void btnGuardarEditarCaracteristicasPersonales_Click(object sender, EventArgs e)
        {
            NInterno nInterno = new NInterno();
            string dataEnviar;

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new InternoAdministarDatos
            {
                cmbSexo = cmbSexo.SelectedValue?.ToString() ?? string.Empty,
                txtTalla = txtTalla.Text,
                cmbPiel = cmbPiel.SelectedValue?.ToString() ?? string.Empty,
                cmbOjosColor = cmbOjosColor.SelectedValue?.ToString() ?? string.Empty,
                cmbOjosTamanio = cmbOjosTamanio.SelectedValue?.ToString() ?? string.Empty,
                cmbNarizForma = cmbNarizForma.SelectedValue?.ToString() ?? string.Empty,
                cmbNarizTamanio = cmbNarizTamanio.SelectedValue?.ToString() ?? string.Empty,
                cmbPeloTipo = cmbPeloTipo.SelectedValue?.ToString() ?? string.Empty,
                cmbPeloColor = cmbPeloColor.SelectedValue?.ToString() ?? string.Empty,
            };

            var validator = new InternoEditarCaracteristicasPrincipalesValidation();
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

            this.tabInterno.Enabled = false;
            var dataInterno = new
            {
                sexo_id = Convert.ToInt32(cmbSexo.SelectedValue.ToString()),
                talla = txtTalla.Text,
                piel_id = cmbPiel.SelectedValue.ToString(),
                ojos_color_id = cmbOjosColor.SelectedValue.ToString(),
                ojos_tamanio_id = cmbOjosTamanio.SelectedValue.ToString(),
                nariz_forma_id = cmbNarizForma.SelectedValue.ToString(),
                nariz_tamanio_id = cmbNarizTamanio.SelectedValue.ToString(),
                pelo_tipo_id = cmbPeloTipo.SelectedValue.ToString(),
                pelo_color_id = cmbPeloColor.SelectedValue.ToString(),
            };

            dataEnviar = JsonConvert.SerializeObject(dataInterno);

            (bool respuestaEditar, string errorResponse) = await nInterno.EditarCaracteristicasPersonales(Convert.ToInt32(txtIdInterno.Text), dataEnviar);


            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarInterno();
                this.HabilitarCarasteristicasPersonales(false);
                this.tabInterno.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }
        
        private void btnCancelarEditarCaracteristicasPersonales_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();
            //cargar datos del interno
            this.CargarControlesInformacionInterno();
            this.HabilitarCarasteristicasPersonales(false);
        }

        private async void btnEditarDatosFilatorios_Click(object sender, EventArgs e)
        {

            if (this.tablasDatosFiliatoriosGlobal == null)
            {

                tabInterno.Enabled = false;

                //Carga de combos sobre listas para ingreso
                NListasGenerales nListasGenerales = new NListasGenerales();
                //Carga de combos sobre DatosFiliatorios
                (DDatosFiliatorios datosFiliatorios, string errorResponseDatosFiliatorios) = await nListasGenerales.ListasDatosFilistorios();


                this.tablasDatosFiliatoriosGlobal = datosFiliatorios;

                tabInterno.Enabled = true;

                if (this.tablasDatosFiliatoriosGlobal == null)
                {
                    MessageBox.Show("Advertencia al cargar las listas: " + errorResponseDatosFiliatorios, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //Carga de combo nacionalidad
            cmbNacionalidad.ValueMember = "id_nacionalidad";
            cmbNacionalidad.DisplayMember = "nacionalidad";
            cmbNacionalidad.DataSource = tablasDatosFiliatoriosGlobal.nacionalidad;

            //Carga de combo estado civil
            cmbEstadoCivil.ValueMember = "id_estado_civil";
            cmbEstadoCivil.DisplayMember = "estado_civil";
            cmbEstadoCivil.DataSource = tablasDatosFiliatoriosGlobal.estado_civil;

            //Carga de combo estado civil
            cmbNivelEducacion.ValueMember = "id_nivel_educacion";
            cmbNivelEducacion.DisplayMember = "nivel_educacion";
            cmbNivelEducacion.DataSource = tablasDatosFiliatoriosGlobal.niveles_educacion;

            //Carga de combo estado civil
            cmbReligion.ValueMember = "id_religion";
            cmbReligion.DisplayMember = "religion";
            cmbReligion.DataSource = tablasDatosFiliatoriosGlobal.religiones;

            //Carga de combo estado civil
            cmbUltimaOcupacion.ValueMember = "id_ocupacion";
            cmbUltimaOcupacion.DisplayMember = "ocupacion";
            cmbUltimaOcupacion.DataSource = tablasDatosFiliatoriosGlobal.ocupaciones;
            //fin Carga de combos sobre DatosFiliatorios

            this.CargarControlesInformacionInterno();

            //Carga de combo provincia
            NProvincia nProvincia = new NProvincia();
            string id_paiss = Convert.ToString(this.cmbNacionalidad.SelectedValue);
            cmbProvinciaNacimiento.ValueMember = "id_provincia";
            cmbProvinciaNacimiento.DisplayMember = "provincia";
            (List<DProvincia> listaProvincia, string errorResponseProvincia) = await nProvincia.RetornarListaProvinciasXPais(id_paiss);
            cmbProvinciaNacimiento.DataSource = listaProvincia;
            cmbProvinciaNacimiento.Text = this.dInternoGlobal.provincia_nacimiento.provincia;

            //Carga de combo departamento
            NDepartamento nDepartamento = new NDepartamento();
            cmbDepartamentoNacimiento.ValueMember = "id_departamento";
            cmbDepartamentoNacimiento.DisplayMember = "departamento";
            (List<DDepartamento> listaDepartamento, string errorResponseDepartamento) = await nDepartamento.RetornarListaDepartamentoXProvincia(this.dInternoGlobal.provincia_nacimiento.id_provincia);
            cmbDepartamentoNacimiento.DataSource = listaDepartamento;
            cmbDepartamentoNacimiento.Text = this.dInternoGlobal.departamento_nacimiento.departamento;

            this.HabilitarDatosFiliatorios(true);
            cmbNacionalidad.Focus();
        }

        private async void btnGuardarEditarDatosFilatorios_Click(object sender, EventArgs e)
        {
            NInterno nInterno = new NInterno();
            string dataEnviar;

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new InternoAdministarDatos
            {
                cmbNacionalidad = cmbNacionalidad.SelectedValue?.ToString() ?? string.Empty,
                cmbProvinciaNacimiento = cmbProvinciaNacimiento.SelectedValue?.ToString() ?? string.Empty,
                cmbDepartamentoNacimiento = cmbDepartamentoNacimiento.SelectedValue?.ToString() ?? string.Empty,
                txtCiudadNacimiento = txtCiudadNacimiento.Text,
                dtpFechaNacimiento = dtpFechaNacimiento.Value,
                cmbEstadoCivil = cmbEstadoCivil.SelectedValue?.ToString() ?? string.Empty,
                cmbNivelEducacion = cmbNivelEducacion.SelectedValue?.ToString() ?? string.Empty,
                cmbReligion = cmbReligion.SelectedValue?.ToString() ?? string.Empty,
                cmbUltimaOcupacion = cmbUltimaOcupacion.SelectedValue?.ToString() ?? string.Empty,
                txtProfesion = txtProfesion.Text,
                txtPadre = txtPadre.Text,
                txtMadre = txtMadre.Text,
                txtParientes = txtParientes.Text,
            };

            var validator = new InternoEditarDatosFiliatoriosValidation();
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

            this.tabInterno.Enabled = false;
            var dataInterno = new
            {
                nacionalidad_id = Convert.ToString(cmbNacionalidad.SelectedValue.ToString()),
                provincia_nacimiento_id = cmbProvinciaNacimiento.SelectedValue.ToString(),
                departamento_nacimiento_id = Convert.ToInt32(cmbDepartamentoNacimiento.SelectedValue.ToString()),
                ciudad = txtCiudadNacimiento.Text,
                fecha_nacimiento = dtpFechaNacimiento.Value,
                estado_civil_id = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString()),
                nivel_educacion_id = Convert.ToInt32(cmbNivelEducacion.SelectedValue.ToString()),
                religion_id = Convert.ToInt32(cmbReligion.SelectedValue.ToString()),
                ocupacion_id = Convert.ToInt32(cmbUltimaOcupacion.SelectedValue.ToString()),
                profesion = txtProfesion.Text,
                padre = txtPadre.Text,
                madre = txtMadre.Text,
                parientes = txtParientes.Text
            };

            dataEnviar = JsonConvert.SerializeObject(dataInterno);

            (bool respuestaEditar, string errorResponse) = await nInterno.EditarDatosFiliatorios(Convert.ToInt32(txtIdInterno.Text), dataEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarInterno();
                this.HabilitarDatosFiliatorios(false);
                this.tabInterno.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }

        private void btnCancelarEditarDatosFilatorios_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();
            //cargar datos del interno
            this.CargarControlesInformacionInterno();
            this.HabilitarDatosFiliatorios(false);
        }

        private async void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo provincia
            NProvincia nProvincia = new NProvincia();
            string id_paiss = Convert.ToString(this.cmbNacionalidad.SelectedValue);
            cmbProvinciaNacimiento.ValueMember = "id_provincia";
            cmbProvinciaNacimiento.DisplayMember = "provincia";
            (List<DProvincia> listaProvincia, string errorResponseProvincia) = await nProvincia.RetornarListaProvinciasXPais(id_paiss);

            cmbProvinciaNacimiento.DataSource = listaProvincia;
        }

        private async void cmbProvinciaNacimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo departamento
            NDepartamento nDepartamento = new NDepartamento();
            string provincia_identificador = Convert.ToString(this.cmbProvinciaNacimiento.SelectedValue);
            cmbDepartamentoNacimiento.ValueMember = "id_departamento";
            cmbDepartamentoNacimiento.DisplayMember = "departamento";
            (List<DDepartamento> listaDepartamento, string errorResponseDepartamento) = await nDepartamento.RetornarListaDepartamentoXProvincia(provincia_identificador);
            //MessageBox.Show("el paramentro es: " + provincia_identificador);
            cmbDepartamentoNacimiento.DataSource = listaDepartamento;
        }

        private void pictureFotoPI_DoubleClick(object sender, EventArgs e)
        {
            if (this.dInternoGlobal == null)
            {
                MessageBox.Show("El interno no es valido.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormInternoEditarFotos form = new FormInternoEditarFotos(this.dInternoGlobal);
            form.ShowDialog();
        }

        private void pictureFoto_DoubleClick(object sender, EventArgs e)
        {
            if (this.dInternoGlobal == null)
            {
                MessageBox.Show("El interno no es valido.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormInternoEditarFotos form = new FormInternoEditarFotos(this.dInternoGlobal);
            form.ShowDialog();
        }

        private void pictureFotoPD_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.dInternoGlobal == null)
            {
                MessageBox.Show("El interno no es valido.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormInternoEditarFotos form = new FormInternoEditarFotos(this.dInternoGlobal);
            form.ShowDialog();
        }


        private void btnEditarFotos_Click(object sender, EventArgs e)
        {
            if (this.dInternoGlobal == null)
            {
                MessageBox.Show("El interno no es valido.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FormInternoEditarFotos formEditarFotos = new FormInternoEditarFotos(this.dInternoGlobal))
            {

                // Aquí se abre el FormularioB
                if (formEditarFotos.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    bool isFotoModificada = formEditarFotos.isFotoModificada;
                    if (isFotoModificada)
                    {
                        this.dInternoGlobal = formEditarFotos.dInternoGlobal;

                        tabInterno.Enabled = false;
                        if (!string.IsNullOrEmpty(this.dInternoGlobal.foto))
                        {
                            pictureFoto.Load(this.dInternoGlobal.foto);
                        }
                        if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPI))
                        {
                            pictureFotoPI.Load(this.dInternoGlobal.fotoPI);
                        }
                        if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPD))
                        {
                            pictureFotoPD.Load(this.dInternoGlobal.fotoPD);
                        }
                        tabInterno.Enabled = true;
                    }                    
                }
            }
        }

        

        //BUSCAR INTERNO
        private async void BuscarInterno()
        {
            int idInterno;
            NInterno nInterno = new NInterno();
            DInterno dInterno = new DInterno();
            idInterno = Convert.ToInt32(txtIdInterno.Text);
            (DInterno dInternoResponse, string errorInternoResponse) = await nInterno.BuscarInternoXID(idInterno);

            dInterno = dInternoResponse;
                        
            if (dInterno == null)
            {
                tabInterno.Enabled = false;
                MessageBox.Show("No se encontro informaciòn del interno solicitado: " + errorInternoResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.dInternoGlobal = dInterno;

        }
        //FIN BUSCAR INTERNO................................................................

        //HABILITAR CONTROLES DATOS PERSONALES
        private void HabilitarDatosPersonales(bool valor)
        {
            txtDni.ReadOnly = !valor;
            txtProntuario.ReadOnly = !valor;
            txtApellido.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            txtAlias.ReadOnly = !valor;


            btnEditarDatosPrincipales.Enabled = !valor;
            btnGuardarEditarDatosPrincipales.Enabled = valor;
            btnCancelarEditarDatosPrincipales.Enabled = valor;

        }//FIN HABILITAR CONTROLES DATOS PERSONALES.......................................


        //HABILITAR CONTROLES CARACTERISTICAS PERSONALES
        private void HabilitarCarasteristicasPersonales(bool valor)
        {
            cmbSexo.Enabled = valor;
            txtTalla.ReadOnly = !valor;
            cmbPiel.Enabled = valor;
            cmbOjosColor.Enabled = valor;
            cmbOjosTamanio.Enabled = valor;
            cmbNarizForma.Enabled = valor;
            cmbNarizTamanio.Enabled = valor;
            cmbPeloTipo.Enabled = valor;
            cmbPeloColor.Enabled = valor;

            btnEditarCaracteristicasPersonales.Enabled = !valor;
            btnGuardarEditarCaracteristicasPersonales.Enabled = valor;
            btnCancelarEditarCaracteristicasPersonales.Enabled = valor;

        }//FIN HABILITAR CONTROLES DATOS PERSONALES.......................................

        //HABILITAR CONTROLES CARACTERISTICAS PERSONALES
        private void HabilitarDatosFiliatorios(bool valor)
        {
            cmbNacionalidad.Enabled = valor;
            cmbProvinciaNacimiento.Enabled = valor;
            cmbDepartamentoNacimiento.Enabled = valor;
            txtCiudadNacimiento.ReadOnly = !valor;
            dtpFechaNacimiento.Enabled = valor;
            cmbEstadoCivil.Enabled = valor;
            cmbNivelEducacion.Enabled = valor;
            cmbReligion.Enabled = valor;
            cmbUltimaOcupacion.Enabled = valor;
            txtProfesion.ReadOnly = !valor;
            txtPadre.ReadOnly = !valor;
            txtMadre.ReadOnly = !valor;
            txtParientes.ReadOnly = !valor;

            btnEditarDatosFilatorios.Enabled = !valor;
            btnGuardarEditarDatosFilatorios.Enabled = valor;
            btnCancelarEditarDatosFilatorios.Enabled = valor;

        }//FIN HABILITAR CONTROLES DATOS PERSONALES.......................................

        #endregion DATOS_PRINCIPALES
        //FIN REGION DATOS_PRINCIPALES..........................................................
        //......................................................................................


        //REGION DATOS_INGRESO
        #region DATOS_INGRESO
        private async void btnEditarIngreso_Click(object sender, EventArgs e)
        {
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

            //cargar datos de ingreso en pestaña DATOS DE INGRESO           
            this.CargarControlesIngreso();

            this.HabilitarControlesIngreso(true);
        }

        private void btnCancelarIngreso_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //cargar datos de ingreso en pestaña DATOS DE INGRESO           
            this.CargarControlesIngreso();

            this.HabilitarControlesIngreso(false);
        }

        private async void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //validacion de formulario
            var datosformulario = new InternoAdministarDatos
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

            var validator = new EditarIngresoValidation();
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


            this.tabInterno.Enabled = false;
            var data = new
            {
                organismo_externo_id = Convert.ToInt32(cmbOrganismoExternoProcedencia.SelectedValue.ToString()),
                fecha_primer_ingreso = dtpFechaIngresoSpps.Value,
                obs_organismo_externo = txtDetalleProceExterno.Text,
                organismo_procedencia_id = Convert.ToInt32(cmbOrganismoSppsProcesencia.SelectedValue.ToString()),
                obs_organismo_procedencia = txtDetalleProceSpps.Text,
                prontuario_policial = txtProntuarioPolicial.Text,
                estado_procesal_id = cmbEstadoProcesal.SelectedValue.ToString(),
                jurisdiccion_id = cmbJurisdiccion.SelectedValue.ToString(),
                otra_jurisdiccion_id = cmbOtraJurisdiccion.SelectedValue.ToString(),
                reingreso_id = Convert.ToInt32(cmbReingreso.SelectedValue.ToString()),
                numero_reingreso = Convert.ToInt32(txtNumeroReingreso.Text),
                fecha_alojamiento = dtpFechaAlojamiento.Value,
                tipo_defensor_id = Convert.ToInt32(cmbTipoDefensor.SelectedValue.ToString()),
                abogado = txtAbogado.Text
            };

            string dataIngresoEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nIngreso.EditarIngreso(Convert.ToInt32(txtIdIngresoVer.Text), dataIngresoEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarIngreso();
                
                this.HabilitarControlesIngreso(false);
                this.tabInterno.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }


        //HABILITAR CONTROLES INGRESO
        private void HabilitarControlesIngreso(bool valor)
        {
            cmbOrganismoExternoProcedencia.Enabled = valor;
            dtpFechaIngresoSpps.Enabled = valor;
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

            btnEditarIngreso.Enabled = !valor;
            btnGuardarIngreso.Enabled = valor;
            btnCancelarIngreso.Enabled = valor;
        }//FIN HABILITAR CONTROLES INGRESO...........................................

        //BUSCAR INGRESO
        private async void BuscarIngreso()
        {
            NIngresoInterno nIngreso = new NIngresoInterno();
            (DIngresoInterno ingresoInterno, string errorResponse) = await nIngreso.BuscarxIdIngreso(Convert.ToInt32(this.txtIdIngresoVer.Text));
            
            if (ingresoInterno == null)
            {
                
                MessageBox.Show("El interno no se encuentra alojado en una unidad", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else
            {
                this.ingresoInternoGlobal = ingresoInterno;
                //datos de ingreso en pestaña DATOS PRINCIPALES
                txtIdIngresoVer.Text = this.ingresoInternoGlobal.id_ingreso_interno.ToString();
                txtReingresoVer.Text = this.ingresoInternoGlobal.reingreso.reingreso;
                txtNumReingresoVer.Text = this.ingresoInternoGlobal.numero_reingreso.ToString();
                txtOrganismoAlojamientoVer.Text = this.ingresoInternoGlobal.organismo_alojamiento.organismo;
                dtpFechaAlojamientoVer.Text = this.ingresoInternoGlobal.fecha_alojamiento.ToShortDateString();
                txtEstadoProcesalVer.Text = this.ingresoInternoGlobal.estado_procesal.estado_procesal;
                txtJurisdiccionVer.Text = this.ingresoInternoGlobal.jurisdiccion.jurisdiccion;

            }
        }
        //FIN BUSCAR INGRESO.....................................................

        #endregion DATOS_INGRESO
        //FIN REGION DATOS_INGRESO................................................................
        //........................................................................................


        //REGION CAUSAS
        #region CAUSAS
        
        private void btnVerCausas_Click_1(object sender, EventArgs e)
        {
            this.CargarDataGridCausas();
        }

        private void btnNuevaCausa_Click_1(object sender, EventArgs e)
        {
            if (txtIdIngresoVer.Text == null || txtIdIngresoVer.Text == "")
            {
                MessageBox.Show("El interno no tiene un ingreso valido", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FormCausaNueva formCausaNuevo = new FormCausaNueva(Convert.ToInt32(txtIdIngresoVer.Text)))
            {
                // Aquí se abre el FormularioB
                if (formCausaNuevo.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    bool isCausaCreada = formCausaNuevo.isCreadoCausa;
                    if (isCausaCreada)
                    {

                        tabInterno.Enabled = false;
                        this.CargarDataGridCausas();
                        tabInterno.Enabled = true;
                    }
                }
            }
        }

        private void dtgvCausas_KeyDown_1(object sender, KeyEventArgs e)
        {
            int idCausa = 0;
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                idCausa = Convert.ToInt32(dtgvCausas.CurrentRow.Cells["Id"].Value.ToString());

                if (dtgvCausas.SelectedRows.Count > 0)
                {
                    if (idCausa > 0)
                    {
                        using (FormCausaAdministrar formCausaAdministrar = new FormCausaAdministrar(Convert.ToInt32(idCausa)))
                        {

                            // Aquí se abre el FormularioB
                            if (formCausaAdministrar.ShowDialog() == DialogResult.OK)
                            {
                                // Recién después de cerrar FormularioB, puedo leer el dato
                                bool isCausaCreado = formCausaAdministrar.isModificadoCausaGlobal;
                                if (isCausaCreado)
                                {
                                    tabInterno.Enabled = false;
                                    this.CargarDataGridCausas();
                                    tabInterno.Enabled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una causa.");
                    }
                }
            }
        }


        //METODO PARA OBTENER LA LISTA DE CAUSAS Y CARGARLO EN UN DATA GRID 
        async private void CargarDataGridCausas()
        {
            NCausa nCausa = new NCausa();

            if (txtIdIngresoVer.Text == null || txtIdIngresoVer.Text == "")
            {
                MessageBox.Show("El interno no tiene un ingreso valido", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (List<DCausa> listaCausas, string errorResponse) = await nCausa.ListaCausasXIngreso(Convert.ToInt32(txtIdIngresoVer.Text));

            if (listaCausas == null)
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaCausas
                .Select(c => new
                {
                    Id = c.id_causa,
                    Causa = c.causa,
                    TipoDelito = c.tipo_delito.tipo_delito,
                    PrisionReclusion = c.prision_reclusion.prision_reclusion,
                    EstadoProcesal = c.estado_procesal.estado_procesal,
                    Jurisdiccion = c.jurisdiccion.jurisdiccion,
                    Juzgado = c.juzgado.juzgado,
                    Reincidencia = c.reincidencia.reincidencia,
                    FechaCarga = c.fecha_carga,
                    OrganismoCarga = c.organismo_carga.organismo,
                    Usuario = c.usuario_carga.apellido + " " + c.usuario_carga.nombre

                })
                .ToList();

            dtgvCausas.DataSource = datosfiltrados;

            if (listaCausas.Count == 0)
            {
                MessageBox.Show("No se encontraron registros.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                dtgvCausas.Columns[1].Width = 200;
                dtgvCausas.Focus();
            }
                        

        } //FIN METODO PARA OBTENER LA LISTA DE CAUSAS EN UN DATA GRID ...........


        #endregion CAUSAS
        //FIN REGION CAUSAS.......................................................................
        //........................................................................................


        //REGION HISTORIAL PROCESAL
        #region HISTORIAL_PROCESAL

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            tabInterno.Enabled = false;
            this.CargarDataGridHistorial();
            tabInterno.Enabled = true;
        }

        private void btnNuevoHistorial_Click(object sender, EventArgs e)
        {
            if (txtIdIngresoVer.Text == null || txtIdIngresoVer.Text == "")
            {
                MessageBox.Show("El interno no tiene un ingreso valido", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FormHistorialProcesalNuevo formHistorialProcesalNuevo = new FormHistorialProcesalNuevo(Convert.ToInt32(txtIdIngresoVer.Text)))
            {
                // Aquí se abre el FormularioB
                if (formHistorialProcesalNuevo.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    bool isHistorialCreado = formHistorialProcesalNuevo.isCreadoHistorialGlobal;
                    if (isHistorialCreado)
                    {

                        tabInterno.Enabled = false;
                        this.CargarDataGridHistorial();
                        tabInterno.Enabled = true;
                    }
                }
            }
        }

        private void dtgHistorialProcesal_KeyDown(object sender, KeyEventArgs e)
        {
            int idHistorial = 0;
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                idHistorial = Convert.ToInt32(dtgHistorialProcesal.CurrentRow.Cells["Id"].Value.ToString());

                if (dtgHistorialProcesal.SelectedRows.Count > 0)
                {
                    if (idHistorial > 0)
                    {
                        using (FormHistorialProcesalAdministrar formHistorialProcesalAdministrar = new FormHistorialProcesalAdministrar(Convert.ToInt32(idHistorial)))
                        {

                            // Aquí se abre el FormularioB
                            if (formHistorialProcesalAdministrar.ShowDialog() == DialogResult.OK)
                            {
                                // Recién después de cerrar FormularioB, puedo leer el dato
                                bool isHistorialModificado = formHistorialProcesalAdministrar.isModificadoHistorialGlobal;
                                if (isHistorialModificado)
                                {
                                    tabInterno.Enabled = false;
                                    this.CargarDataGridHistorial();
                                    tabInterno.Enabled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una causa.");
                    }
                }
            }
        }

        //METODO PARA OBTENER LA LISTA DE historial Y CARGARLO EN UN DATA GRID 
        async private void CargarDataGridHistorial()
        {
            NHistorialPRocesal nHistorialProcesal = new NHistorialPRocesal();

            if (txtIdIngresoVer.Text == null || txtIdIngresoVer.Text == "")
            {
                MessageBox.Show("El interno no tiene un ingreso valido", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (List<DHistorialProcesal> listaHistorialProcesal, string errorResponse) = await nHistorialProcesal.ListaXIngreso(Convert.ToInt32(txtIdIngresoVer.Text));

            if (listaHistorialProcesal == null)
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaHistorialProcesal
                .Select(c => new
                {
                    Id = c.id_historial_procesal,
                    Fecha = c.fecha,
                    TipoHistorial = c.tipo_historial_procesal.tipo_historial_procesal,
                    Detalle = c.detalle,
                    Motivo = c.motivo,
                    FechaCarga = c.fecha_carga,
                    OrganismoCarga = c.organismo.organismo,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgHistorialProcesal.DataSource = datosfiltrados;

            if (listaHistorialProcesal.Count == 0)
            {
                MessageBox.Show("No se encontraron registros.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dtgHistorialProcesal.Columns[0].Width = 50;
                dtgHistorialProcesal.Columns[1].Width = 70;
                dtgHistorialProcesal.Columns[2].Width = 150;
                dtgHistorialProcesal.Columns[3].Width = 350;
                dtgHistorialProcesal.Columns[4].Width = 200;
                dtgHistorialProcesal.Columns[5].Width = 80;
                dtgHistorialProcesal.Columns[6].Width = 150;

                dtgHistorialProcesal.Focus();
            }

        }
        //FIN METODO PARA OBTENER LA LISTA DE CAUSAS EN UN DATA GRID ...........


        #endregion HISTORIAL_PROCESAL
        //FIN REGION HISTORIAL PROCESAL...........................................................
        //.......................................................................................


        //REGION PROGRESIVIDAD
        #region PROGRESIVIDAD

        private async void btnEditarAlojamiento_Click(object sender, EventArgs e)
        {
            //Carga de combos sobre alojamiento
            NListasGenerales nListasGenerales = new NListasGenerales();
            tabInterno.Enabled = false;
            (DTablasAlojamiento dTablasAlojamiento, string errorResponseEgreso) = await nListasGenerales.ListasTablasAlojamiento();
            tabInterno.Enabled = true;

            if (dTablasAlojamiento == null)
            {
                MessageBox.Show("Advertencia al cargar los datos para alojamiento: " + errorResponseEgreso, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //dTablasDomicilioInternoGlobal = dTablasDomicilioInterno;

                cmbPabellon.ValueMember = "id_pabellon";
                cmbPabellon.DisplayMember = "pabellon";
                cmbPabellon.DataSource = dTablasAlojamiento.pabellones;

                cmbSituacionProvisoria.ValueMember = "id_situacion_provisoria";
                cmbSituacionProvisoria.DisplayMember = "situacion_provisoria";
                cmbSituacionProvisoria.DataSource = dTablasAlojamiento.situacion_provisoria;



                this.HabilitarControlesAlojamiento(true);
                this.CargarControlesAlojamiento();
            }
            //fin Carga de combos sobre egreso
        }

        private async void  btnGuardarAlojamiento_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //validacion de formulario
            //var datosformulario = new InternoAdministarDatos
            //{
            //    cmbOrganismoExternoProcedencia = cmbOrganismoExternoProcedencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceExterno = txtDetalleProceExterno.Text,
            //    txtProntuarioPolicial = txtProntuarioPolicial.Text,
            //    cmbOrganismoSppsProcesencia = cmbOrganismoSppsProcesencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceSpps = txtDetalleProceSpps.Text,
            //    cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
            //    cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbOtraJurisdiccion = cmbOtraJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbReingreso = cmbReingreso.SelectedValue?.ToString() ?? string.Empty,
            //    txtNumeroReingreso = txtNumeroReingreso.Text,
            //    cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
            //    txtAbogado = txtAbogado.Text,
            //};

            //var validator = new EditarIngresoValidation();
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


            this.tabInterno.Enabled = false;
            var data = new
            {
                pabellon_id = Convert.ToInt32(cmbPabellon.SelectedValue.ToString()),
                celda = txtCelda.Text.Trim(),
                tiene_programa_puerta = chkProgramaPuerta.Checked,
                situacion_provisoria_id = Convert.ToInt32(cmbSituacionProvisoria.SelectedValue.ToString()),
                fecha = dtpFechaCambioAlojamiento.Value,
                detalle = txtDetalleCambioAlojamiento.Text,

            };

            string dataAlojamientoEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nIngreso.EstablecerAlojamiento(Convert.ToInt32(txtIdIngresoVer.Text), dataAlojamientoEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("Se modifico correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarIngreso();

                this.HabilitarControlesAlojamiento(false);
                this.tabInterno.Enabled = true;

            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }

        private void btnCancelarAlojamiento_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesAlojamiento(false);
            this.CargarControlesAlojamiento();
        }


        private async void btnGuardarConductaConepto_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //validacion de formulario
            //var datosformulario = new InternoAdministarDatos
            //{
            //    cmbOrganismoExternoProcedencia = cmbOrganismoExternoProcedencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceExterno = txtDetalleProceExterno.Text,
            //    txtProntuarioPolicial = txtProntuarioPolicial.Text,
            //    cmbOrganismoSppsProcesencia = cmbOrganismoSppsProcesencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceSpps = txtDetalleProceSpps.Text,
            //    cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
            //    cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbOtraJurisdiccion = cmbOtraJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbReingreso = cmbReingreso.SelectedValue?.ToString() ?? string.Empty,
            //    txtNumeroReingreso = txtNumeroReingreso.Text,
            //    cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
            //    txtAbogado = txtAbogado.Text,
            //};

            //var validator = new EditarIngresoValidation();
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


            this.tabInterno.Enabled = false;
            var data = new
            {
                trimestre_id = Convert.ToInt32(cmbTrimestre.SelectedValue.ToString()),
                conducta_id = Convert.ToInt32(cmbConducta.SelectedValue.ToString()),
                concepto_id = Convert.ToInt32(cmbConcepto.SelectedValue.ToString()),

            };

            string dataConductaConceptoEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nIngreso.EstablecerConductaConcepto(Convert.ToInt32(txtIdIngresoVer.Text), dataConductaConceptoEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("Se modifico correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarIngreso();

                this.HabilitarControlesConductaConcepto(false);
                this.tabInterno.Enabled = true;

            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }

        private async void btnEditarConductaConcepto_Click(object sender, EventArgs e)
        {
            //Carga de combos sobre conducta concepto
            NListasGenerales nListasGenerales = new NListasGenerales();
            tabInterno.Enabled = false;
            (DTablasConductaConcepto dTablasConductaConcepto, string errorResponseEgreso) = await nListasGenerales.ListasTablasConductaConcepto();
            tabInterno.Enabled = true;

            if (dTablasConductaConcepto == null)
            {
                MessageBox.Show("Advertencia al cargar los datos para conducta/concepto: " + errorResponseEgreso, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //dTablasDomicilioInternoGlobal = dTablasDomicilioInterno;

                cmbTrimestre.ValueMember = "id_trimestre";
                cmbTrimestre.DisplayMember = "trimestre";
                cmbTrimestre.DataSource = dTablasConductaConcepto.trimestres;

                cmbConducta.ValueMember = "id_conducta";
                cmbConducta.DisplayMember = "conducta";
                cmbConducta.DataSource = dTablasConductaConcepto.conducta;

                cmbConcepto.ValueMember = "id_concepto";
                cmbConcepto.DisplayMember = "concepto";
                cmbConcepto.DataSource = dTablasConductaConcepto.concepto;


                this.HabilitarControlesConductaConcepto(true);
                this.CargarControlesConductaConcepto();
            }
            //fin Carga de combos sobre egreso
        }

        private void btnCancelarConductaConcepto_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesConductaConcepto(false);
            this.CargarControlesConductaConcepto();
        }

        private async void btnEditarProgresividad_Click(object sender, EventArgs e)
        {
            //Carga de combos sobre progresividad
            NListasGenerales nListasGenerales = new NListasGenerales();
            tabInterno.Enabled = false;
            (DTablasProgresividad dTablasProgresividad, string errorResponseEgreso) = await nListasGenerales.ListasTablasProgresividad();
            tabInterno.Enabled = true;

            if (dTablasProgresividad == null)
            {
                MessageBox.Show("Advertencia al cargar los datos para progresividad: " + errorResponseEgreso, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //dTablasDomicilioInternoGlobal = dTablasDomicilioInterno;

                cmbProgresividad.ValueMember = "id_progresividad";
                cmbProgresividad.DisplayMember = "progresividad";
                cmbProgresividad.DataSource = dTablasProgresividad.progresividad;

                cmbFase.ValueMember = "id_fase";
                cmbFase.DisplayMember = "fase";
                cmbFase.DataSource = dTablasProgresividad.fases;

                this.HabilitarControlesProgresividad(true);
                this.CargarControlesProgresividad();
            }
            //fin Carga de combos sobre progresividad

        }

        private async void btnGuardarProgresividad_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //validacion de formulario
            //var datosformulario = new InternoAdministarDatos
            //{
            //    cmbOrganismoExternoProcedencia = cmbOrganismoExternoProcedencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceExterno = txtDetalleProceExterno.Text,
            //    txtProntuarioPolicial = txtProntuarioPolicial.Text,
            //    cmbOrganismoSppsProcesencia = cmbOrganismoSppsProcesencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceSpps = txtDetalleProceSpps.Text,
            //    cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
            //    cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbOtraJurisdiccion = cmbOtraJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbReingreso = cmbReingreso.SelectedValue?.ToString() ?? string.Empty,
            //    txtNumeroReingreso = txtNumeroReingreso.Text,
            //    cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
            //    txtAbogado = txtAbogado.Text,
            //};

            //var validator = new EditarIngresoValidation();
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


            this.tabInterno.Enabled = false;
            var data = new
            {
                progresividad_id = Convert.ToInt32(cmbProgresividad.SelectedValue.ToString()),
                fase_id = Convert.ToInt32(cmbFase.SelectedValue.ToString()),
                tiene_extramuro = chkExtramuro.Checked,
                tiene_granja = chkGranja.Checked,
                tiene_semilibertad = chkSemilibertad.Checked,
                tiene_transitoria = chkTransitoria.Checked,
                fecha = dtpFechaProgresividad.Value,
                detalle = txtDetalleProgresividad.Text,

            };

            string dataProgresividadEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nIngreso.EstablecerProgresividad(Convert.ToInt32(txtIdIngresoVer.Text), dataProgresividadEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("La progresividad de modifico correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarIngreso();

                this.HabilitarControlesProgresividad(false);
                this.tabInterno.Enabled = true;

            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }

        private void btnCancelarProgresividad_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesProgresividad(false);
            this.CargarControlesProgresividad();
        }

        //HABILITAR CONTROLES PROGRESIVIDAD
        private void HabilitarControlesProgresividad(bool valor)
        {
            
            cmbProgresividad.Enabled = valor;
            cmbFase.Enabled = valor;
            chkExtramuro.Enabled = valor;
            chkGranja.Enabled = valor;
            chkSemilibertad.Enabled = valor;
            chkTransitoria.Enabled = valor;
            dtpFechaProgresividad.Enabled = valor;
            txtDetalleProgresividad.Enabled = valor;

            btnEditarProgresividad.Enabled = !valor;
            btnGuardarProgresividad.Enabled = valor;
            btnCancelarProgresividad.Enabled = valor;
        }//FIN HABILITAR CONTROLES EGRESO...........................................

        //HABILITAR CONTROLES CONDUCTA CONCEPTO
        private void HabilitarControlesConductaConcepto(bool valor)
        {
            cmbTrimestre.Enabled = valor;
            cmbConducta.Enabled = valor;
            cmbConcepto.Enabled = valor;  

            btnEditarConductaConcepto.Enabled = !valor;
            btnGuardarConductaConepto.Enabled = valor;
            btnCancelarConductaConcepto.Enabled = valor;
        }//FIN HABILITAR CONTROLES EGRESO...........................................

        //HABILITAR CONTROLES CONDUCTA CONCEPTO
        private void HabilitarControlesAlojamiento(bool valor)
        {
            cmbPabellon.Enabled = valor;
            txtCelda.Enabled = valor;
            chkProgramaPuerta.Enabled = valor;
            cmbSituacionProvisoria.Enabled = valor;
            dtpFechaCambioAlojamiento.Enabled = valor;
            txtDetalleCambioAlojamiento.Enabled = valor;

            btnEditarAlojamiento.Enabled = !valor;
            btnGuardarAlojamiento.Enabled = valor;
            btnCancelarAlojamiento.Enabled = valor;
        }//FIN HABILITAR CONTROLES EGRESO...........................................

        #endregion PROGRESIVIDAD
        //FIN REGION PROGRESIVIDAD........................................................
        //...................................................................................


        //REGION TRASLADOS
        #region TRASLADOS
        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            if (txtIdIngresoVer.Text == null || txtIdIngresoVer.Text == "")
            {
                MessageBox.Show("El interno no tiene un ingreso valido", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormTrasladoNuevo formTrasladoNuevo = new FormTrasladoNuevo(Convert.ToInt32(txtIdIngresoVer.Text));
            formTrasladoNuevo.ShowDialog();
        }

        private void btnVerTraslados_Click(object sender, EventArgs e)
        {
            this.CargarDataGridTraslados();
        }



        private void dtgvTraslados_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvTraslados.SelectedRows.Count > 0)
                {
                    int idTraslado;
                    idTraslado = Convert.ToInt32(dtgvTraslados.CurrentRow.Cells["ID"].Value.ToString());


                    if (idTraslado > 0)
                    {
                        txtIdTraslado.Text = idTraslado.ToString();
                        txtOrganismoOrigenTraslado.Text = dtgvTraslados.CurrentRow.Cells["Origen"].Value.ToString();
                        txtFechaTraslado.Text = Convert.ToDateTime(dtgvTraslados.CurrentRow.Cells["FechaTraslado"].Value).ToString("dd/MM/yyyy");
                        txtDetalleTraslado.Text = dtgvTraslados.CurrentRow.Cells["DetalleTrasaldo"].Value?.ToString();
                        txtOrganismoDestinoTraslado.Text = dtgvTraslados.CurrentRow.Cells["Destino"].Value?.ToString();
                        //controlar fecha_ingreso
                        var valor = dtgvTraslados.CurrentRow.Cells["FechaIngreso"].Value;

                        if (valor is DateTime fecha)
                        {
                            txtFechaIngresoTraslado.Text = fecha.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            txtFechaIngresoTraslado.Text = "";
                        }
                        txtEstadoTraslado.Text = dtgvTraslados.CurrentRow.Cells["Estado"].Value?.ToString();
                        txtObsTraslado.Text = dtgvTraslados.CurrentRow.Cells["ObsTraslado"].Value?.ToString();
                        txtFechaCargaTraslado.Text = Convert.ToDateTime(dtgvTraslados.CurrentRow.Cells["FechaCarga"].Value).ToString("dd/MM/yyyy");
                        txtHoraCargaTraslado.Text = dtgvTraslados.CurrentRow.Cells["HoraCarga"].Value?.ToString();
                        txtUsuarioCargaTraslado.Text = dtgvTraslados.CurrentRow.Cells["Usuario"].Value?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una traslado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void btnAnularTraslado_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesAnularTraslado(true);
        }

        private void btnCancelarTrasladoARA_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesAnularTraslado(false);
        }
        private async void btnGuardarTrasladoARA_Click(object sender, EventArgs e)
        {
            if (txtIdTraslado.Text == null || txtIdTraslado.Text == "")
            {
                MessageBox.Show("Debe seleccionar un traslado para poder anular.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtObsProcesarTraslado.Text == string.Empty)
            {
                MessageBox.Show("Debe completar el obs traslado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NTrasladoInterno nTrasladoInterno = new NTrasladoInterno();

            var dataAnular = new
            {
                obs_traslado = txtObsProcesarTraslado.Text,
            };

            string dataEnviar = JsonConvert.SerializeObject(dataAnular);

            tabInterno.Enabled = false;
            (bool respuestaEditar, string errorResponse) = await nTrasladoInterno.AnularTraslado(Convert.ToInt32(txtIdTraslado.Text), dataEnviar);
            tabInterno.Enabled = true;

            //verificar respuesta de la peticion
            if (respuestaEditar)
            {

                MessageBox.Show("El traslado se anulo correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.HabilitarControlesAnularTraslado(false);
                this.CargarDataGridTraslados();
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //METODO PARA OBTENER LA LISTA DE TRASLADOS Y CARGARLO EN UN DATA GRID 
        async private void CargarDataGridTraslados()
        {
            NTrasladoInterno nTrasladoInterno = new NTrasladoInterno();

            if (txtIdIngresoVer.Text == null || txtIdIngresoVer.Text == "")
            {
                MessageBox.Show("El interno no tiene un ingreso valido", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (List<DTrasladoInterno> listaTraslados, string errorResponse) = await nTrasladoInterno.ListaTrasladosXIngreso(Convert.ToInt32(txtIdIngresoVer.Text));

            if (listaTraslados == null)
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaTraslados
                .Select(c => new
                {
                    Id = c.id_traslado_interno,
                    Origen = c.organismo_origen.organismo,
                    FechaTraslado = c.fecha_egreso_origen,
                    DetalleTrasaldo = c.detalle_traslado,
                    Destino = c.organismo_destino.organismo,
                    FechaIngreso = c.fecha_ingreso_destino,
                    Estado = c.estado_traslado,
                    ObsTraslado = c.obs_traslado,
                    FechaCarga = c.fecha_carga,
                    HoraCarga = c.hora_carga,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre,

                })
                .ToList();

            dtgvTraslados.DataSource = datosfiltrados;

            if (listaTraslados.Count == 0)
            {
                MessageBox.Show("No se encontraron registros.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                dtgvTraslados.Columns[1].Width = 200;
                dtgvTraslados.Columns[4].Width = 200;
            }

            //limpiar formulario
            txtIdTraslado.Text = string.Empty;
            txtOrganismoOrigenTraslado.Text = string.Empty;
            txtFechaTraslado.Text = string.Empty;
            txtDetalleTraslado.Text = string.Empty;
            txtOrganismoDestinoTraslado.Text = string.Empty;
            txtFechaIngresoTraslado.Text = string.Empty;
            txtEstadoTraslado.Text = string.Empty;
            txtObsTraslado.Text = string.Empty;
            txtFechaCargaTraslado.Text = string.Empty;
            txtHoraCargaTraslado.Text = string.Empty;
            txtUsuarioCargaTraslado.Text = string.Empty;

        } //FIN METODO PARA OBTENER LA LISTA DE TRASLADOS EN UN DATA GRID ...........

        //METODO HABILITAR CONTROLES ANULAR TRASLADO
        private void HabilitarControlesAnularTraslado(bool valor)
        {
            txtObsProcesarTraslado.Enabled = valor;
            txtObsProcesarTraslado.Text = string.Empty;

            btnAnularTraslado.Enabled = !valor;

            btnGuardarTrasladoARA.Enabled = valor;
            btnCancelarTrasladoARA.Enabled = valor;

        }//FIN METODO HABILITAR CONTROLES ANULAR TRASLADO..............................


        #endregion TRASLADOS
        //FIN REGION TRASLADOS....................................................................
        //........................................................................................


        //REGION EGRESO
        #region EGRESO
        private async void btnEditarEgreso_Click(object sender, EventArgs e)
        {
            //Carga de combos sobre egreso
            NListasGenerales nListasGenerales = new NListasGenerales();
            tabInterno.Enabled = false;
            (DTablasEgreso dTablasEgreso, string errorResponseEgreso) = await nListasGenerales.ListasTablasEgreso();
            tabInterno.Enabled = true;

            if (dTablasEgreso == null)
            {
                MessageBox.Show("Advertencia al cargar los datos para egreso: " + errorResponseEgreso, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //dTablasDomicilioInternoGlobal = dTablasDomicilioInterno;

                cmbJuzgadoLibera.ValueMember = "id_juzgado";
                cmbJuzgadoLibera.DisplayMember = "juzgado";
                cmbJuzgadoLibera.DataSource = dTablasEgreso.juzgados;

                cmbMotivoEgreso.ValueMember = "id_motivo_egreso";
                cmbMotivoEgreso.DisplayMember = "motivo_egreso";
                cmbMotivoEgreso.DataSource = dTablasEgreso.motivos_egreso;

            }
            //fin Carga de combos sobre egreso

            this.HabilitarControlesEgreso(true);
        }

        private async void btnGuardarEgreso_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //validacion de formulario
            //var datosformulario = new InternoAdministarDatos
            //{
            //    cmbOrganismoExternoProcedencia = cmbOrganismoExternoProcedencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceExterno = txtDetalleProceExterno.Text,
            //    txtProntuarioPolicial = txtProntuarioPolicial.Text,
            //    cmbOrganismoSppsProcesencia = cmbOrganismoSppsProcesencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtDetalleProceSpps = txtDetalleProceSpps.Text,
            //    cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
            //    cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbOtraJurisdiccion = cmbOtraJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
            //    cmbReingreso = cmbReingreso.SelectedValue?.ToString() ?? string.Empty,
            //    txtNumeroReingreso = txtNumeroReingreso.Text,
            //    cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
            //    txtAbogado = txtAbogado.Text,
            //};

            //var validator = new EditarIngresoValidation();
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


            this.tabInterno.Enabled = false;
            var data = new
            {
                fecha_egreso = dtpFechaEgreso.Value,
                motivo_egreso_id = Convert.ToInt32(cmbMotivoEgreso.SelectedValue.ToString()),
                juzgado_libera_id = cmbJuzgadoLibera.SelectedValue.ToString(),
                domicilio_libertad = txtDomicilioLibertad.Text,
                detalles_egreso = txtDetallesEgreso.Text
                
            };

            string dataEgresoEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nIngreso.EgresoInterno(Convert.ToInt32(txtIdIngresoVer.Text), dataEgresoEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("El egreso se realizo correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarIngreso();

                this.HabilitarControlesEgreso(false);
                this.tabInterno.Enabled = true;

                this.Close();
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabInterno.Enabled = true;
            }
        }


        private void btnCancelarEgreso_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesEgreso(true);
            this.CargarControlesEgreso();
        }


        //HABILITAR CONTROLES EGRESO
        private void HabilitarControlesEgreso(bool valor)
        {
            dtpFechaEgreso.Enabled = valor;
            cmbMotivoEgreso.Enabled = valor;
            cmbJuzgadoLibera.Enabled = valor;
            txtDomicilioLibertad.Enabled = valor;
            txtDetallesEgreso.Enabled = valor;

            btnEditarEgreso.Enabled = !valor;
            btnGuardarEgreso.Enabled = valor;
            btnCancelarEgreso.Enabled = valor;
        }//FIN HABILITAR CONTROLES EGRESO...........................................
        
        #endregion EGRESO
        //FIN REGION EGRESO........................................................................
        //.........................................................................................


        //REGION DOMICILIOS
        #region DOMICILIOS
        private void btnVerDomicilios_Click(object sender, EventArgs e)
        {
            tabInterno.Enabled = false;
            this.CargarDataGridDomicilios();
            tabInterno.Enabled = true;
        }

        private void btnNuevoDomicilio_Click(object sender, EventArgs e)
        {
            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("El interno no se encuentra cargado", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.LimpiarControlesDomicilio();

            using (FormDomicilioNuevo formDomicilioNuevo = new FormDomicilioNuevo(Convert.ToInt32(txtIdInterno.Text)))
            {  
                // Aquí se abre el FormularioB
                if (formDomicilioNuevo.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    bool isDomicilioCreado = formDomicilioNuevo.isCreadoDomicilioGlobal;
                    if (isDomicilioCreado)
                    {

                        tabInterno.Enabled = false;
                        this.CargarDataGridDomicilios();
                        txtIdDomicilio.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        txtCiudad.Text = string.Empty;
                        txtMunicipio.Text = string.Empty;
                        txtDepartamento.Text = string.Empty;
                        txtProvincia.Text = string.Empty;
                        txtPais.Text = string.Empty;
                        txtZonaResidencia.Text = string.Empty;
                        txtTelefono.Text = string.Empty;
                        chkVigente.Checked = false;
                        txtFechaCarga.Text = string.Empty;
                        txtOrganismoCarga.Text = string.Empty;
                        txtUsuarioCarga.Text = string.Empty;
                        tabInterno.Enabled = true;
                        tabInterno.Enabled = true;
                    }
                }
            }
        }

        private void dtgDomicilios_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgDomicilios.SelectedRows.Count > 0)
                {
                    int idDomiciio;
                    idDomiciio = Convert.ToInt32(dtgDomicilios.CurrentRow.Cells["ID"].Value.ToString());


                    if (idDomiciio > 0)
                    {
                        txtIdDomicilio.Text = idDomiciio.ToString();
                        txtDireccion.Text = "Barrio: " + dtgDomicilios.CurrentRow.Cells["Barrio"].Value.ToString()
                            + " - " + dtgDomicilios.CurrentRow.Cells["Direccion"].Value.ToString();
                        txtCiudad.Text = dtgDomicilios.CurrentRow.Cells["Ciudad"].Value?.ToString();
                        txtMunicipio.Text = dtgDomicilios.CurrentRow.Cells["Municipio"].Value?.ToString();
                        txtDepartamento .Text = dtgDomicilios.CurrentRow.Cells["Departamento"].Value?.ToString();
                        txtProvincia.Text = dtgDomicilios.CurrentRow.Cells["Provincia"].Value?.ToString();
                        txtPais.Text = dtgDomicilios.CurrentRow.Cells["Pais"].Value?.ToString();
                        txtZonaResidencia.Text = dtgDomicilios.CurrentRow.Cells["ZonaResidencia"].Value?.ToString();
                        txtTelefono.Text = dtgDomicilios.CurrentRow.Cells["Telefono"].Value?.ToString();
                        chkVigente.Checked = Convert.ToBoolean(dtgDomicilios.CurrentRow.Cells["Vigente"].Value.ToString());
                        txtFechaCarga.Text = Convert.ToDateTime(dtgDomicilios.CurrentRow.Cells["FechaCarga"].Value).ToString("dd/MM/yyyy");
                        txtOrganismoCarga.Text = dtgDomicilios.CurrentRow.Cells["OrganismoCarga"].Value?.ToString();
                        txtUsuarioCarga.Text = dtgDomicilios.CurrentRow.Cells["Usuario"].Value?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una traslado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnEditarDomicilio_Click(object sender, EventArgs e)
        {
            if (txtIdDomicilio.Text == null || txtIdDomicilio.Text == "")
            {
                MessageBox.Show("Debe seleccionar un domicilio", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkVigente.Checked == false)
            {
                MessageBox.Show("Solo se puede modificar el domicilio vigente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FormDomiclioEditar formDomicilioEditar = new FormDomiclioEditar(Convert.ToInt32(txtIdDomicilio.Text)))
            {
                // Aquí se abre el FormularioB
                if (formDomicilioEditar.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    bool isDomicilioEditado = formDomicilioEditar.isEditadoDomicilioGlobal;
                    if (isDomicilioEditado)
                    {

                        tabInterno.Enabled = false;
                        this.CargarDataGridDomicilios();
                        
                        this.LimpiarControlesDomicilio();
                    }
                }
            }
        }

        private void btnAnularDomicilio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdDomicilio.Text))
            {
                MessageBox.Show("Debe seleccionar un domicilio", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtDetalleAnulardomicilio.Enabled = true;
            btnGuardarAnulardomicilio.Enabled = true;
            btnCancelarAnulardomicilio.Enabled = true;
            btnAnularDomicilio.Enabled = false;
        }

        private void btnCancelarAnulardomicilio_Click(object sender, EventArgs e)
        {
            txtDetalleAnulardomicilio.Text = string.Empty;
            txtDetalleAnulardomicilio.Enabled = false;
            btnGuardarAnulardomicilio.Enabled = false;
            btnCancelarAnulardomicilio.Enabled = false;
            btnAnularDomicilio.Enabled = true;

        }

        //METODO LIMPIAR CONTROLES DOMICILIO
        private void LimpiarControlesDomicilio()
        {
            txtIdDomicilio.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtMunicipio.Text = string.Empty;
            txtDepartamento.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            txtPais.Text = string.Empty;
            txtZonaResidencia.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            chkVigente.Checked = false;
            txtFechaCarga.Text = string.Empty;
            txtOrganismoCarga.Text = string.Empty;
            txtUsuarioCarga.Text = string.Empty;
            tabInterno.Enabled = true;
        }
        //FIN METODO LIMPIAR CONTROLES DOMICILIO

        //METODO PARA OBTENER LA LISTA DE DOMICILIOS Y CARGARLO EN UN DATA GRID 
        async private void CargarDataGridDomicilios()
        {
            NDomicilioInterno nDomicilioInterno = new NDomicilioInterno();

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("El interno no esta cargado", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (List<DDomicilioInterno> listaDomicilios, string errorResponse) = await nDomicilioInterno.ListaDomiciliosXInterno(Convert.ToInt32(txtIdInterno.Text));

            if (listaDomicilios == null)
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaDomicilios
                .Select(c => new
                {
                    Id = c.id_domicilio_interno,
                    Vigente = c.vigente,
                    Barrio = c.barrio,
                    Direccion = c.direccion + " N° " + c.numero_dom,
                    Ciudad = c.ciudad,
                    Municipio = c.municipio.municipio,
                    Departamento = c.departamento.departamento,
                    Provincia = c.provincia.provincia,
                    Pais = c.pais.pais,
                    ZonaResidencia = c.zona_residencia.zona_residencia,
                    Telefono = c.telefono,
                    FechaCarga = c.fecha_carga,
                    OrganismoCarga = c.organismo.organismo,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgDomicilios.DataSource = datosfiltrados;

            if (listaDomicilios.Count == 0)
            {
                MessageBox.Show("No se encontraron registros.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dtgDomicilios.Columns[0].Width = 30;
                dtgDomicilios.Columns[1].Width = 60;
                dtgDomicilios.Columns[2].Width = 150;
                dtgDomicilios.Columns[3].Width = 200;
                dtgDomicilios.Columns[4].Width = 100;
                dtgDomicilios.Columns[5].Width = 100;
                dtgDomicilios.Columns[6].Width = 100;

                dtgDomicilios.Focus();
            }
        }
        //FIN METODO PARA OBTENER LA LISTA DE CAUSAS EN UN DATA GRID .............................

        private async void btnGuardarAnulardomicilio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdDomicilio.Text))
            {
                MessageBox.Show("Debe seleccionar un domicilio", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDetalleAnulardomicilio.Text == string.Empty)
            {
                MessageBox.Show("Debe completar el detalle.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDetalleAnulardomicilio.Focus();
                return;
            }

            if (txtDetalleAnulardomicilio.Text.Length > 200)
            {
                MessageBox.Show("El detalle debe tener hasta 200 caracteres.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDetalleAnulardomicilio.Focus();
                return;
            }

            NDomicilioInterno nDomicilioInterno = new NDomicilioInterno();

            var dataAnular = new
            {
                detalle_eliminado = txtDetalleAnulardomicilio.Text
            };

            string dataEnviar = JsonConvert.SerializeObject(dataAnular);

            tabInterno.Enabled = false;
            (bool respuestaEditar, string errorResponse) = await nDomicilioInterno.AnularDomicilio(Convert.ToInt32(txtIdDomicilio.Text), dataEnviar);
            tabInterno.Enabled = true;

            //verificar respuesta de la peticion
            if (respuestaEditar)
            {

                MessageBox.Show("El domicilio se anulo correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.LimpiarControlesDomicilio();

                txtDetalleAnulardomicilio.Text = string.Empty;
                txtDetalleAnulardomicilio.Enabled = false;
                btnGuardarAnulardomicilio.Enabled = false;
                btnCancelarAnulardomicilio.Enabled = false;
                btnAnularDomicilio.Enabled = true;

                this.CargarDataGridDomicilios();
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion DOMICILIOS
        //FIN REGION DOMICILIOS.......................................................
        //........................................................................


    }
}
