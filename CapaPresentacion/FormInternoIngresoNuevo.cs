using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
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
    }
}
