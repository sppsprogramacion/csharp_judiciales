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
    public partial class FormInternoIngresoNuevo : Form
    {
        //VARIABLES GLOBALES
        DInterno dInternoGlobal = new DInterno();
        private ErrorProvider errorProvider = new ErrorProvider();

        public FormInternoIngresoNuevo()
        {
            InitializeComponent();
        }

        private async void FormInternoIngresoNuevo_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);


            //CARGAR DATOS DEL INTERNO
            int idInterno;
            //acceder a la instancia de FormTramites abierta.
            FormInternos formInternos = Application.OpenForms["FormInternos"] as FormInternos;
            NInterno nInterno = new NInterno();

            //BUSCAR INTERNO CON EL ID DEL FORMULARIO DE BUSQUEDA (formInternos)
            tabInterno.Enabled = false;
            idInterno = Convert.ToInt32(formInternos.idInternoGlobal);
            (DInterno dInternoResponse, string errorInternoResponse) = await nInterno.BuscarInternoXID(idInterno);


            this.dInternoGlobal = dInternoResponse;

            if (this.dInternoGlobal == null)
            {
                tabInterno.Enabled = false;

                MessageBox.Show(errorInternoResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

            //txtFechaAlta.Text = this.dCiudadanoGlo.fecha_alta.ToShortDateString();
            //txtOrganismoAlta.Text = this.dCiudadanoGlo.organismo_alta.organismo;
            //pictureFoto.Load(this.dCiudadanoGlo.foto);

            //Carga de combos sobre Caracteristicas generales
            NListasGenerales nListasGenerales = new NListasGenerales();
            (DTablasIngresoInterno tablasIngresoInterno, string errorResponse) = await nListasGenerales.ListasTablasIngresoInterno();

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
                cmbOrganismoSppsProcesencia.DataSource = tablasIngresoInterno.organismos_spps;

                //ESTADO PROCESAL
                cmbEstadoProcesal.ValueMember = "id_estado_procesal";
                cmbEstadoProcesal.DisplayMember = "estado_procesal";
                cmbEstadoProcesal.DataSource = tablasIngresoInterno.estado_procesal;

                //JURISDICCION
                cmbJurisdiccion.ValueMember = "id_jurisdiccion";
                cmbJurisdiccion.DisplayMember = "jurisdiccion";
                cmbJurisdiccion.DataSource = tablasIngresoInterno.jurisdiccion;

                //OTRA JURISDICCION
                cmbOtraJurisdiccion.ValueMember = "id_jurisdiccion";
                cmbOtraJurisdiccion.DisplayMember = "jurisdiccion";
                cmbOtraJurisdiccion.DataSource = tablasIngresoInterno.jurisdiccion;

                //REINGRESO
                cmbReingreso.ValueMember = "id_reingreso";
                cmbReingreso.DisplayMember = "reingreso";
                cmbReingreso.DataSource = tablasIngresoInterno.reingreso;

                

            }
            //fin Carga de combos sobre Caracteristicas generales

            tabInterno.Enabled = true;
        }

        private async void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            NIngresoInterno nIngreso = new NIngresoInterno();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            //var datosFormulario = new NuevoInternoDatos
            //{
            //    txtApellido = txtApellido.Text,
            //    txtNombre = txtNombre.Text,
            //    txtProntuario = txtProntuario.Text,
            //    txtDni = txtDni.Text,
            //    txtAlias = txtAlias.Text,
            //    cmbSexo = cmbSexo.SelectedValue?.ToString() ?? string.Empty,
            //    txtTalla = txtTalla.Text,
            //    cmbPiel = cmbPiel.SelectedValue?.ToString() ?? string.Empty,
            //    cmbOjosColor = cmbOjosColor.SelectedValue?.ToString() ?? string.Empty,
            //    cmbOjosTamanio = cmbOjosTamanio.SelectedValue?.ToString() ?? string.Empty,
            //    cmbNarizForma = cmbNarizForma.SelectedValue?.ToString() ?? string.Empty,
            //    cmbNarizTamanio = cmbNarizTamanio.SelectedValue?.ToString() ?? string.Empty,
            //    cmbPeloTipo = cmbPeloTipo.SelectedValue?.ToString() ?? string.Empty,
            //    cmbPeloColor = cmbPeloColor.SelectedValue?.ToString() ?? string.Empty,
            //    cmbNacionalidad = cmbNacionalidad.SelectedValue?.ToString() ?? string.Empty,
            //    cmbProvinciaNacimiento = cmbProvinciaNacimiento.SelectedValue?.ToString() ?? string.Empty,
            //    cmbDepartamentoNacimiento = cmbDepartamentoNacimiento.SelectedValue?.ToString() ?? string.Empty,
            //    dtpFechaNacimiento = dtpFechaNacimiento.Value,
            //    cmbEstadoCivil = cmbEstadoCivil.SelectedValue?.ToString() ?? string.Empty,
            //    cmbZonaResidencia = cmbZonaResidencia.SelectedValue?.ToString() ?? string.Empty,
            //    txtTelefono = txtTelefono.Text,
            //    txtPadre = txtPadre.Text,
            //    txtMadre = txtMadre.Text,
            //    txtParientes = txtParientes.Text,
            //};

            //var validator = new CrearInternoValidation();
            //var result = validator.Validate(datosFormulario);

            //if (!result.IsValid)
            //{
            //    MessageBox.Show("Complete correctamente los campos del formulario", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                fecha_primer_ingreso = dtpFechaPrimerIngreso.Value,
                organismo_externo_id = Convert.ToInt32(cmbOrganismoExternoProcedencia.SelectedValue.ToString()),
                organismo_procedencia_id = Convert.ToInt32(cmbOrganismoSppsProcesencia.SelectedValue.ToString()),
                fecha_alojamiento = dtpFechaAlojamiento.Value,
                estado_procesal_id = cmbEstadoProcesal.SelectedValue.ToString(),
                jurisdiccion_id = cmbJurisdiccion.SelectedValue.ToString(),
                otra_jurisdiccion_id = cmbOtraJurisdiccion.SelectedValue.ToString(),
                reingreso_id = Convert.ToInt32(cmbReingreso.SelectedValue.ToString()),
                numero_reingreso = Convert.ToInt32(txtNumeroReingreso.Text),
                prontuario_policial = txtProntuarioPolicial.Text

            };

            string dataIngreso = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nCiudadano.crearCiudadano(dataCiudadano);
                (DIngresoInterno ingreso, string errorIngreso) = await nIngreso.CrearIngreso(dataIngreso);


                if (ingreso != null)
                {

                    MessageBox.Show("Ingreso creado correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
