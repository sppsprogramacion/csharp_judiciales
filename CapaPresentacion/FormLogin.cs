using CapaDatos;
using CapaNegocio;
using CommonCache;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            NAuth nAuth = new NAuth();

            var data = new
            {
                dni = Convert.ToInt32(txtUsuario.Text),
                clave = txtContrasenia.Text
            };

            string dataLogin = JsonConvert.SerializeObject(data);

            (bool acceso, string error) = await nAuth.LoginUsuario(dataLogin);

            if (acceso)
            {
                CurrentUser currentUser = CurrentUser.Instance;

                MessageBox.Show("Bienvenido " + currentUser.nombre + " " + currentUser.apellido, "Accesso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Roles " + currentUser.roles[1]);
                MessageBox.Show("Token: " + SessionManager.Token);
                //FormVisitas formVisitas = new FormVisitas();
                FormPrincipal formPrincipal = new FormPrincipal();

                this.Hide();
                formPrincipal.Show();
                //formVisitas.Show();
            }
            else
            {
                MessageBox.Show($"{error}", "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
