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
    public partial class FormInternoVer : Form
    {
        //VARIABLES GLOBALES
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
                lblMensajeIngreso.Text = "Alojado en: " + this.ingresoInternoGlobal.organismo_alojamiento.organismo;
                cmbOrganismoExternoProcedencia.Text = ingresoInternoGlobal.organismo_externo.organismo_externo.ToString();
                dtpFechaIngresoSpps.Text = this.ingresoInternoGlobal.fecha_primer_ingreso.ToShortDateString();
                cmbOrganismoSppsProcesencia.Text = ingresoInternoGlobal.organismo_procedencia.organismo.ToString();
                txtProntuarioPolicial.Text = this.ingresoInternoGlobal.prontuario_policial.ToString();
                cmbEstadoProcesal.Text = this.ingresoInternoGlobal.estado_procesal.estado_procesal;
                cmbJurisdiccion.Text = this.ingresoInternoGlobal.jurisdiccion.jurisdiccion;
                cmbOtraJurisdiccion.Text = this.ingresoInternoGlobal.otra_jurisdiccion.jurisdiccion;
                cmbReingreso.Text = this.ingresoInternoGlobal.reingreso.reingreso;
                txtNumeroReingreso.Text = this.ingresoInternoGlobal.numero_reingreso.ToString();
                dtpFechaAlojamiento.Text = this.ingresoInternoGlobal.fecha_alojamiento.ToShortDateString();


                                
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
            if (this.ingresoInternoGlobal != null)
            {
                bool trasladoMiunidad = false;

                //el interno esta alojado en otra unidad y no tiene autorizacion para ingresarlo a mi unidad
                if (!trasladoMiunidad)
                {
                    MessageBox.Show("El interno ya se encuentra alojado en una unidad", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //el interno esta alojado en otra unidad y SI tiene autorizacion para ingresarlo a mi unidad
                MessageBox.Show("Tiene autorizacion para ingresar el interno a su unidad", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chkIngresarMiunidad.Checked = true;
                chkIngresarMiunidad.Visible = true;
                dtpFechaAlojamientoMiUnidad.Visible = true;
            }


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

            }
            //fin Carga de combos sobre  listas para ingreso
        }

        
    }
}
