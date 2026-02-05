namespace CapaPresentacion
{
    partial class FormTraslados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraslados));
            this.btnImprimirExcepciones = new System.Windows.Forms.Button();
            this.dtgvTraslados = new System.Windows.Forms.DataGridView();
            this.groupAceptarRechazar = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblEstadoTraslado = new System.Windows.Forms.Label();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnAceptarTraslado = new System.Windows.Forms.Button();
            this.lblDetalleCumplAnularExcepcion = new System.Windows.Forms.Label();
            this.txtObsProcesarTraslado = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtHoraCargaTraslado = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.txtFechaCargaTraslado = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtOrganismoDestinoTraslado = new System.Windows.Forms.TextBox();
            this.txtFechaIngresoTraslado = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtObsTraslado = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.txtEstadoTraslado = new System.Windows.Forms.TextBox();
            this.txtOrganismoOrigenTraslado = new System.Windows.Forms.TextBox();
            this.txtFechaTraslado = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtUsuarioCargaTraslado = new System.Windows.Forms.TextBox();
            this.txtDetalleTraslado = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtIdTraslado = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnVerTraslados = new System.Windows.Forms.Button();
            this.btnPendientesSalieron = new System.Windows.Forms.Button();
            this.btnPendientesIngreso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTraslados)).BeginInit();
            this.groupAceptarRechazar.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimirExcepciones
            // 
            this.btnImprimirExcepciones.BackColor = System.Drawing.Color.White;
            this.btnImprimirExcepciones.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnImprimirExcepciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirExcepciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirExcepciones.ForeColor = System.Drawing.Color.Indigo;
            this.btnImprimirExcepciones.Location = new System.Drawing.Point(756, 19);
            this.btnImprimirExcepciones.Name = "btnImprimirExcepciones";
            this.btnImprimirExcepciones.Size = new System.Drawing.Size(194, 40);
            this.btnImprimirExcepciones.TabIndex = 117;
            this.btnImprimirExcepciones.Text = "Imprimir";
            this.btnImprimirExcepciones.UseVisualStyleBackColor = false;
            // 
            // dtgvTraslados
            // 
            this.dtgvTraslados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTraslados.Location = new System.Drawing.Point(12, 69);
            this.dtgvTraslados.Name = "dtgvTraslados";
            this.dtgvTraslados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvTraslados.Size = new System.Drawing.Size(938, 239);
            this.dtgvTraslados.TabIndex = 111;
            this.dtgvTraslados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvTraslados_KeyDown);
            // 
            // groupAceptarRechazar
            // 
            this.groupAceptarRechazar.Controls.Add(this.btnGuardar);
            this.groupAceptarRechazar.Controls.Add(this.btnCancelar);
            this.groupAceptarRechazar.Controls.Add(this.lblEstadoTraslado);
            this.groupAceptarRechazar.Controls.Add(this.btnRechazar);
            this.groupAceptarRechazar.Controls.Add(this.btnAceptarTraslado);
            this.groupAceptarRechazar.Controls.Add(this.lblDetalleCumplAnularExcepcion);
            this.groupAceptarRechazar.Controls.Add(this.txtObsProcesarTraslado);
            this.groupAceptarRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAceptarRechazar.Location = new System.Drawing.Point(677, 314);
            this.groupAceptarRechazar.Name = "groupAceptarRechazar";
            this.groupAceptarRechazar.Size = new System.Drawing.Size(273, 351);
            this.groupAceptarRechazar.TabIndex = 113;
            this.groupAceptarRechazar.TabStop = false;
            this.groupAceptarRechazar.Text = "Aceptar / Rechazar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Location = new System.Drawing.Point(9, 305);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 40);
            this.btnGuardar.TabIndex = 240;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCancelar.Location = new System.Drawing.Point(123, 305);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 40);
            this.btnCancelar.TabIndex = 241;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblEstadoTraslado
            // 
            this.lblEstadoTraslado.AutoSize = true;
            this.lblEstadoTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoTraslado.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblEstadoTraslado.Location = new System.Drawing.Point(6, 73);
            this.lblEstadoTraslado.Name = "lblEstadoTraslado";
            this.lblEstadoTraslado.Size = new System.Drawing.Size(65, 15);
            this.lblEstadoTraslado.TabIndex = 239;
            this.lblEstadoTraslado.Text = "ESTADO:";
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackColor = System.Drawing.Color.White;
            this.btnRechazar.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnRechazar.Location = new System.Drawing.Point(142, 19);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(125, 40);
            this.btnRechazar.TabIndex = 238;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnAceptarTraslado
            // 
            this.btnAceptarTraslado.BackColor = System.Drawing.Color.White;
            this.btnAceptarTraslado.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnAceptarTraslado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptarTraslado.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnAceptarTraslado.Location = new System.Drawing.Point(8, 20);
            this.btnAceptarTraslado.Name = "btnAceptarTraslado";
            this.btnAceptarTraslado.Size = new System.Drawing.Size(125, 40);
            this.btnAceptarTraslado.TabIndex = 237;
            this.btnAceptarTraslado.Text = "Aceptar";
            this.btnAceptarTraslado.UseVisualStyleBackColor = false;
            this.btnAceptarTraslado.Click += new System.EventHandler(this.btnAceptarTraslado_Click);
            // 
            // lblDetalleCumplAnularExcepcion
            // 
            this.lblDetalleCumplAnularExcepcion.AutoSize = true;
            this.lblDetalleCumplAnularExcepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleCumplAnularExcepcion.Location = new System.Drawing.Point(5, 97);
            this.lblDetalleCumplAnularExcepcion.Name = "lblDetalleCumplAnularExcepcion";
            this.lblDetalleCumplAnularExcepcion.Size = new System.Drawing.Size(101, 15);
            this.lblDetalleCumplAnularExcepcion.TabIndex = 78;
            this.lblDetalleCumplAnularExcepcion.Text = "OBS TRASLADO:";
            // 
            // txtObsProcesarTraslado
            // 
            this.txtObsProcesarTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObsProcesarTraslado.Enabled = false;
            this.txtObsProcesarTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObsProcesarTraslado.Location = new System.Drawing.Point(8, 117);
            this.txtObsProcesarTraslado.Multiline = true;
            this.txtObsProcesarTraslado.Name = "txtObsProcesarTraslado";
            this.txtObsProcesarTraslado.Size = new System.Drawing.Size(249, 176);
            this.txtObsProcesarTraslado.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtHoraCargaTraslado);
            this.groupBox5.Controls.Add(this.label74);
            this.groupBox5.Controls.Add(this.txtFechaCargaTraslado);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.txtOrganismoDestinoTraslado);
            this.groupBox5.Controls.Add(this.txtFechaIngresoTraslado);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Controls.Add(this.txtObsTraslado);
            this.groupBox5.Controls.Add(this.label73);
            this.groupBox5.Controls.Add(this.txtEstadoTraslado);
            this.groupBox5.Controls.Add(this.txtOrganismoOrigenTraslado);
            this.groupBox5.Controls.Add(this.txtFechaTraslado);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.txtUsuarioCargaTraslado);
            this.groupBox5.Controls.Add(this.txtDetalleTraslado);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Controls.Add(this.txtIdTraslado);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 315);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(659, 350);
            this.groupBox5.TabIndex = 118;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Traslado";
            // 
            // txtHoraCargaTraslado
            // 
            this.txtHoraCargaTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoraCargaTraslado.Location = new System.Drawing.Point(138, 325);
            this.txtHoraCargaTraslado.Name = "txtHoraCargaTraslado";
            this.txtHoraCargaTraslado.ReadOnly = true;
            this.txtHoraCargaTraslado.Size = new System.Drawing.Size(112, 21);
            this.txtHoraCargaTraslado.TabIndex = 97;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(135, 305);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(87, 15);
            this.label74.TabIndex = 98;
            this.label74.Text = "HORA CARGA:";
            // 
            // txtFechaCargaTraslado
            // 
            this.txtFechaCargaTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCargaTraslado.Location = new System.Drawing.Point(15, 325);
            this.txtFechaCargaTraslado.Name = "txtFechaCargaTraslado";
            this.txtFechaCargaTraslado.ReadOnly = true;
            this.txtFechaCargaTraslado.Size = new System.Drawing.Size(112, 21);
            this.txtFechaCargaTraslado.TabIndex = 95;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 305);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(92, 15);
            this.label26.TabIndex = 96;
            this.label26.Text = "FECHA CARGA:";
            // 
            // txtOrganismoDestinoTraslado
            // 
            this.txtOrganismoDestinoTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismoDestinoTraslado.Location = new System.Drawing.Point(10, 177);
            this.txtOrganismoDestinoTraslado.Name = "txtOrganismoDestinoTraslado";
            this.txtOrganismoDestinoTraslado.ReadOnly = true;
            this.txtOrganismoDestinoTraslado.Size = new System.Drawing.Size(349, 21);
            this.txtOrganismoDestinoTraslado.TabIndex = 94;
            // 
            // txtFechaIngresoTraslado
            // 
            this.txtFechaIngresoTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaIngresoTraslado.Location = new System.Drawing.Point(370, 177);
            this.txtFechaIngresoTraslado.Name = "txtFechaIngresoTraslado";
            this.txtFechaIngresoTraslado.ReadOnly = true;
            this.txtFechaIngresoTraslado.Size = new System.Drawing.Size(112, 21);
            this.txtFechaIngresoTraslado.TabIndex = 91;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(367, 158);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(107, 15);
            this.label40.TabIndex = 92;
            this.label40.Text = "FECHA INGRESO:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(6, 158);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(140, 15);
            this.label41.TabIndex = 93;
            this.label41.Text = "ORGANISMO DESTINO:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(6, 203);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(101, 15);
            this.label44.TabIndex = 90;
            this.label44.Text = "OBS TRASLADO:";
            // 
            // txtObsTraslado
            // 
            this.txtObsTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObsTraslado.Enabled = false;
            this.txtObsTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObsTraslado.Location = new System.Drawing.Point(9, 222);
            this.txtObsTraslado.Multiline = true;
            this.txtObsTraslado.Name = "txtObsTraslado";
            this.txtObsTraslado.ReadOnly = true;
            this.txtObsTraslado.Size = new System.Drawing.Size(640, 70);
            this.txtObsTraslado.TabIndex = 89;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(490, 159);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(58, 15);
            this.label73.TabIndex = 88;
            this.label73.Text = "ESTADO:";
            // 
            // txtEstadoTraslado
            // 
            this.txtEstadoTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoTraslado.Location = new System.Drawing.Point(493, 177);
            this.txtEstadoTraslado.Name = "txtEstadoTraslado";
            this.txtEstadoTraslado.ReadOnly = true;
            this.txtEstadoTraslado.Size = new System.Drawing.Size(90, 21);
            this.txtEstadoTraslado.TabIndex = 87;
            // 
            // txtOrganismoOrigenTraslado
            // 
            this.txtOrganismoOrigenTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganismoOrigenTraslado.Location = new System.Drawing.Point(111, 36);
            this.txtOrganismoOrigenTraslado.Name = "txtOrganismoOrigenTraslado";
            this.txtOrganismoOrigenTraslado.ReadOnly = true;
            this.txtOrganismoOrigenTraslado.Size = new System.Drawing.Size(349, 21);
            this.txtOrganismoOrigenTraslado.TabIndex = 86;
            // 
            // txtFechaTraslado
            // 
            this.txtFechaTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaTraslado.Location = new System.Drawing.Point(471, 36);
            this.txtFechaTraslado.Name = "txtFechaTraslado";
            this.txtFechaTraslado.ReadOnly = true;
            this.txtFechaTraslado.Size = new System.Drawing.Size(112, 21);
            this.txtFechaTraslado.TabIndex = 83;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(468, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(115, 15);
            this.label31.TabIndex = 84;
            this.label31.Text = "FECHA TRASLADO:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(107, 17);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(134, 15);
            this.label32.TabIndex = 85;
            this.label32.Text = "ORGANISMO ORIGEN:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(6, 62);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(129, 15);
            this.label42.TabIndex = 82;
            this.label42.Text = "DETALLE TRASLADO:";
            // 
            // txtUsuarioCargaTraslado
            // 
            this.txtUsuarioCargaTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioCargaTraslado.Location = new System.Drawing.Point(260, 324);
            this.txtUsuarioCargaTraslado.Name = "txtUsuarioCargaTraslado";
            this.txtUsuarioCargaTraslado.ReadOnly = true;
            this.txtUsuarioCargaTraslado.Size = new System.Drawing.Size(193, 21);
            this.txtUsuarioCargaTraslado.TabIndex = 80;
            // 
            // txtDetalleTraslado
            // 
            this.txtDetalleTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleTraslado.Enabled = false;
            this.txtDetalleTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleTraslado.Location = new System.Drawing.Point(9, 81);
            this.txtDetalleTraslado.Multiline = true;
            this.txtDetalleTraslado.Name = "txtDetalleTraslado";
            this.txtDetalleTraslado.ReadOnly = true;
            this.txtDetalleTraslado.Size = new System.Drawing.Size(640, 70);
            this.txtDetalleTraslado.TabIndex = 81;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(6, 17);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(22, 15);
            this.label39.TabIndex = 78;
            this.label39.Text = "ID:";
            // 
            // txtIdTraslado
            // 
            this.txtIdTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTraslado.Location = new System.Drawing.Point(9, 37);
            this.txtIdTraslado.Name = "txtIdTraslado";
            this.txtIdTraslado.ReadOnly = true;
            this.txtIdTraslado.Size = new System.Drawing.Size(90, 21);
            this.txtIdTraslado.TabIndex = 77;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(256, 305);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 15);
            this.label25.TabIndex = 72;
            this.label25.Text = "USUARIO CARGA:";
            // 
            // btnVerTraslados
            // 
            this.btnVerTraslados.BackColor = System.Drawing.Color.White;
            this.btnVerTraslados.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnVerTraslados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTraslados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTraslados.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnVerTraslados.Location = new System.Drawing.Point(12, 19);
            this.btnVerTraslados.Name = "btnVerTraslados";
            this.btnVerTraslados.Size = new System.Drawing.Size(125, 40);
            this.btnVerTraslados.TabIndex = 119;
            this.btnVerTraslados.Text = "Ver traslados";
            this.btnVerTraslados.UseVisualStyleBackColor = false;
            this.btnVerTraslados.Click += new System.EventHandler(this.btnVerTraslados_Click);
            // 
            // btnPendientesSalieron
            // 
            this.btnPendientesSalieron.BackColor = System.Drawing.Color.White;
            this.btnPendientesSalieron.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPendientesSalieron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendientesSalieron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendientesSalieron.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPendientesSalieron.Location = new System.Drawing.Point(150, 19);
            this.btnPendientesSalieron.Name = "btnPendientesSalieron";
            this.btnPendientesSalieron.Size = new System.Drawing.Size(171, 40);
            this.btnPendientesSalieron.TabIndex = 120;
            this.btnPendientesSalieron.Text = "Pendientes salieron";
            this.btnPendientesSalieron.UseVisualStyleBackColor = false;
            this.btnPendientesSalieron.Click += new System.EventHandler(this.btnPendientesSalieron_Click);
            // 
            // btnPendientesIngreso
            // 
            this.btnPendientesIngreso.BackColor = System.Drawing.Color.White;
            this.btnPendientesIngreso.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPendientesIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendientesIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendientesIngreso.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPendientesIngreso.Location = new System.Drawing.Point(340, 19);
            this.btnPendientesIngreso.Name = "btnPendientesIngreso";
            this.btnPendientesIngreso.Size = new System.Drawing.Size(171, 40);
            this.btnPendientesIngreso.TabIndex = 121;
            this.btnPendientesIngreso.Text = "Pendientes Ingreso";
            this.btnPendientesIngreso.UseVisualStyleBackColor = false;
            this.btnPendientesIngreso.Click += new System.EventHandler(this.btnPendientesIngreso_Click);
            // 
            // FormTraslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 671);
            this.Controls.Add(this.btnPendientesIngreso);
            this.Controls.Add(this.btnPendientesSalieron);
            this.Controls.Add(this.btnVerTraslados);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnImprimirExcepciones);
            this.Controls.Add(this.dtgvTraslados);
            this.Controls.Add(this.groupAceptarRechazar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTraslados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traslados";
            this.Load += new System.EventHandler(this.FormTraslados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTraslados)).EndInit();
            this.groupAceptarRechazar.ResumeLayout(false);
            this.groupAceptarRechazar.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimirExcepciones;
        private System.Windows.Forms.DataGridView dtgvTraslados;
        private System.Windows.Forms.GroupBox groupAceptarRechazar;
        private System.Windows.Forms.Label lblDetalleCumplAnularExcepcion;
        private System.Windows.Forms.TextBox txtObsProcesarTraslado;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtHoraCargaTraslado;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox txtFechaCargaTraslado;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtOrganismoDestinoTraslado;
        private System.Windows.Forms.TextBox txtFechaIngresoTraslado;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtObsTraslado;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox txtEstadoTraslado;
        private System.Windows.Forms.TextBox txtOrganismoOrigenTraslado;
        private System.Windows.Forms.TextBox txtFechaTraslado;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtUsuarioCargaTraslado;
        private System.Windows.Forms.TextBox txtDetalleTraslado;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtIdTraslado;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnVerTraslados;
        private System.Windows.Forms.Button btnPendientesSalieron;
        private System.Windows.Forms.Button btnPendientesIngreso;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnAceptarTraslado;
        private System.Windows.Forms.Label lblEstadoTraslado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}