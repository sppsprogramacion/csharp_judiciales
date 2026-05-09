using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.CausaAdministrar.Datos;
using CapaPresentacion.Validaciones.CausaAdministrar.Validacon;
using CapaPresentacion.Validaciones.CausaNueva.Datos;
using CapaPresentacion.Validaciones.CausaNueva.Validacion;
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
        public bool isModificadoCausaGlobal { get; private set; }

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
            gboxDatosGenerales.Enabled = true;
            gboxDadosCondena.Enabled = true;

            if (this.dCausaGlobal == null)
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.CargarControlesCausa();
        }

        private void dtpFechaCondena_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaCondena.Format = DateTimePickerFormat.Short;
        }


        private void dtpFechaCumple_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaCumple.Format = DateTimePickerFormat.Short;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.CargarTablasCausa();

            this.HabilitarControlesEditarDatosGenerales(true);
            txtCausa.Focus();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosformulario = new CausaAdministrarDatos
            {
                txtCausa = txtCausa.Text,
                cmbPrisionReclusion = cmbPrisionReclusion.SelectedValue?.ToString() ?? string.Empty,
                txtExpediente = txtExpediente.Text,
                cmbTipoDelito = cmbTipoDelito.SelectedValue?.ToString() ?? string.Empty,
                cmbEstadoProcesal = cmbEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
                cmbJurisdiccion = cmbJurisdiccion.SelectedValue?.ToString() ?? string.Empty,
                cmbJuzgado = cmbJuzgado.SelectedValue?.ToString() ?? string.Empty,
                cmbOtroJuzgado = cmbOtroJuzgado.SelectedValue?.ToString() ?? string.Empty,
                cmbReincidencia = cmbReincidencia.SelectedValue?.ToString() ?? string.Empty,
                cmbTipoDefensor = cmbTipoDefensor.SelectedValue?.ToString() ?? string.Empty,
                txtAbogado = txtAbogado.Text
            };

            var validator = new CausaEditarDatosGeneralesValidation();
            var result = validator.Validate(datosformulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {
                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validar formulario

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

            this.gboxDatosGenerales.Enabled = true;

            if (respuestaEditar)
            {
                MessageBox.Show("La edición se realizó correctamente", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isModificadoCausaGlobal = true;
                //this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                this.HabilitarControlesEditarDatosGenerales(false);
                
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            this.CargarControlesCausa();
            this.HabilitarControlesEditarDatosGenerales(false);
        }

        
        
        private void btnEditarCondena_Click(object sender, EventArgs e)
        {
            this.CargarTablasCausa();
            this.HabilitarControlesCondena(true);

        }
        private async void btnGuardarCondena_Click(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosformulario = new CausaAdministrarDatos
            {
                cmbTribunalCondena = cmbTribunalCondena.SelectedValue?.ToString() ?? string.Empty,
                txtPenaAnios = txtPenaAnios.Text,
                txtPenaMeses = txtPenaMeses.Text,
                txtPenaDias = txtPenaDias.Text,
            };

            var validator = new CausaEstablecerCondenaValidation();
            var result = validator.Validate(datosformulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {
                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validar formulario

            this.gboxDadosCondena.Enabled = false;
            var data = new
            {
                fecha_ultima_detencion = dtpFechaUltimaDetCondena.Value,
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
                isModificadoCausaGlobal = true;
                //this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                this.BuscarCausa();

                this.HabilitarControlesCondena(false);
                this.gboxDadosCondena.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gboxDadosCondena.Enabled = true;
            }
        }

        private void btnCancelarCondena_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            this.CargarControlesCausa();
            this.HabilitarControlesCondena(false);
        }

        private void btnQuitarDatosCondena_Click(object sender, EventArgs e)
        {
            this.CargarTablasCausa();
            this.HabilitarControlesQuitarCondena(true);
        }

        private async void btnGuardarQuitarCondena_Click(object sender, EventArgs e)
        {
            NCausa nCausa = new NCausa();

            //limpiar errores de provider
            errorProvider.Clear();

            this.gboxDadosCondena.Enabled = false;
            var data = new
            {
                estado_procesal_id = cmbQuitarEstadoProcesal.SelectedValue?.ToString() ?? string.Empty,
            };

            string dataCondenaEnviar = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nCausa.QuitarCondena(Convert.ToInt32(txtIdCausa.Text), dataCondenaEnviar);

            if (respuestaEditar)
            {
                MessageBox.Show("Se quito correctamente los datos de condena", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //actualizar el internoClobal
                isModificadoCausaGlobal = true;
                //this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
                this.BuscarCausa();
                this.HabilitarControlesCondena(false);
                this.gboxDadosCondena.Enabled = true;
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.gboxDadosCondena.Enabled = true;
            }
        }

        private void btnCancelarQuitarCondena_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            this.HabilitarControlesQuitarCondena(false);
            this.CargarControlesCausa();
        }


        //BUSCAR CAUSA
        private async void BuscarCausa()
        {
            NCausa nCausa = new NCausa();

            gboxDatosGenerales.Enabled = false;
            gboxDadosCondena.Enabled = false;

            (DCausa dCausax, string errorResponse) = await nCausa.BuscarxIdCausa(this.idCausaGlobal);
            this.dCausaGlobal = dCausax;
            gboxDatosGenerales.Enabled = true;
            gboxDadosCondena.Enabled = true;

            if (this.dCausaGlobal == null)
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.CargarControlesCausa();
            

        }
        //FIN BUSCAR CAUSA....................................................................


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
            cmbEstadoProcesal.DataSource = this.tablasCausa.estado_procesal.ToList();

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

            //ESTADO PROCESAL PARA QUITAR CONDENA
            cmbQuitarEstadoProcesal.ValueMember = "id_estado_procesal";
            cmbQuitarEstadoProcesal.DisplayMember = "estado_procesal";
            cmbQuitarEstadoProcesal.DataSource = this.tablasCausa.estado_procesal.ToList();

            this.CargarControlesCausa();
            //fin Carga de combos causa
            
        }
        //FIN CARGAR TABLAS CAUSA.................................................


        //CARGAR DATOS DE CAUSA 
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

            if (this.dCausaGlobal.fecha_ultima_detencion == null)
            {
                if (btnEditarCondena.Enabled)
                {
                    dtpFechaUltimaDetCondena.Format = DateTimePickerFormat.Custom;
                    dtpFechaUltimaDetCondena.CustomFormat = " ";
                }
                else
                {
                    dtpFechaUltimaDetCondena.Format = DateTimePickerFormat.Short;
                }
            }
            else
            {
                dtpFechaUltimaDetCondena.Format = DateTimePickerFormat.Short;
                dtpFechaUltimaDetCondena.Text = this.dCausaGlobal.fecha_ultima_detencion.ToShortDateString();
            }

            if (this.dCausaGlobal.fecha_condena == null)
            {
                if (btnEditarCondena.Enabled)
                {
                    dtpFechaCondena.Format = DateTimePickerFormat.Custom;
                    dtpFechaCondena.CustomFormat = " ";
                }
                else
                {
                    dtpFechaCondena.Format = DateTimePickerFormat.Short;
                }                
            }
            else
            {
                dtpFechaCondena.Format = DateTimePickerFormat.Short;
                dtpFechaCondena.Text = this.dCausaGlobal.fecha_condena?.ToShortDateString();
            }

            if (this.dCausaGlobal.fecha_cumple_pena == null)
            {
                if (btnEditarCondena.Enabled)
                {
                    dtpFechaCumple.Format = DateTimePickerFormat.Custom;
                    dtpFechaCumple.CustomFormat = " ";
                }
                else
                {
                    dtpFechaCumple.Format = DateTimePickerFormat.Short;
                }
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

        }//FIN CARGAR DATOS DE CAUSA ......................................

        //HABILITAR CONTROLES INGRESO
        private void HabilitarControlesEditarDatosGenerales(bool valor)
        {
            txtCausa.Enabled = valor;
            cmbPrisionReclusion.Enabled = valor;
            txtExpediente.Enabled = valor;
            cmbTipoDelito.Enabled = valor;
            cmbEstadoProcesal.Enabled = valor;
            cmbJurisdiccion.Enabled = valor;
            cmbJuzgado.Enabled = valor;
            cmbOtroJuzgado.Enabled = valor;
            cmbReincidencia.Enabled = valor;
            dtpFechaUltimaDetencion.Enabled = valor;
            cmbTipoDefensor.Enabled = valor;
            txtAbogado.Enabled = valor;

            btnEditar.Enabled = !valor;
            btnGuardar.Enabled = valor;
            btnCancelar.Enabled = valor;
            gboxDadosCondena.Enabled = !valor;
        }//FIN HABILITAR CONTROLES INGRESO...........................................

        //HABILITAR CONTROLES CONDENA
        private void HabilitarControlesCondena(bool valor)
        {
            dtpFechaUltimaDetCondena.Enabled = valor;
            dtpFechaCondena.Enabled = valor;
            dtpFechaCumple.Enabled = valor;
            cmbTribunalCondena.Enabled = valor;
            txtPenaAnios.Enabled = valor;
            txtPenaMeses.Enabled = valor;
            txtPenaDias.Enabled = valor;

            btnQuitarDatosCondena.Enabled = !valor;
            btnEditarCondena.Enabled = !valor;
            btnGuardarCondena.Enabled = valor;
            btnCancelarCondena.Enabled = valor;
            gboxDatosGenerales.Enabled = !valor;
        }//FIN HABILITAR CONTROLES CONDENA...........................................

        //HABILITAR CONTROLES CONDENA
        private void HabilitarControlesQuitarCondena(bool valor)
        {
            
            cmbQuitarEstadoProcesal.Enabled = valor;

            btnQuitarDatosCondena.Enabled = !valor;
            btnGuardarQuitarCondena.Enabled = valor;
            btnCancelarQuitarCondena.Enabled = valor;
            gboxDatosGenerales.Enabled = !valor;
        }//FIN HABILITAR CONTROLES CONDENA...........................................

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
            this.Close();
        }
    }
}
