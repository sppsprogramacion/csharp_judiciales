using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CommonCache;
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
    public partial class FormTraslados : Form
    {
        public FormTraslados()
        {
            InitializeComponent();
        }

        private void FormTraslados_Load(object sender, EventArgs e)
        {
            FormularioAyudas.AjustarFormulario(this);
        }

        private void btnVerTraslados_Click(object sender, EventArgs e)
        {
            this.CargarDataGridTraslados("todos");
        }

        private void btnPendientesSalieron_Click(object sender, EventArgs e)
        {
            this.CargarDataGridTraslados("pendiente_salieron");
        }

        private void btnPendientesIngreso_Click(object sender, EventArgs e)
        {
            this.CargarDataGridTraslados("pendiente_ingreso");
        }


        private void btnAceptarTraslado_Click(object sender, EventArgs e)
        {
            lblEstadoTraslado.Text = "Aceptar";
            this.HabilitarControlesAnularTraslado(true);
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            lblEstadoTraslado.Text = "Rechazar";
            this.HabilitarControlesAnularTraslado(true);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lblEstadoTraslado.Text = "ESTADO:";
            this.HabilitarControlesAnularTraslado(false);

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdTraslado.Text == null || txtIdTraslado.Text == "")
            {
                MessageBox.Show("Debe seleccionar un traslado para poder aceptar o rechazar.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtObsProcesarTraslado.Text == string.Empty)
            {
                MessageBox.Show("Debe completar el obs traslado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NTrasladoInterno nTrasladoInterno = new NTrasladoInterno();

            bool respuestaOk = false;
            string mensajeRespuesta = "";
            string dataEnviar;

            //determinar cual es la accion a realizar con la prohibicion
            //usar el respectivo metodo
            if (lblEstadoTraslado.Text == "Aceptar")
            {

                var dataAceptar = new
                {
                    obs_traslado = txtObsProcesarTraslado.Text,
                };

                dataEnviar = JsonConvert.SerializeObject(dataAceptar);

                groupAceptarRechazar.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nTrasladoInterno.AceptarTraslado(Convert.ToInt32(txtIdTraslado.Text), dataEnviar);
                groupAceptarRechazar.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El trasllado de acptó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }


            if (lblEstadoTraslado.Text == "Rechazar")
            {
                var dataCumplimentar = new
                {
                    obs_traslado = txtObsProcesarTraslado.Text,
                };

                dataEnviar = JsonConvert.SerializeObject(dataCumplimentar);

                groupAceptarRechazar.Enabled = false;
                (bool respuestaEditar, string errorResponse) = await nTrasladoInterno.RechazarTraslado(Convert.ToInt32(txtIdTraslado.Text), dataEnviar);
                groupAceptarRechazar.Enabled = true;

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El traslado se rechazó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                lblEstadoTraslado.Text = "ESTADO:";
                this.HabilitarControlesAnularTraslado(false);
                this.CargarDataGridTraslados("todos");
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //METODO PARA OBTENER LA LISTA DE TRASLADOS Y CARGARLO EN UN DATA GRID 
        async private void CargarDataGridTraslados(string tipoBusqueda)
        {
            //tipoBusqueda = todos, pendiente_ingreso, pendiente_salieron

            NTrasladoInterno nTrasladoInterno = new NTrasladoInterno();
            List<DTrasladoInterno> listaTraslados = new List<DTrasladoInterno>();

            if(tipoBusqueda == "todos")
            {

                (List<DTrasladoInterno> listaTrasladosResponse, string errorResponse) = await nTrasladoInterno.ListaTrasladosXMiOrganismo();
                listaTraslados = listaTrasladosResponse;
            }

            if (tipoBusqueda == "pendiente_ingreso")
            {

                (List<DTrasladoInterno> listaTrasladosResponse, string errorResponse) = await nTrasladoInterno.ListaTrasladosPendientesXMiOrganismo();
                //listaTraslados = listaTrasladosResponse;
                listaTraslados = listaTrasladosResponse
                    .Where(x => x.organismo_destino_id == CurrentUser.Instance.organismo.id_organismo)
                    .ToList();
            }

            if (tipoBusqueda == "pendiente_salieron")
            {

                (List<DTrasladoInterno> listaTrasladosResponse, string errorResponse) = await nTrasladoInterno.ListaTrasladosPendientesXMiOrganismo();
                //listaTraslados = listaTrasladosResponse;
                listaTraslados = listaTrasladosResponse
                    .Where(x => x.organismo_origen_id == CurrentUser.Instance.organismo.id_organismo)
                    .ToList();
            }

            if (listaTraslados == null)
            {
                MessageBox.Show("No se encontraron registros", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaTraslados
                .Select(c => new
                {
                    Id = c.id_traslado_interno,
                    Origen = c.organismo_origen.organismo,
                    FechaTraslado = c.fecha_egreso_origen,
                    DetalleTrasaldo = c.detalle_traslado,
                    Destino = c.organismo_destino.organismo,
                    FechaIngreso = c.fecha_ingreso_destino,
                    Estado = c.estado_traslado,
                    ObsTraslado = c.obs_traslado,
                    FechaCarga = c.fecha_carga,
                    HoraCarga = c.hora_carga,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre,

                })
                .ToList();

            dtgvTraslados.DataSource = datosfiltrados;

            if (listaTraslados.Count == 0)
            {
                MessageBox.Show("No se encontraron registros.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                dtgvTraslados.Columns[1].Width = 200;
                dtgvTraslados.Columns[4].Width = 200;
            }

            //limpiar formulario
            txtIdTraslado.Text = string.Empty;
            txtOrganismoOrigenTraslado.Text = string.Empty;
            txtFechaTraslado.Text = string.Empty;
            txtDetalleTraslado.Text = string.Empty;
            txtOrganismoDestinoTraslado.Text = string.Empty;
            txtFechaIngresoTraslado.Text = string.Empty;
            txtEstadoTraslado.Text = string.Empty;
            txtObsTraslado.Text = string.Empty;
            txtFechaCargaTraslado.Text = string.Empty;
            txtHoraCargaTraslado.Text = string.Empty;
            txtUsuarioCargaTraslado.Text = string.Empty;

        }

        private void dtgvTraslados_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvTraslados.SelectedRows.Count > 0)
                {
                    int idTraslado;
                    idTraslado = Convert.ToInt32(dtgvTraslados.CurrentRow.Cells["ID"].Value.ToString());


                    if (idTraslado > 0)
                    {
                        txtIdTraslado.Text = idTraslado.ToString();
                        txtOrganismoOrigenTraslado.Text = dtgvTraslados.CurrentRow.Cells["Origen"].Value.ToString();
                        txtFechaTraslado.Text = Convert.ToDateTime(dtgvTraslados.CurrentRow.Cells["FechaTraslado"].Value).ToString("dd/MM/yyyy");
                        txtDetalleTraslado.Text = dtgvTraslados.CurrentRow.Cells["DetalleTrasaldo"].Value?.ToString();
                        txtOrganismoDestinoTraslado.Text = dtgvTraslados.CurrentRow.Cells["Destino"].Value?.ToString();
                        txtFechaIngresoTraslado.Text = Convert.ToDateTime(dtgvTraslados.CurrentRow.Cells["FechaIngreso"].Value).ToString("dd/MM/yyyy");
                        txtEstadoTraslado.Text = dtgvTraslados.CurrentRow.Cells["Estado"].Value?.ToString();
                        txtObsTraslado.Text = dtgvTraslados.CurrentRow.Cells["ObsTraslado"].Value?.ToString();
                        txtFechaCargaTraslado.Text = Convert.ToDateTime(dtgvTraslados.CurrentRow.Cells["FechaCarga"].Value).ToString("dd/MM/yyyy");
                        txtHoraCargaTraslado.Text = dtgvTraslados.CurrentRow.Cells["HoraCarga"].Value?.ToString();
                        txtUsuarioCargaTraslado.Text = dtgvTraslados.CurrentRow.Cells["Usuario"].Value?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una traslado.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        //FIN METODO PARA OBTENER LA LISTA DE TRASLADOS EN UN DATA GRID ........................

        //METODO HABILITAR CONTROLES ACEPTAR / RECHAZAR TRASLADO
        private void HabilitarControlesAnularTraslado(bool valor)
        {           
            lblEstadoTraslado.Visible = valor;
            txtObsProcesarTraslado.Enabled = valor;
            txtObsProcesarTraslado.Text = string.Empty;

            btnAceptarTraslado.Enabled = !valor;
            btnRechazar.Enabled = !valor;

            btnGuardar.Enabled = valor;
            btnCancelar.Enabled = valor;            
        }

        //FIN METODO HABILITAR CONTROLES ACEPTAR / RECHAZAR TRASLADO
    }
}
