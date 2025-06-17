using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones;
using Newtonsoft.Json;
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
using System.Windows.Forms.VisualStyles;

namespace CapaPresentacion
{
    public partial class FormAdminVisita : Form
    {
        //VARIABLES GLOBALES
        DCiudadano dCiudadano = new DCiudadano();
        private ErrorProvider errorProvider = new ErrorProvider();
        //la accion puede ser prohibir, levantar o quitar
        string accionProhibir = "";
        

        public FormAdminVisita()
        {
            InitializeComponent();
        }

       
        private async void frmAdminVisita_Load(object sender, EventArgs e)
        {
            // Obtener el tamaño de la pantalla actual
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;

            // Ajustar el tamaño del formulario
            if (this.Height > screenHeight)
                this.Height = screenHeight;

            if (this.Width > screenWidth)
                this.Width = screenWidth;

            // Opcional: centrar el formulario si se ajustó
            this.StartPosition = FormStartPosition.CenterScreen;

            int idCiudadano;
            //acceder a la instancia de FormTramites abierta.
            FormVisitas formVisitas = Application.OpenForms["FormVisitas"] as FormVisitas;
            NCiudadano nCiudadano = new NCiudadano();
            //DCiudadano dCiudadano = new DCiudadano();

            idCiudadano = Convert.ToInt32(formVisitas.idCiudadanoGlobal);
            (DCiudadano dCiudadanoX, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(idCiudadano);

            this.dCiudadano = dCiudadanoX;

            if (this.dCiudadano == null)
            {
                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //pictureBox1.Load("https://drive.google.com/uc?id=1Wfa2hj0P5LFAGgYdZNx6TibZmQ7fxJrJ&export=download");
            txtIdCiudadano.Text = this.dCiudadano.id_ciudadano.ToString();
            if (this.dCiudadano.es_visita)
            {
                txtVisita.Text = "ES VISITA";
            }
            else
            {
                txtVisita.Text = "NO ES VISITA";
            }
            txtApellido.Text = this.dCiudadano.apellido;
            txtNombre.Text = this.dCiudadano.nombre;
            txtDni.Text = this.dCiudadano.dni.ToString();
            txtSexo.Text = this.dCiudadano.sexo.sexo;
            txtFechaNacimiento.Text = this.dCiudadano.fecha_nac.ToShortDateString();
            txtTelefono.Text = this.dCiudadano.telefono;
            txtEstadoCivil.Text = this.dCiudadano.estado_civil.estado_civil;
            txtNacionalidad.Text = this.dCiudadano.nacionalidad.nacionalidad;
            txtPais.Text = this.dCiudadano.pais.pais;
            txtProvincia.Text = this.dCiudadano.provincia.provincia;
            txtDepartamento.Text = this.dCiudadano.departamento.departamento;
            txtMunicipio.Text = this.dCiudadano.municipio.municipio;
            txtCiudad.Text = this.dCiudadano.ciudad;
            if (this.dCiudadano.tiene_discapacidad)
            {
                txtDiscapacidad.Text = "TIENE DISCAPACIDAD";
            }
            else
            {
                txtDiscapacidad.Text = "NO TIENE DISCAPACIDAD";
            }
            txtFechaAlta.Text = this.dCiudadano.fecha_alta.ToShortDateString();
            txtOrganismoAlta.Text = this.dCiudadano.organismo_alta.organismo;
            pictureFoto.Load(this.dCiudadano.foto);

            //Carga de combo parenrescos
            NParentesco nParentesco = new NParentesco();
            cmbParentescos.ValueMember = "id_parentesco";
            cmbParentescos.DisplayMember = "parentesco";
            //List<DParentesco> listaParentescos = new List<DParentesco>();
            //listaParentescos = await nParentesco.RetornarListaParentescos();
            //cmbParentescos.DataSource = listaParentescos;
            cmbParentescos.DataSource = await nParentesco.RetornarListaParentescos();
        }

        
        private void btnVerProhibiciones_Click(object sender, EventArgs e)
        {
            this.CargarDataGridProhibiciones();

        }

        
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            Boolean enviar = true;

            //NUEVO
            if ( txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new ProhibicionDatos
                {
                    txtIdCiudadano = Convert.ToInt32(txtIdCiudadano.Text),
                    txtDisposicion = txtDisposicion.Text,
                    txtDetalle = txtDetalle.Text,
                    dtpFechaInicio = dtpFechaInicio.Value,
                    dtpFechaFin = dtpFechaFin.Value,
                };

                var validator = new ProhibicionValidator();
                //var result = validator.Validate(datosFormulario);

                //if (!result.IsValid)
                //{
                //    enviar = false;
                //    MessageBox.Show("Complete correctamente los campos del formulario","Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    foreach (var failure in result.Errors)
                //    {
                        
                //        Control control = Controls.Find(failure.PropertyName, true)[0];
                //        errorProvider.SetError(control, failure.ErrorMessage);
                //    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                //    return;
                //}

                //enviar datos si son correctos
                var data = new
                {
                    ciudadano_id = Convert.ToInt32(txtIdCiudadano.Text),
                    disposicion = txtDisposicion.Text,
                    detalle = txtDetalle.Text,
                    fecha_inicio = dtpFechaInicio.Value,
                    fecha_fin = dtpFechaFin.Value,
                };

                string dataProhibicion = JsonConvert.SerializeObject(data);
                
                (DProhibicionVisita dataRespuesta, string errorResponse) = await nProhibicionVisita.CrearProhibicion(dataProhibicion);
                    
                if (dataRespuesta != null)
                {                        
                    MessageBox.Show("La prohibición se guardo correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.HabilitarControles(false);
                    this.LimpiarControles();

                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                                        
                    //cargar lista de ciudadanos en datagrid
                    this.CargarDataGridProhibiciones();
                }
                else
                {
                    MessageBox.Show( errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            //FIN NUEVO............................................................

            //EDITAR
            if (!string.IsNullOrEmpty(txtIdProhibicion.Text))
            {
                var data = new
                {
                    disposicion = txtDisposicion.Text,
                    detalle = txtDetalle.Text,
                    fecha_inicio = dtpFechaInicio.Value,
                    fecha_fin = dtpFechaFin.Value,
                    detalle_motivo = txtMotivo.Text,
                };

                string dataProhibicion = JsonConvert.SerializeObject(data);
               
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.EditarProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataProhibicion);
                if (respuestaEditar)
                {
                        
                    MessageBox.Show("La edición de la prohibición se realizó correctamente", "Restricción Visitass", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.LimpiarControles();
                    this.HabilitarControles(false);

                    //cargar lista de prhibiciones en datagrid
                    this.CargarDataGridProhibiciones();
                        
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                }
                else
                {                        
                    MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                

            }
            //FIN EDITAR.........................................................
        }        

        private void dtgvProhibiciones_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (btnGuardar.Enabled == true || btnGuardarQP.Enabled == true)
                {
                    MessageBox.Show("No puede se puede seleccionar una prohibición mientras se esta editando o se está agregando una nueva prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtgvProhibiciones.SelectedRows.Count > 0)
                {
                    int idProhibicion;
                    idProhibicion = Convert.ToInt32(dtgvProhibiciones.CurrentRow.Cells["ID"].Value.ToString());
                    
                    if (idProhibicion > 0)
                    {
                        txtIdProhibicion.Text = idProhibicion.ToString();
                        txtDisposicion.Text = dtgvProhibiciones.CurrentRow.Cells["Disposicion"].Value.ToString();
                        txtDetalle.Text = dtgvProhibiciones.CurrentRow.Cells["Detalle"].Value.ToString();
                        dtpFechaInicio.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaInicio"].Value.ToString());
                        dtpFechaFin.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaFin"].Value.ToString());
                        txtOrganismo.Text = dtgvProhibiciones.CurrentRow.Cells["Organismo"].Value.ToString();
                        dtpFechaProhibicion.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaProhibicion"].Value.ToString());
                        chkVigente.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Vigente"].Value.ToString());
                        chkAnulado.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Anulado"].Value.ToString());

                        dtgvHistorialProhibicion.DataSource = "";
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.HabilitarControles(false);
            this.LimpiarControles();
            
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.HabilitarControles(true);
            this.txtMotivo.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.HabilitarControles(true);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            dtgvHistorialProhibicion.DataSource = "";
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibir = "levantar";
            this.HabilitarControlesQP(true);
        }

        private void btnProhibir_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibir = "prohibir";
            this.HabilitarControlesQP(true);
            
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == null || txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.accionProhibir = "anular";
            this.HabilitarControlesQP(true);
        }

        private void btnCancelarQP_Click(object sender, EventArgs e)
        {
            btnQuitar.Enabled = true;
            btnProhibir.Enabled = true;
            btnAnular.Enabled = true;
            this.HabilitarControlesQP(false);
            this.LimpiarControlesQP();
        }

        //GUARDAR LEVANTAR, PROHIBIR Y ANULAR
        private async void btnGuardarQP_Click(object sender, EventArgs e)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            
            var data = new
            {
                detalle_motivo = txtMotivoQP.Text,
                fecha_fin = dtpFechaFinQP.Value,
            };

            string dataEnviar = JsonConvert.SerializeObject(data);

            
            bool respuestaOk = false;
            string mensajeRespuesta = "";

            //determinar cual es la accion a realizar con la prohibicion
            //usar el respectivo metodo
            if (this.accionProhibir == "levantar")
            {
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.LevantarManualProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataEnviar);

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "El levantamiento de la prohibición se realizó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }

            if (this.accionProhibir == "prohibir")
            {
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.ProhibirManualProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataEnviar);

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La prohibición se realizó correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }

            if (this.accionProhibir == "anular")
            {
                (bool respuestaEditar, string errorResponse) = await nProhibicionVisita.AnularProhibicion(Convert.ToInt32(txtIdProhibicion.Text), dataEnviar);

                if (respuestaEditar)
                {
                    respuestaOk = true;
                    mensajeRespuesta = "La prohibición se anuló correctamente";
                }
                else
                {
                    mensajeRespuesta = errorResponse;
                }
            }            

            //verificar respuesta de la peticion
            if (respuestaOk)
            {

                MessageBox.Show(mensajeRespuesta, "Restricción Visitas",MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeRespuesta = "";

                //INICIALIZACION CONTROLES LEVANTAMIENTO                        
                this.HabilitarControlesQP(false);
                this.LimpiarControlesQP();

                //INICIALIZACION DE CONTROLES PROHIBICION
                this.LimpiarControles();
                this.HabilitarControles(false);

                //cargar lista de prhibiciones en datagrid
                this.CargarDataGridProhibiciones();

                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show(mensajeRespuesta, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        //FIN GUARDAR LEVANTAR, PROHIBIR Y ANULAR..................................................................


        //METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES
        async private void CargarDataGridProhibiciones()
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            (List<DProhibicionVisita> listaProhibicionesVisita, string errorResponse) =  await nProhibicionVisita.RetornarListaProhibicionesVisita(this.dCiudadano.id_ciudadano);

            if(listaProhibicionesVisita == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaProhibicionesVisita
                .Select(c => new
                {
                    Id = c.id_prohibicion_visita,
                    Disposicion = c.disposicion,
                    Detalle = c.detalle,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    FechaProhibicion = c.fecha_prohibicion,
                    Organismo = c.organismo.organismo,
                    Vigente = c.vigente,
                    Anulado = c.anulado

                })
                .ToList();

            dtgvProhibiciones.DataSource = datosfiltrados;

            if (listaProhibicionesVisita.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            foreach (DataGridViewRow row in dtgvProhibiciones.Rows)
            {
                if (row.Cells["Vigente"].Value != null && Convert.ToBoolean(row.Cells["Vigente"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange; // Cambiar color de fondo
                    row.DefaultCellStyle.ForeColor = Color.Black;    // Cambiar color del texto
                }

                if (row.Cells["Anulado"].Value != null && Convert.ToBoolean(row.Cells["Anulado"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Black; // Cambiar color de fondo
                    row.DefaultCellStyle.ForeColor = Color.White;    // Cambiar color del texto
                }
            }


        } //FIN METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES...........

        //METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES
        private async void CargarDataGridHistorialProhibiciones(int idProhibicion)
        {
            NBitacoraProhibicionVisita nBitacoraProhibicionVisita = new NBitacoraProhibicionVisita();
            List<DBitacoraProhibicionVisita> listaBitacoraProhibicionesVisita = new List<DBitacoraProhibicionVisita>();
            listaBitacoraProhibicionesVisita = await nBitacoraProhibicionVisita.RetornarListaBitacoraProhibicionesVisita(idProhibicion);

            var datosfiltrados = listaBitacoraProhibicionesVisita
                .Select(c => new
                {
                    Id = c.id_bitacora_prohibicion_visita,
                    Disposicion = c.disposicion,
                    Detalle = c.detalle,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    Vigente = c.vigente,
                    Anulado = c.anulado,
                    Motivo = c.motivo,
                    DetalleMotivo = c.detalle_motivo,
                    FechaCambio = c.fecha_cambio,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvHistorialProhibicion.DataSource = datosfiltrados;            

        } //FIN METODO PARA OBTENER LA LISTA DE PROHIBICIONES Y CARGARLO EN UN DATA GRID DE PROHIBICIONES...........
        
        //HABILITAR CONTROLES
        private void HabilitarControles(bool valor)
        {            
            txtDisposicion.Enabled = valor;
            txtDetalle.ReadOnly = !valor;
            dtpFechaInicio.Enabled = valor;
            dtpFechaFin.Enabled = valor;
            txtMotivo.Enabled = false;
            dtgvHistorialProhibicion.DataSource = "";

            //botnes de quitar prohibicion
            btnQuitar.Enabled = !valor;
            btnProhibir.Enabled = !valor;
            btnAnular.Enabled = !valor;
        }        
        //FIN HABILITAR CONTROLES

        //LIMPIAR CONTROLES
        private void LimpiarControles()
        {
            //limpiar errores
            errorProvider.Clear();

            txtIdProhibicion.Text = string.Empty;
            txtDisposicion.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            dtpFechaInicio.Text = string.Empty;
            dtpFechaFin.Text = string.Empty;
            txtOrganismo.Text = string.Empty;
            dtpFechaProhibicion.Text = string.Empty;
            chkVigente.Checked = false;
            chkAnulado.Checked = false;
            txtMotivo.Text = string.Empty;
        }//FIN LIMPIAR CONTROLES...................................

        
        //HABILITAR CONTROLES QUITAR/PROHIBIR
        private void HabilitarControlesQP(bool valor)
        {
            dtpFechaFinQP.Enabled = valor;
            txtMotivoQP.Enabled = valor;

            btnAnular.Enabled = !valor;
            btnProhibir.Enabled = !valor;
            btnQuitar.Enabled = !valor;

            btnGuardarQP.Enabled = valor;
            btnCancelarQP.Enabled = valor;

            //botones de prohibicion
            btnNuevo.Enabled = !valor;
            btnEditar.Enabled = !valor;
        }
        //FIN HABILITAR QUITAR/PRHIBIR

        //LIMPIAR CONTROLES QUITAR/PROHIBIR
        private void LimpiarControlesQP()
        {
            dtpFechaFinQP.Text = string.Empty;
            txtMotivoQP.Text = string.Empty;
            
        }


        //FIN LIMPIAR QUITAR/PRHIBIR

        //METODO PARA OBTENER LA LISTA DE PARENTESCOS Y CARGARLO EN UN DATA GRID 
        async private void CargarDataGridParentescos()
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();
            List<DVisitaInterno> listaParentescos = new List<DVisitaInterno>();
            listaParentescos = await nVisitaInterno.RetornarListaParentescos(this.dCiudadano.id_ciudadano);

            var datosfiltrados = listaParentescos
                .Select(c => new
                {
                    Id = c.id_visita_interno,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    Parentesco = c.parentesco.parentesco,
                    Prohibido = c.prohibido,
                    Vigente = c.vigente,
                    Anulado = c.anulado,
                    FechaAlta = c.fecha_alta,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvParentescos.DataSource = datosfiltrados;

        } //FIN METODO PARA OBTENER LA LISTA DE PARENTESCOS EN UN DATA GRID ...........


        private void btnVerParentescos_Click(object sender, EventArgs e)
        {
            this.CargarDataGridParentescos();
        }

        private void dtgvParentescos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvParentescos.SelectedRows.Count > 0)
                {
                    int id_visita_interno;
                    id_visita_interno = Convert.ToInt32(dtgvParentescos.CurrentRow.Cells["ID"].Value.ToString());

                    if (id_visita_interno > 0)
                    {
                        txtIdVisitaInterno.Text = id_visita_interno.ToString();
                        txtInternoVinculado.Text = dtgvParentescos.CurrentRow.Cells["Interno"].Value.ToString();
                        txtParentesco.Text = dtgvParentescos.CurrentRow.Cells["Parentesco"].Value.ToString();
                                                
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private async void btnGuardarModificarParentesco_Click(object sender, EventArgs e)
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            //EDITAR
            if (txtIdVisitaInterno.Text != null || txtIdVisitaInterno.Text != "")
            {
                var data = new
                {
                    parentesco_id = cmbParentescos.SelectedValue,
                    detalle_motivo = txtMotivoModificarParentesco.Text
                };

                string dataVisitaInterno = JsonConvert.SerializeObject(data);

                try
                {
                    HttpResponseMessage httpResponse = await nVisitaInterno.CambiarParentesco(Convert.ToInt32(txtIdVisitaInterno.Text), dataVisitaInterno);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();

                        MessageBox.Show("El cambio de parentesco se realizó correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //this.LimpiarControles();
                        //this.HabilitarControles(false);


                        //cargar lista de prhibiciones en datagrid
                        this.CargarDataGridParentescos();

                        cmbParentescos.Enabled = false;
                        txtMotivoModificarParentesco.Text = "";
                        txtMotivoModificarParentesco.Enabled = false;
                        btnModificarParentesco.Enabled = true;
                        btnGuardarModificarParentesco.Enabled = false;
                        btnCancelarModificarParentesco.Enabled = false;
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("No se pudo insertar el registro.");
                        MessageBox.Show($"Error de la API: {errorMessage}", $"Error {httpResponse.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            //FIN EDITAR.........................................................
        }

        private void btnModificarParentesco_Click(object sender, EventArgs e)
        {
            cmbParentescos.Enabled = true;
            txtMotivoModificarParentesco.Enabled = true;
            btnModificarParentesco.Enabled = false;
            btnGuardarModificarParentesco.Enabled = true;
            btnCancelarModificarParentesco.Enabled = true;
        }

        private void btnCancelarModificarParentesco_Click(object sender, EventArgs e)
        {
            cmbParentescos.Enabled = false;
            txtMotivoModificarParentesco.Text = "";
            txtMotivoModificarParentesco.Enabled = false;
            btnModificarParentesco.Enabled = false;
            btnGuardarModificarParentesco.Enabled = true;
            btnCancelarModificarParentesco.Enabled = true;
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (txtIdProhibicion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una prohibición","Restricción Visitas",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                this.CargarDataGridHistorialProhibiciones(Convert.ToInt32(txtIdProhibicion.Text));
            }
        }
        
    }


}
