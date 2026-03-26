using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CommonCache;
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
                texto = "Apellido en: Mi unidad"
            });

            listaElegir.Add(new DElegirBusquedaInterno
            {
                id_busqueda = "todas",
                texto = "Apellido en: Todas las unidades"
            });

            listaElegir.Add(new DElegirBusquedaInterno
            {
                id_busqueda = "prontuario",
                texto = "Prontuario"
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
            if (txtBusqueda.Text.Length < 2){
                MessageBox.Show("Debe ingresar al menos 2 caracteres en el cuadro de busqueda", "Internos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NInterno nInterno = new NInterno();
            List<DInterno> listaInternos = new List<DInterno>();

            if (cmbBusqueda.SelectedValue.ToString() == "unidad")
            {
                this.Enabled = false;
                (List<DInterno> listaInternosEncontrados, string errorResponse) = await nInterno.ListaInternosXApellido(txtBusqueda.Text);
                this.Enabled = true;

                if (listaInternosEncontrados == null)
                {
                    MessageBox.Show(errorResponse, "Internos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                listaInternos = listaInternosEncontrados;
            }

            if (cmbBusqueda.SelectedValue.ToString() == "todas")
            {
                this.Enabled = false;
                (List<DInterno> listaInternosEncontrados, string errorResponse) = await nInterno.ListaInternosXApellidoGeneral(txtBusqueda.Text);
                this.Enabled = true;

                if (listaInternosEncontrados == null)
                {
                    MessageBox.Show(errorResponse, "Internos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                listaInternos = listaInternosEncontrados;
            }

            if (cmbBusqueda.SelectedValue.ToString() == "prontuario")
            {
                int prontuarioX;
                try
                {
                    prontuarioX = int.Parse(txtBusqueda.Text);
                }
                catch
                {
                    MessageBox.Show("El prontuario debe ser un numero válido", "Internos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Enabled = false;
                (List<DInterno> listaInternosEncontrados, string errorResponse) = await nInterno.ListaInternosXProntuario(prontuarioX);
                this.Enabled = true;

                if (listaInternosEncontrados == null)
                {
                    MessageBox.Show(errorResponse, "Internos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                listaInternos = listaInternosEncontrados;
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
                MessageBox.Show("No se encontraron registros", "Internos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dtgvInternos.Columns[0].Width = 90;
                dtgvInternos.Columns[1].Width = 200;
                dtgvInternos.Columns[2].Width = 200;
                dtgvInternos.Columns[3].Width = 90;
                dtgvInternos.Columns[4].Width = 90;

                dtgvInternos.Focus();
            }
        }

        private async void dtgvInternos_KeyDown(object sender, KeyEventArgs e)
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
                        NIngresoInterno nIngreso = new NIngresoInterno();
                        this.Enabled = false;
                        (DIngresoInterno ingresoInterno, string errorResponse) = await nIngreso.BuscarxInterno(this.idInternoGlobal);
                        this.Enabled = true;

                        if (ingresoInterno == null)
                        {
                            MessageBox.Show("El interno no se encuentra alojado en una unidad", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            FormInternoVer formInternoVer = new FormInternoVer(null, this.idInternoGlobal, "consulta");
                            formInternoVer.ShowDialog();
                        }
                        else
                        {
                            if (ingresoInterno.organismo_alojamiento_id == CurrentUser.Instance.organismo.id_organismo)
                            {
                                FormInternoAdministrar forminternoadministrar = new FormInternoAdministrar(ingresoInterno);
                                forminternoadministrar.ShowDialog();

                            }
                            else
                            {
                                FormInternoVer formInternoVer = new FormInternoVer(ingresoInterno, ingresoInterno.interno_id, "consulta");
                                formInternoVer.ShowDialog();

                            }
                        }
                        
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
