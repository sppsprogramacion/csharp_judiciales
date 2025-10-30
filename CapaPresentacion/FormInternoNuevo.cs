using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
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
            (DCaracteristicasPersonales caracteristicasPersonales, string errorResponse) = await nListasGenerales.ListaCaracteristicasGenerales();

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
                cmbOjosColor.ValueMember = "id_ojos_color";
                cmbOjosColor.DisplayMember = "ojos_color";
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


        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NInterno nInterno = new NInterno();


            var data = new
            {
                prontuario = Convert.ToInt32(txtProntuario.Text),
                dni = Convert.ToInt32(txtDni.Text),
                apellido = txtApellido.Text,
                nombre = txtNombre.Text,
                alias = txtAlias.Text,
                sexo_id = Convert.ToInt32(cmbSexo.SelectedValue.ToString()),
                talla = Convert.ToInt32(txtTalla.Text),
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
                fecha_nacimiento = dtpFechaNacimiento.Value,
                estado_civil_id = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString()),
                zona_residencia_id = cmbZonaResidencia.SelectedValue.ToString(),
                telefono = txtTelefono.Text,
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
                    this.Close();
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
            txtTelefono.Enabled = habilitar;
            txtTelefono.Text = "";
            cmbEstadoCivil.Enabled = habilitar;
            cmbNacionalidad.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }//FIN HABILITAR CONTROLES...............................................

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
