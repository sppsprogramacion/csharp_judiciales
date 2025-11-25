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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion
{
    public partial class FormInternos : Form
    {
        //variable global id_ciudadano
        public int idInternoGlobal { get; set; }

        public FormInternos()
        {
            InitializeComponent();
        }

        private void FormInternos_Load(object sender, EventArgs e)
        {
            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

            
            List<DElegirBusquedaInterno> listaElegir = new List<DElegirBusquedaInterno>();

            listaElegir.Add(new DElegirBusquedaInterno
            {
                id_busqueda = "unidad",
                texto = "Mi unidad"
            });

            listaElegir.Add(new DElegirBusquedaInterno
            {
                id_busqueda = "todas",
                texto = "Todas las unidades"
            });

            cmbBusqueda.ValueMember = "id_busqueda";    // id
            cmbBusqueda.DisplayMember = "texto";  // texto
            cmbBusqueda.DataSource = listaElegir;

            // Seleccionar algo por defecto
            cmbBusqueda.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormInternoNuevo formInternoNuevo = new FormInternoNuevo();
            formInternoNuevo.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private async void btnBuscarApellido_Click(object sender, EventArgs e)
        {

            NInterno nInterno = new NInterno();
            (List<DInterno> listaInternos, string errorResponse) = await nInterno.ListaInternosXApellido(txtApellidoBusqueda.Text);

            if (listaInternos == null)
            {
                MessageBox.Show(errorResponse, "Internos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaInternos
                .Select(c => new
                {
                    ID = c.id_interno,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    Prontuario = c.prontuario,
                    Sexo = c.sexo.sexo
                    
                })
                .ToList();

            dtgvInternos.DataSource = datosFiltrados;

            if (listaInternos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvInternos.Columns[0].Width = 90;
                dtgvInternos.Columns[1].Width = 200;
                dtgvInternos.Columns[2].Width = 200;
                dtgvInternos.Columns[3].Width = 90;
                dtgvInternos.Columns[4].Width = 90;
            }
        }

        private void dtgvInternos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idInternoGlobal = Convert.ToInt32(dtgvInternos.CurrentRow.Cells["ID"].Value.ToString());

                if (dtgvInternos.SelectedRows.Count > 0)
                {
                    if (this.idInternoGlobal > 0)
                    {
                        if(cmbBusqueda.SelectedValue.ToString() == "unidad")
                        {
                            FormInternoAdministrar forminternoadministrar = new FormInternoAdministrar();
                            forminternoadministrar.ShowDialog();

                        }

                        if (cmbBusqueda.SelectedValue.ToString() == "todas")
                        {
                            FormInternoVer formInternoVer = new FormInternoVer();
                            formInternoVer.ShowDialog();

                        }
                        //FormInternoIngresoNuevo formInternoIngresoNuevo = new FormInternoIngresoNuevo();
                        //formInternoIngresoNuevo.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un interno.");
                    }
                }
            }
        }

        private void btnBuscarProntuario_Click(object sender, EventArgs e)
        {
            var opcion = cmbBusqueda.SelectedItem as DElegirBusquedaInterno;
            string id = opcion.id_busqueda;  // "unidad" o "todas"

            MessageBox.Show(id);

            //if (cmbBusqueda.SelectedValue != null)
            //{

            //    MessageBox.Show(cmbBusqueda.SelectedValue.ToString());
            //}
            //else
            //{
            //    MessageBox.Show("No hay selección.");
            //}
        }
    }

}
