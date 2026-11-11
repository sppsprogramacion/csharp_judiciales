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
    public partial class FormInternoProntuario : Form
    {
        //privadas
        private int idInternoGlobal = 0;

        //globales
        public bool isPronturarioModificado = false;
        public DInterno dInternoGlobal { get; private set; }

        public FormInternoProntuario(int idInterno, int prontuario, int numAlcaidia1, int numAlcaidia2, int numAlcaidia3)
        {
            InitializeComponent();

            idInternoGlobal = idInterno;
            txtIdInterno.Text = idInterno.ToString();
            txtProntuario.Text = prontuario.ToString();
            txtNumAlcaidia1.Text = numAlcaidia1.ToString();
            txtNumAlcaidia2.Text = numAlcaidia2.ToString();
            txtNumAlcaidia3.Text = numAlcaidia3.ToString();

        }

        private void FormInternoProntuario_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);


        }

        private async void btnGuardarEditarDatosPrincipales_Click(object sender, EventArgs e)
        {
            NInterno nInterno = new NInterno();
            string dataEnviar;

            if (txtIdInterno.Text == null || txtIdInterno.Text == "")
            {
                MessageBox.Show("Debe tener un interno cargado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevoNumero.Text == null || txtNuevoNumero.Text == "")
            {
                MessageBox.Show("Debe ingresar el nuevo valor.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intenta convertir el texto a entero y lo guarda en la variable 'numero'
            if (int.TryParse(txtNuevoNumero.Text, out int numero))
            {
                // Es un número entero válido. Aquí puedes usar la variable 'numero'
                //MessageBox.Show($"Número válido: {numero}");
            }
            else
            {
                // No es un entero (contiene letras, decimales, está vacío o es demasiado grande)
                MessageBox.Show("Por favor, ingrese un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevoNumero.Focus();
                txtNuevoNumero.SelectAll();

                return;
            }
            //fin validaciones

            var dataInterno = new
            {
                numero_cambio = Convert.ToInt32(txtNuevoNumero.Text)
            };

            dataEnviar = JsonConvert.SerializeObject(dataInterno);

            (bool respuestaEditar, string errorResponse) = await nInterno.EditarProntuario(Convert.ToInt32(txtIdInterno.Text), dataEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                this.BuscarInterno();
                
                this.isPronturarioModificado = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }


        private void btnCancelarEditarDatosPrincipales_Click(object sender, EventArgs e)
        {
            txtNuevoNumero.Text = string.Empty;
            this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
            this.Close();
        }

        //BUSCAR INTERNO
        private async void BuscarInterno()
        {
            int idInterno;
            NInterno nInterno = new NInterno();
            DInterno dInterno = new DInterno();

            idInterno = Convert.ToInt32(this.idInternoGlobal);
            
            this.Enabled = false;
            (DInterno dInternoResponse, string errorInternoResponse) = await nInterno.BuscarInternoXID(idInterno);
            this.Enabled = true;

            dInterno = dInternoResponse;

            if (dInterno == null)
            {
                MessageBox.Show("No se encontro informaciòn del interno: " + errorInternoResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.dInternoGlobal = dInterno;
           
        }

        //FIN BUSCAR INTERNO................................................................
    }
}
