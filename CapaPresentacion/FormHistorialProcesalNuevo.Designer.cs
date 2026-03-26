namespace CapaPresentacion
{
    partial class FormHistorialProcesalNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistorialProcesalNuevo));
            this.gboxDatosHistorial = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpFechaNovedad = new System.Windows.Forms.DateTimePicker();
            this.txtDetalleNovedad = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnGuardarHistorial = new System.Windows.Forms.Button();
            this.cmbTipoNovedad = new System.Windows.Forms.ComboBox();
            this.btnCancelarHistorial = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdIngreso = new System.Windows.Forms.TextBox();
            this.gboxDatosHistorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxDatosHistorial
            // 
            this.gboxDatosHistorial.Controls.Add(this.label3);
            this.gboxDatosHistorial.Controls.Add(this.txtIdIngreso);
            this.gboxDatosHistorial.Controls.Add(this.label16);
            this.gboxDatosHistorial.Controls.Add(this.dtpFechaNovedad);
            this.gboxDatosHistorial.Controls.Add(this.txtDetalleNovedad);
            this.gboxDatosHistorial.Controls.Add(this.label18);
            this.gboxDatosHistorial.Controls.Add(this.btnGuardarHistorial);
            this.gboxDatosHistorial.Controls.Add(this.cmbTipoNovedad);
            this.gboxDatosHistorial.Controls.Add(this.btnCancelarHistorial);
            this.gboxDatosHistorial.Controls.Add(this.label17);
            this.gboxDatosHistorial.Location = new System.Drawing.Point(9, 4);
            this.gboxDatosHistorial.Name = "gboxDatosHistorial";
            this.gboxDatosHistorial.Size = new System.Drawing.Size(535, 271);
            this.gboxDatosHistorial.TabIndex = 303;
            this.gboxDatosHistorial.TabStop = false;
            this.gboxDatosHistorial.Text = "Nueva";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 15);
            this.label16.TabIndex = 214;
            this.label16.Text = "FECHA NOVEDAD";
            // 
            // dtpFechaNovedad
            // 
            this.dtpFechaNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNovedad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNovedad.Location = new System.Drawing.Point(9, 77);
            this.dtpFechaNovedad.Name = "dtpFechaNovedad";
            this.dtpFechaNovedad.Size = new System.Drawing.Size(116, 22);
            this.dtpFechaNovedad.TabIndex = 213;
            // 
            // txtDetalleNovedad
            // 
            this.txtDetalleNovedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleNovedad.Location = new System.Drawing.Point(7, 121);
            this.txtDetalleNovedad.Multiline = true;
            this.txtDetalleNovedad.Name = "txtDetalleNovedad";
            this.txtDetalleNovedad.Size = new System.Drawing.Size(518, 97);
            this.txtDetalleNovedad.TabIndex = 291;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 13);
            this.label18.TabIndex = 292;
            this.label18.Text = "DETALLE NOVEDAD";
            // 
            // btnGuardarHistorial
            // 
            this.btnGuardarHistorial.BackColor = System.Drawing.Color.White;
            this.btnGuardarHistorial.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnGuardarHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarHistorial.ForeColor = System.Drawing.Color.Green;
            this.btnGuardarHistorial.Location = new System.Drawing.Point(323, 226);
            this.btnGuardarHistorial.Name = "btnGuardarHistorial";
            this.btnGuardarHistorial.Size = new System.Drawing.Size(98, 35);
            this.btnGuardarHistorial.TabIndex = 296;
            this.btnGuardarHistorial.Text = "Guardar";
            this.btnGuardarHistorial.UseVisualStyleBackColor = false;
            this.btnGuardarHistorial.Click += new System.EventHandler(this.btnGuardarHistorial_Click);
            // 
            // cmbTipoNovedad
            // 
            this.cmbTipoNovedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoNovedad.FormattingEnabled = true;
            this.cmbTipoNovedad.Location = new System.Drawing.Point(138, 77);
            this.cmbTipoNovedad.Name = "cmbTipoNovedad";
            this.cmbTipoNovedad.Size = new System.Drawing.Size(242, 23);
            this.cmbTipoNovedad.TabIndex = 293;
            // 
            // btnCancelarHistorial
            // 
            this.btnCancelarHistorial.BackColor = System.Drawing.Color.White;
            this.btnCancelarHistorial.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnCancelarHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarHistorial.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCancelarHistorial.Location = new System.Drawing.Point(427, 226);
            this.btnCancelarHistorial.Name = "btnCancelarHistorial";
            this.btnCancelarHistorial.Size = new System.Drawing.Size(98, 35);
            this.btnCancelarHistorial.TabIndex = 297;
            this.btnCancelarHistorial.Text = "Cancelar";
            this.btnCancelarHistorial.UseVisualStyleBackColor = false;
            this.btnCancelarHistorial.Click += new System.EventHandler(this.btnCancelarHistorial_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(136, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 13);
            this.label17.TabIndex = 294;
            this.label17.Text = "TIPO NOVEDAD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 299;
            this.label3.Text = "ID INGRESO";
            // 
            // txtIdIngreso
            // 
            this.txtIdIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdIngreso.Enabled = false;
            this.txtIdIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdIngreso.Location = new System.Drawing.Point(9, 33);
            this.txtIdIngreso.Name = "txtIdIngreso";
            this.txtIdIngreso.Size = new System.Drawing.Size(134, 21);
            this.txtIdIngreso.TabIndex = 298;
            // 
            // FormHistorialProcesalNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 287);
            this.Controls.Add(this.gboxDatosHistorial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHistorialProcesalNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NUEVO HISTORIAL";
            this.Load += new System.EventHandler(this.FormHistorialProcesalNuevo_Load);
            this.gboxDatosHistorial.ResumeLayout(false);
            this.gboxDatosHistorial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxDatosHistorial;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpFechaNovedad;
        private System.Windows.Forms.TextBox txtDetalleNovedad;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnGuardarHistorial;
        private System.Windows.Forms.ComboBox cmbTipoNovedad;
        private System.Windows.Forms.Button btnCancelarHistorial;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdIngreso;
    }
}