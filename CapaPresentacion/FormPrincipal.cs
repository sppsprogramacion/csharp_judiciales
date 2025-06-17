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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnVerVisitas_Click(object sender, EventArgs e)
        {
            FormVisitas formVisitas = new FormVisitas();

            formVisitas.ShowDialog();
        }

        private void btnCerrarSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVerInternos_Click(object sender, EventArgs e)
        {
            FormInternos formInternos = new FormInternos();

            formInternos.ShowDialog();
        }
    }
}
