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
    public partial class FormCuentaUsuario : Form
    {
        private int idUsuarioGlobal = 0;
        public FormCuentaUsuario()
        {
            InitializeComponent();            
        }

        private async void FormCuentaUsuario_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);


            NUsuario nUsuario = new NUsuario();
            this.Enabled = false;
            (DUsuario usuarioResponse, string errorResponse) = await nUsuario.BuscarUsuarioMiCuenta();
            this.Enabled = true;


            if (usuarioResponse == null)
            {

                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //CARGAR DATOS DEL CIUDADANO
            txtApellido.Text = usuarioResponse.apellido;
            txtNombre.Text = usuarioResponse.nombre;
            txtDni.Text = usuarioResponse.dni.ToString();
            txtLegajo.Text = usuarioResponse.legajo.ToString();
            txtSexo.Text = usuarioResponse.sexo.sexo;
            txtTelefono.Text = usuarioResponse.telefono;
            txtOrganismo.Text = usuarioResponse.organismo.organismo;
            txtEmail.Text = usuarioResponse.email;
            txtRoles.Text = string.Join(", ", usuarioResponse.roles);
            
        }


        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtCotraseniaActual.Text.Trim() == string.Empty){
                MessageBox.Show("La <CONTRASEÑA ACTUAL> esta vacia.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContrasenia.Text.Trim() == string.Empty)
            {
                MessageBox.Show("La <NUEVA CONTRASEÑA> esta vacia.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContrasenia.Text.Trim() != txtContraseniaRepetir.Text.Trim())
            {
                MessageBox.Show("<NUEVA CONTRASEÑA> y <REPETIR CONTRASEÑA> deben ser iguales", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NUsuario nUsuario = new NUsuario();

            var data = new
            {
                clave_actual = txtCotraseniaActual.Text.Trim(),
                clave = txtContrasenia.Text.Trim()
            };

            string dataEditar = JsonConvert.SerializeObject(data);

            try
            {
                this.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nUsuario.CambiarMiPassword( dataEditar);
                this.Enabled = true;

                if (respuestaEditar)
                {
                    MessageBox.Show("El cambio de contraseña se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCotraseniaActual.Text = string.Empty;
                    txtContrasenia.Text = string.Empty;
                    txtContraseniaRepetir.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCotraseniaActual.Text = string.Empty;
            txtContrasenia.Text = string.Empty;
            txtContraseniaRepetir.Text = string.Empty;
        }
    }
}
