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
    public partial class FormAdministrarUsuarios : Form
    {
        public FormAdministrarUsuarios()
        {
            InitializeComponent();
        }

        private void FormAdministrarUsuarios_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);


        }

        private void btnVerUsuariosRestriccion_Click(object sender, EventArgs e)
        {
            this.CargarDataGridUsuarios();
        }

        private void dtgvProhibiciones_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgUsuarios.SelectedRows.Count > 0)
                {
                    int idUsuario;
                    idUsuario = Convert.ToInt32(dtgUsuarios.CurrentRow.Cells["ID"].Value.ToString());

                    if (idUsuario > 0)
                    {
                        txtIdUsuario.Text = idUsuario.ToString();
                        txtRoles.Text = dtgUsuarios.CurrentRow.Cells["Roles"].Value.ToString();
                        txtApellido.Text = dtgUsuarios.CurrentRow.Cells["Apellido"].Value.ToString();
                        txtNombre.Text = dtgUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
                        txtDni.Text = dtgUsuarios.CurrentRow.Cells["Dni"].Value.ToString();
                        txtLegajo.Text = dtgUsuarios.CurrentRow.Cells["Legajo"].Value.ToString();
                        txtSexo.Text = dtgUsuarios.CurrentRow.Cells["Sexo"].Value.ToString();
                        txtEmail.Text = dtgUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                        txtTelefono.Text = dtgUsuarios.CurrentRow.Cells["Telefono"].Value.ToString();
                        txtOrganismo.Text = dtgUsuarios.CurrentRow.Cells["Organismo"].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una usuario.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private async void btnDeshabilitarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Debe seleccionar una usuario.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            NUsuario nUsuario = new NUsuario();

            try
            {
                this.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nUsuario.DeshabilitarUsuarioDelSistema(Convert.ToInt32(txtIdUsuario.Text));
                this.Enabled = true;

                if (respuestaEditar)
                {
                    MessageBox.Show("Se quito correctamente al usuario del sistema", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.CargarDataGridUsuarios();

                    txtIdUsuario.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtDni.Text = string.Empty;
                    txtLegajo.Text = string.Empty;
                    txtSexo.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtOrganismo.Text = string.Empty;
                    txtRoles.Text = string.Empty;

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

        //METODO PARA OBTENER LA LISTA DE USUARIOS DE RESTRICCION
        async private void CargarDataGridUsuarios()
        {
            NUsuario nUsuario = new NUsuario();
            this.Enabled = false;
            (List<DUsuario> listaUsuariosResponse, string errorResponse) = await nUsuario.ListaUsuariosActivos();
            this.Enabled = true;

            if (listaUsuariosResponse == null)
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaUsuariosResponse
                .Select(c => new
                {
                    Id = c.id_usuario,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    Dni = c.dni,
                    Legajo = c.legajo,
                    Sexo = c.sexo.sexo,
                    Email = c.email,
                    Telefono = c.telefono,
                    Organismo = c.organismo.organismo,
                    Roles = string.Join(", ", c.roles),

                })
                .ToList();

            dtgUsuarios.DataSource = datosfiltrados;

            if (listaUsuariosResponse.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgUsuarios.Columns[0].Width = 50;
                dtgUsuarios.Columns[1].Width = 150;
                dtgUsuarios.Columns[2].Width = 150;
                dtgUsuarios.Columns[3].Width = 80;
                dtgUsuarios.Columns[4].Width = 80;
                dtgUsuarios.Columns[5].Width = 80;
                dtgUsuarios.Columns[6].Width = 150;
                dtgUsuarios.Columns[7].Width = 80;
                dtgUsuarios.Columns[8].Width = 180;
            }
        }

        //FIN METODO  PARA OBTENER LA LISTA DE USUARIOS DE RESTRICCION
        //............................................................................
    }
}
