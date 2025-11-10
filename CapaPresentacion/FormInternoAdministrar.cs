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
    public partial class FormInternoAdministrar : Form
    {
        //VARIABLES GLOBALES
        DInterno dInternoGlobal = new DInterno();

        public FormInternoAdministrar()
        {
            InitializeComponent();
        }

        private async void FormInternoAdministrar_Load(object sender, EventArgs e)
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
                cmbOjosTamanio.DataSource = caracteristicasPersonales.tamanio;

                //NARIZ FORMA
                cmbNarizForma.ValueMember = "id_nariz_forma";
                cmbNarizForma.DisplayMember = "nariz_forma";
                cmbNarizForma.DataSource = caracteristicasPersonales.nariz_forma;

                //NARIZ TAMAÑO
                cmbNarizTamanio.ValueMember = "id_tamanio";
                cmbNarizTamanio.DisplayMember = "tamanio";
                cmbNarizTamanio.DataSource = caracteristicasPersonales.tamanio;

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
            //fin Carga de combos sobre Caracteristicas generales

            //Carga de combos sobre DatosFiliatorios
            (DDatosFiliatorios datosFiliatorios, string errorResponseDatosFiliatorios) = await nListasGenerales.ListasDatosFilistorios();

            if (datosFiliatorios == null)
            {
                MessageBox.Show("Advertencia al cargar los datos filiatorios: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

                //Carga de combo zona residencia
                NZonaResidencia nZonaResidencia = new NZonaResidencia();
                cmbZonaResidencia.ValueMember = "id_zona_residencia";
                cmbZonaResidencia.DisplayMember = "zona_residencia";
                cmbZonaResidencia.DataSource = datosFiliatorios.zona_residencia;
            }
            //fin Carga de combos sobre DatosFiliatorios

            //CARGAR DATOS DEL INTERNO
            int idInterno;
            //acceder a la instancia de FormTramites abierta.
            FormInternos formInternos = Application.OpenForms["FormInternos"] as FormInternos;
            NInterno nInterno = new NInterno();

            //BUSCAR CIUDADANO CON EL ID DEL FORMULARIO DE BUSQUEDA (formVisitas)
            tabInterno.Enabled = false;
            idInterno = Convert.ToInt32(formInternos.idInternoGlobal);
            (DInterno dInternoResponse, string errorInternoResponse) = await nInterno.BuscarInternoXID(idInterno);


            this.dInternoGlobal = dInternoResponse;

            if (this.dInternoGlobal == null)
            {
                tabInterno.Enabled = false;

                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            dtpFechaNacimiento.Text = this.dInternoGlobal.fecha_nacimiento.ToShortDateString();
            cmbEstadoCivil.Text = this.dInternoGlobal.estado_civil.estado_civil;
            cmbZonaResidencia.Text = this.dInternoGlobal.zona_residencia.zona_residencia;
            txtTelefono.Text = this.dInternoGlobal.telefono;
            
            txtPadre.Text = this.dInternoGlobal.padre;
            txtMadre.Text = this.dInternoGlobal.madre;
            txtParientes.Text = this.dInternoGlobal.parientes;

            //txtFechaAlta.Text = this.dCiudadanoGlo.fecha_alta.ToShortDateString();
            //txtOrganismoAlta.Text = this.dCiudadanoGlo.organismo_alta.organismo;
            //pictureFoto.Load(this.dCiudadanoGlo.foto);

            tabInterno.Enabled = true;
        }
                
    }
}
