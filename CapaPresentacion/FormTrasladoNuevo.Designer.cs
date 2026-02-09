namespace CapaPresentacion
{
    partial class FormTrasladoNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrasladoNuevo));
            this.label27 = new System.Windows.Forms.Label();
            this.txtIdIngreso = new System.Windows.Forms.TextBox();
            this.dtpFechaEgreso = new System.Windows.Forms.DateTimePicker();
            this.label68 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.cmbOrganismoDestino = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.txtDetalleTraslado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 15);
            this.label27.TabIndex = 252;
            this.label27.Text = "ID INGRESO";
            // 
            // txtIdIngreso
            // 
            this.txtIdIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdIngreso.Enabled = false;
            this.txtIdIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdIngreso.Location = new System.Drawing.Point(15, 26);
            this.txtIdIngreso.Name = "txtIdIngreso";
            this.txtIdIngreso.Size = new System.Drawing.Size(134, 21);
            this.txtIdIngreso.TabIndex = 251;
            // 
            // dtpFechaEgreso
            // 
            this.dtpFechaEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEgreso.Location = new System.Drawing.Point(16, 78);
            this.dtpFechaEgreso.Name = "dtpFechaEgreso";
            this.dtpFechaEgreso.Size = new System.Drawing.Size(133, 22);
            this.dtpFechaEgreso.TabIndex = 246;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(12, 59);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(100, 15);
            this.label68.TabIndex = 250;
            this.label68.Text = "FECHA EGRESO";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(165, 59);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(137, 15);
            this.label74.TabIndex = 248;
            this.label74.Text = "ORGANISMO DESTINO";
            // 
            // cmbOrganismoDestino
            // 
            this.cmbOrganismoDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrganismoDestino.FormattingEnabled = true;
            this.cmbOrganismoDestino.Location = new System.Drawing.Point(168, 78);
            this.cmbOrganismoDestino.Name = "cmbOrganismoDestino";
            this.cmbOrganismoDestino.Size = new System.Drawing.Size(315, 23);
            this.cmbOrganismoDestino.TabIndex = 247;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Green;
            this.btnGuardar.Location = new System.Drawing.Point(379, 302);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 40);
            this.btnGuardar.TabIndex = 253;
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
            this.btnCancelar.Location = new System.Drawing.Point(492, 302);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 40);
            this.btnCancelar.TabIndex = 254;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(13, 105);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(129, 15);
            this.label42.TabIndex = 256;
            this.label42.Text = "DETALLE TRASLADO:";
            // 
            // txtDetalleTraslado
            // 
            this.txtDetalleTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalleTraslado.Location = new System.Drawing.Point(16, 124);
            this.txtDetalleTraslado.Multiline = true;
            this.txtDetalleTraslado.Name = "txtDetalleTraslado";
            this.txtDetalleTraslado.Size = new System.Drawing.Size(574, 166);
            this.txtDetalleTraslado.TabIndex = 255;
            // 
            // FormTrasladoNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 365);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.txtDetalleTraslado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtIdIngreso);
            this.Controls.Add(this.dtpFechaEgreso);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.cmbOrganismoDestino);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTrasladoNuevo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NUEVO TRASLADO";
            this.Load += new System.EventHandler(this.FormTrasladoNuevo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtIdIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaEgreso;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.ComboBox cmbOrganismoDestino;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtDetalleTraslado;
    }
}