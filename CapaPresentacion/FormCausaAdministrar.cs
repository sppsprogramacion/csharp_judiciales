using CapaDatos;
using CapaNegocio;
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
    public partial class FormCausaAdministrar : Form
    {
        int idCausaGlobal = 0;
        DCausa dCausaGlobal = new DCausa();
        DTablasCausa tablasCausa = null;

        private ErrorProvider errorProvider = new ErrorProvider();


        public FormCausaAdministrar(int idCausa)
        {
            this.idCausaGlobal = idCausa;
            InitializeComponent();
        }

        private async void FormCausaAdministrar_Load(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //BUSCAR CAUSA CON EL ID DEL FORMULARIO DE BUSQUEDA (formVisitas)
            gboxDatosGenerales.Enabled = false;
            gboxDadosCondena.Enabled = false;

            (DCausa dCausax, string errorResponse) = await nCausa.BuscarxIdCausa(this.idCausaGlobal);
            this.dCausaGlobal = dCausax;

            if (this.dCausaGlobal == null)
            {
                gboxDatosGenerales.Enabled = true;
                gboxDadosCondena.Enabled = true;

                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.CargarControlesCausa();

            gboxDatosGenerales.Enabled = true;
            gboxDadosCondena.Enabled = true;
        }

        private void dtpFechaCondena_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaCondena.Format = DateTimePickerFormat.Short;
        }


        private void dtpFechaCumple_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaCumple.Format = DateTimePickerFormat.Short;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //limpiar errores de provider
            errorProvider.Clear();

            this.gboxDatosGenerales.Enabled = false;
            var data = new
            {
                causa = txtCausa.Text,
                prision_reclusion_id = cmbPrisionReclusion.SelectedValue.ToString(),
                expediente = txtExpediente.Text,
                tipo_delito_id = Convert.ToInt32(cmbTipoDelito.SelectedValue.ToString()),
                estado_procesal_id = cmbEstadoProcesal.SelectedValue.ToString(),
                jurisdiccion_id = cmbJurisdiccion.SelectedValue.ToString(),
                juzgado_id = cmbJuzgado.SelectedValue.ToString(),
                otro_juzgado_id = cmbOtroJuzgado.SelectedValue.ToString(),
                reincidencia_id = cmbReincidencia.SelectedValue.ToString(),
                fecha_ultima_detencion = dtpFechaUltimaDetencion.Value,
                tipo_defensor_id = Convert.ToInt32(cmbTipoDefensor.SelectedValue.ToString()),
                abogado = txtAbogado.Text
            };

            string dataCausaEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nCausa.EditarCausa(Convert.ToInt32(txtIdCausa.Text), dataCausaEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                //this.BuscarIngreso();

                //this.HabilitarControlesIngreso(false);
                this.gboxDatosGenerales.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gboxDatosGenerales.Enabled = true;
            }

        }

        private async void btnGuardarCondena_Click(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //limpiar errores de provider
            errorProvider.Clear();

            this.gboxDadosCondena.Enabled = false;
            var data = new
            {
                fecha_condena = dtpFechaCondena.Value,
                tribunal_condena_id = cmbTribunalCondena.SelectedValue.ToString(),
                pena_anios = Convert.ToInt32(txtPenaAnios.Text),
                pena_meses = Convert.ToInt32(txtPenaMeses.Text),
                pena_dias = Convert.ToInt32(txtPenaDias.Text),
                fecha_cumple_pena = dtpFechaCondena.Value
            };

            string dataCondenaEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nCausa.EstablecerCondena(Convert.ToInt32(txtIdCausa.Text), dataCondenaEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                //this.BuscarIngreso();

                //this.HabilitarControlesIngreso(false);
                this.gboxDadosCondena.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gboxDadosCondena.Enabled = true;
            }
        }

        //CARGAR TABLAS CAUSA
        private async void CargarTablasCausa()
        {
            if (this.tablasCausa == null)
            {

                gboxDatosGenerales.Enabled = false;
                gboxDadosCondena.Enabled = false;

                //Carga de combos sobre listas para ingreso
                NListasGenerales nListasGenerales = new NListasGenerales();
                (DTablasCausa tablasCausaResponse, string errorResponse) = await nListasGenerales.ListasTablasCausa();
                this.tablasCausa = tablasCausaResponse;

                gboxDatosGenerales.Enabled = true;
                gboxDadosCondena.Enabled = true;

                if (this.tablasCausa == null)
                {
                    MessageBox.Show("Advertencia al cargar las listas: " + errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //CargarCombos Causa
            
            //PRISION RECLUSION
            cmbPrisionReclusion.ValueMember = "id_prision_reclusion";
            cmbPrisionReclusion.DisplayMember = "prision_reclusion";
            cmbPrisionReclusion.DataSource = this.tablasCausa.prision_reclusion;

            //TIPOS DELITO
            cmbTipoDelito.ValueMember = "id_tipo_delito";
            cmbTipoDelito.DisplayMember = "tipo_delito";
            cmbTipoDelito.DataSource = this.tablasCausa.tipos_delito.ToList();

            //ESTADO PROCESAL
            cmbEstadoProcesal.ValueMember = "id_estado_procesal";
            cmbEstadoProcesal.DisplayMember = "estado_procesal";
            cmbEstadoProcesal.DataSource = this.tablasCausa.estado_procesal;

            //JURISDICCION
            cmbJurisdiccion.ValueMember = "id_jurisdiccion";
            cmbJurisdiccion.DisplayMember = "jurisdiccion";
            cmbJurisdiccion.DataSource = this.tablasCausa.jurisdiccion.ToList();

            //JUZGADOS
            cmbJuzgado.ValueMember = "id_juzgado";
            cmbJuzgado.DisplayMember = "juzgado";
            cmbJuzgado.DataSource = this.tablasCausa.juzgados.ToList();

            //OTROS JUZGADOS
            cmbOtroJuzgado.ValueMember = "id_juzgado";
            cmbOtroJuzgado.DisplayMember = "juzgado";
            cmbOtroJuzgado.DataSource = this.tablasCausa.juzgados.ToList();

            //REINCIDENCIA
            cmbReincidencia.ValueMember = "id_reincidencia";
            cmbReincidencia.DisplayMember = "reincidencia";
            cmbReincidencia.DataSource = this.tablasCausa.reincidencia;

            //Tipos defensor
            cmbTipoDefensor.ValueMember = "id_tipo_defensor";
            cmbTipoDefensor.DisplayMember = "tipo_defensor";
            cmbTipoDefensor.DataSource = this.tablasCausa.tipos_defensor;

            //Tribunal condena
            cmbTribunalCondena.ValueMember = "id_juzgado";
            cmbTribunalCondena.DisplayMember = "juzgado";
            cmbTribunalCondena.DataSource = this.tablasCausa.juzgados.ToList();

            this.CargarControlesCausa();
            
            //fin Carga de combos causa
            
        }
        //FIN CARGAR TABLAS CAUSA.................................................


        //CARGAR DATOS DE INGRESO EN PESTAÑA DATOS DE INGRESO
        private void CargarControlesCausa()
        {
            txtIdCausa.Text = this.idCausaGlobal.ToString();
            txtUsuarioCarga.Text = this.dCausaGlobal.usuario_carga.apellido + " " + this.dCausaGlobal.usuario_carga.nombre;
            txtOrganismoCarga.Text = this.dCausaGlobal.organismo_carga.organismo;
            txtFechaCarga.Text = this.dCausaGlobal.fecha_carga.ToString();

            //datos generales
            txtCausa.Text = this.dCausaGlobal.causa;
            cmbPrisionReclusion.Text = this.dCausaGlobal.prision_reclusion.prision_reclusion;
            txtExpediente.Text = this.dCausaGlobal.expediente.ToString();
            cmbTipoDelito.Text = this.dCausaGlobal.tipo_delito.tipo_delito;
            cmbEstadoProcesal.Text = this.dCausaGlobal.estado_procesal.estado_procesal;
            cmbJurisdiccion.Text = this.dCausaGlobal.jurisdiccion.jurisdiccion;
            cmbJuzgado.Text = this.dCausaGlobal.juzgado.juzgado;
            cmbOtroJuzgado.Text = this.dCausaGlobal.juzgado.juzgado;
            cmbReincidencia.Text = this.dCausaGlobal.reincidencia.reincidencia;
            cmbTipoDefensor.Text = this.dCausaGlobal.tipo_defensor.tipo_defensor;
            dtpFechaUltimaDetencion.Text = this.dCausaGlobal.fecha_ultima_detencion.ToShortDateString();
            txtAbogado.Text = this.dCausaGlobal.abogado;

            //datos de condena
            chckTieneComputo.Checked = this.dCausaGlobal.tiene_computo;

            if (this.dCausaGlobal.fecha_condena == null)
            {
                dtpFechaCondena.Format = DateTimePickerFormat.Custom;
                dtpFechaCondena.CustomFormat = " ";
            }
            else
            {
                dtpFechaCondena.Format = DateTimePickerFormat.Short;
                dtpFechaCondena.Text = this.dCausaGlobal.fecha_condena?.ToShortDateString();
            }

            if (this.dCausaGlobal.fecha_cumple_pena == null)
            {
                dtpFechaCumple.Format = DateTimePickerFormat.Custom;
                dtpFechaCumple.CustomFormat = " ";
            }
            else
            {
                dtpFechaCumple.Format = DateTimePickerFormat.Short;
                dtpFechaCumple.Text = this.dCausaGlobal.fecha_cumple_pena?.ToShortDateString();
            }
                        
            cmbTribunalCondena.Text = this.dCausaGlobal.tribunal_condena.juzgado.ToString();
            txtPenaAnios.Text = this.dCausaGlobal.pena_anios.ToString();
            txtPenaMeses.Text = this.dCausaGlobal.pena_meses.ToString();
            txtPenaDias.Text = this.dCausaGlobal.pena_dias.ToString();

        }//FIN CARGAR DATOS DE INGRESO EN PESTAÑA DATOS DE INGRESO......................................

        private void btnEditarIngreso_Click(object sender, EventArgs e)
        {
            this.CargarTablasCausa();
        }

        private void btnEditarCondena_Click(object sender, EventArgs e)
        {
            this.CargarTablasCausa();
        }

        private async void btnQuitarDatosCondena_Click(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //limpiar errores de provider
            errorProvider.Clear();

            this.gboxDadosCondena.Enabled = false;
            var data = new
            {
                tiene_computo = chckTieneComputo.Checked
            };

            string dataCondenaEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nCausa.QuitarCondena(Convert.ToInt32(txtIdCausa.Text), dataCondenaEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("Se quito correctamente los datos de condena", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                //this.BuscarIngreso();

                //this.HabilitarControlesIngreso(false);
                this.gboxDadosCondena.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gboxDadosCondena.Enabled = true;
            }
        }
    }
}
