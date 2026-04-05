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
    public partial class FormInternoNuevo : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        DTablasIngresoInterno tablasIngresoInterno = null;

        public FormInternoNuevo()
        {
            InitializeComponent();
        }

        private async void FormInternoNuevo_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);


            //Carga de combos sobre Caracteristicas generales
            NListasGenerales nListasGenerales = new NListasGenerales();
            (DCaracteristicasPersonales caracteristicasPersonales, string errorResponse) = await nListasGenerales.ListaCaracteristicasPersonales();

            if (caracteristicasPersonales == null)
            {
                MessageBox.Show("Advertencia al cargar las caracteristicas personales: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            else
            {
                //PIEL
                cmbPiel.ValueMember = "id_piel";
                cmbPiel.DisplayMember = "piel";
                cmbPiel.DataSource = caracteristicasPersonales.piel;

                //OJOS COLOR
                cmbOjosColor.ValueMember = "id_ojo_color";
                cmbOjosColor.DisplayMember = "ojo_color";
                cmbOjosColor.DataSource = caracteristicasPersonales.ojos_color;

                //OJOS TAMAÑO
                cmbOjosTamanio.ValueMember = "id_tamanio";
                cmbOjosTamanio.DisplayMember = "tamanio";
                cmbOjosTamanio.DataSource = caracteristicasPersonales.tamanio.ToList();

                //NARIZ FORMA
                cmbNarizForma.ValueMember = "id_nariz_forma";
                cmbNarizForma.DisplayMember = "nariz_forma";
                cmbNarizForma.DataSource = caracteristicasPersonales.nariz_forma;

                //NARIZ TAMAÑO
                cmbNarizTamanio.ValueMember = "id_tamanio";
                cmbNarizTamanio.DisplayMember = "tamanio";
                cmbNarizTamanio.DataSource = caracteristicasPersonales.tamanio.ToList();

                //PELO COLOR
                cmbPeloColor.ValueMember = "id_pelo_color";
                cmbPeloColor.DisplayMember = "pelo_color";
                cmbPeloColor.DataSource = caracteristicasPersonales.pelo_color;

                //PELO TIPO
                cmbPeloTipo.ValueMember = "id_pelo_tipo";
                cmbPeloTipo.DisplayMember = "pelo_tipo";
                cmbPeloTipo.DataSource = caracteristicasPersonales.pelo_tipo;

                //SEXO
                cmbSexo.ValueMember = "id_sexo";
                cmbSexo.DisplayMember = "sexo";
                cmbSexo.DataSource = caracteristicasPersonales.sexo;


            }


            //Carga de combos sobre DatosFiliatorios
            (DDatosFiliatorios datosFiliatorios, string errorResponseDatosFiliatorios) = await nListasGenerales.ListasDatosFilistorios();

            if (datosFiliatorios == null)
            {
                MessageBox.Show("Advertencia al cargar los datos filiatorios: " + errorResponseDatosFiliatorios, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                //Carga de combo nacionalidad
                cmbNacionalidad.ValueMember = "id_nacionalidad";
                cmbNacionalidad.DisplayMember = "nacionalidad";
                cmbNacionalidad.DataSource = datosFiliatorios.nacionalidad;

                //Carga de combo estado civil
                cmbEstadoCivil.ValueMember = "id_estado_civil";
                cmbEstadoCivil.DisplayMember = "estado_civil";
                cmbEstadoCivil.DataSource = datosFiliatorios.estado_civil;

                //NIVELES EDUCACION
                cmbNivelEducacion.ValueMember = "id_nivel_educacion";
                cmbNivelEducacion.DisplayMember = "nivel_educacion";
                cmbNivelEducacion.DataSource = datosFiliatorios.niveles_educacion;

                //RELIGIONES
                cmbReligion.ValueMember = "id_religion";
                cmbReligion.DisplayMember = "religion";
                cmbReligion.DataSource = datosFiliatorios.religiones;

                //OCUPACIONES
                cmbUltimaOcupacion.ValueMember = "id_ocupacion";
                cmbUltimaOcupacion.DisplayMember = "ocupacion";
                cmbUltimaOcupacion.DataSource = datosFiliatorios.ocupaciones;
            }
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NInterno nInterno = new NInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new NuevoInternoDatos
            {
                txtApellido = txtApellido.Text,
                txtNombre = txtNombre.Text,
                txtProntuario = txtProntuario.Text,
                txtDni = txtDni.Text,
                txtAlias = txtAlias.Text,
                cmbSexo = cmbSexo.SelectedValue?.ToString() ?? string.Empty,
                txtTalla = txtTalla.Text,
                cmbPiel = cmbPiel.SelectedValue?.ToString() ?? string.Empty,
                cmbOjosColor = cmbOjosColor.SelectedValue?.ToString() ?? string.Empty,
                cmbOjosTamanio = cmbOjosTamanio.SelectedValue?.ToString() ?? string.Empty,
                cmbNarizForma = cmbNarizForma.SelectedValue?.ToString() ?? string.Empty,
                cmbNarizTamanio = cmbNarizTamanio.SelectedValue?.ToString() ?? string.Empty,
                cmbPeloTipo = cmbPeloTipo.SelectedValue?.ToString() ?? string.Empty,
                cmbPeloColor = cmbPeloColor.SelectedValue?.ToString() ?? string.Empty,
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

            var validator = new CrearInternoValidation();
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
                prontuario = Convert.ToInt32(txtProntuario.Text),
                dni = Convert.ToInt32(txtDni.Text),
                apellido = txtApellido.Text,
                nombre = txtNombre.Text,
                alias = txtAlias.Text,
                sexo_id = Convert.ToInt32(cmbSexo.SelectedValue.ToString()),
                talla = txtTalla.Text,
                ojos_color_id = cmbOjosColor.SelectedValue.ToString(),
                ojos_tamanio_id = cmbOjosTamanio.SelectedValue.ToString(),
                nariz_tamanio_id = cmbNarizTamanio.SelectedValue.ToString(),
                nariz_forma_id = cmbNarizForma.SelectedValue.ToString(),
                pelo_tipo_id = cmbPeloTipo.SelectedValue.ToString(),
                pelo_color_id = cmbPeloColor.SelectedValue.ToString(),
                piel_id = cmbPiel.SelectedValue.ToString(),
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

            string dataInterno = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DInterno interno, string errorInterno) = await nInterno.CrearInterno(dataInterno);


                if (interno != null)
                {

                    MessageBox.Show("Interno creado correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtIdInterno.Text = interno.id_interno.ToString();
                    gboxDatosInterno.Enabled = false;

                    //Carga de combos sobre listas para ingreso
                    NListasGenerales nListasGenerales = new NListasGenerales();
                    (DTablasIngresoInterno tablasIngresoInternoResponse, string errorResponse) = await nListasGenerales.ListasTablasIngresoInterno();
                    this.tablasIngresoInterno = tablasIngresoInternoResponse;

                    if (this.tablasIngresoInterno == null)
                    {
                        MessageBox.Show("Advertencia al cargar las listas para el ingreso: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        //ORGANISMOS EXTERNOS
                        cmbOrganismoExternoProcedencia.ValueMember = "id_organismo_externo";
                        cmbOrganismoExternoProcedencia.DisplayMember = "organismo_externo";
                        cmbOrganismoExternoProcedencia.DataSource = this.tablasIngresoInterno.organismos_externos;

                        //ORGANISMOS
                        cmbOrganismoSppsProcesencia.ValueMember = "id_organismo";
                        cmbOrganismoSppsProcesencia.DisplayMember = "organismo";
                        cmbOrganismoSppsProcesencia.DataSource = this.tablasIngresoInterno.organismos_spps.ToList();

                        //ESTADO PROCESAL
                        cmbEstadoProcesal.ValueMember = "id_estado_procesal";
                        cmbEstadoProcesal.DisplayMember = "estado_procesal";
                        cmbEstadoProcesal.DataSource = this.tablasIngresoInterno.estado_procesal;

                        //JURISDICCION
                        cmbJurisdiccion.ValueMember = "id_jurisdiccion";
                        cmbJurisdiccion.DisplayMember = "jurisdiccion";
                        cmbJurisdiccion.DataSource = this.tablasIngresoInterno.jurisdiccion.ToList();

                        //OTRA JURISDICCION
                        cmbOtraJurisdiccion.ValueMember = "id_jurisdiccion";
                        cmbOtraJurisdiccion.DisplayMember = "jurisdiccion";
                        cmbOtraJurisdiccion.DataSource = this.tablasIngresoInterno.jurisdiccion.ToList();

                        //REINGRESO
                        cmbReingreso.ValueMember = "id_reingreso";
                        cmbReingreso.DisplayMember = "reingreso";
                        cmbReingreso.DataSource = this.tablasIngresoInterno.reingreso;

                        //Tipos defensor
                        cmbTipoDefensor.ValueMember = "id_tipo_defensor";
                        cmbTipoDefensor.DisplayMember = "tipo_defensor";
                        cmbTipoDefensor.DataSource = this.tablasIngresoInterno.tipos_defensor;

                    }
                    //fin Carga de combos sobre  listas para ingreso

                    gboxIngresarInterno.Enabled = true;
                }
                else
                {

                    MessageBox.Show(errorInterno, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }
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
            dtpFechaNacimiento.Enabled = habilitar;
            dtpFechaNacimiento.ResetText();
            //txtTelefono.Enabled = habilitar;
            //txtTelefono.Text = "";
            cmbEstadoCivil.Enabled = habilitar;
            cmbNacionalidad.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }//FIN HABILITAR CONTROLES...............................................

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

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
                fecha_primer_ingreso = dtpFechaPrimerIngreso.Value,
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
                    
                    //ORGANISMOS
                    cmbOrganismoAlojamiento.ValueMember = "id_organismo";
                    cmbOrganismoAlojamiento.DisplayMember = "organismo";
                    cmbOrganismoAlojamiento.DataSource = this.tablasIngresoInterno.organismos_spps.ToList();

                    cmbOrganismoAlojamiento.SelectedValue = ingreso.organismo_alojamiento_id;
                    txtFechaCarga.Text = ingreso.fecha_carga.ToShortDateString();

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
    }
}
