namespace CapaPresentacion
{
    partial class FormInternos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInternos));
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvInternos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProcesadosProvinciales = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtProblacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPenadosProvinciales = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgregados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPenadosFederales = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMedidaSeguridad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProcesadosFederales = new System.Windows.Forms.TextBox();
            this.btnActualizarPoblacion = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInternos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(17, 205);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(93, 70);
            this.btnNuevo.TabIndex = 116;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvInternos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(850, 454);
            this.groupBox2.TabIndex = 117;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Internos";
            // 
            // dtgvInternos
            // 
            this.dtgvInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvInternos.Location = new System.Drawing.Point(9, 24);
            this.dtgvInternos.Name = "dtgvInternos";
            this.dtgvInternos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvInternos.Size = new System.Drawing.Size(830, 416);
            this.dtgvInternos.TabIndex = 16;
            this.dtgvInternos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvInternos_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBusqueda);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.btnBuscarApellido);
            this.groupBox1.Controls.Add(this.txtBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(116, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 78);
            this.groupBox1.TabIndex = 116;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(6, 38);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(244, 23);
            this.cmbBusqueda.TabIndex = 69;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(264, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(171, 16);
            this.label26.TabIndex = 68;
            this.label26.Text = "APELLIDO / PRONTUARIO";
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.White;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnBuscarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnBuscarApellido.Location = new System.Drawing.Point(571, 33);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(98, 30);
            this.btnBuscarApellido.TabIndex = 2;
            this.btnBuscarApellido.Text = "Buscar";
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(267, 39);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(282, 22);
            this.txtBusqueda.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(179, 15);
            this.label11.TabIndex = 196;
            this.label11.Text = "PROCESADOS PROVINCIALES";
            // 
            // txtProcesadosProvinciales
            // 
            this.txtProcesadosProvinciales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcesadosProvinciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcesadosProvinciales.Location = new System.Drawing.Point(17, 72);
            this.txtProcesadosProvinciales.Name = "txtProcesadosProvinciales";
            this.txtProcesadosProvinciales.ReadOnly = true;
            this.txtProcesadosProvinciales.Size = new System.Drawing.Size(185, 21);
            this.txtProcesadosProvinciales.TabIndex = 194;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 15);
            this.label15.TabIndex = 193;
            this.label15.Text = "POBLACION ACTUAL";
            // 
            // txtProblacion
            // 
            this.txtProblacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProblacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProblacion.Location = new System.Drawing.Point(17, 28);
            this.txtProblacion.Name = "txtProblacion";
            this.txtProblacion.ReadOnly = true;
            this.txtProblacion.Size = new System.Drawing.Size(185, 21);
            this.txtProblacion.TabIndex = 192;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(228, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 15);
            this.label2.TabIndex = 199;
            this.label2.Text = "PENADOS PROVINCIALES";
            // 
            // txtPenadosProvinciales
            // 
            this.txtPenadosProvinciales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPenadosProvinciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPenadosProvinciales.Location = new System.Drawing.Point(231, 72);
            this.txtPenadosProvinciales.Name = "txtPenadosProvinciales";
            this.txtPenadosProvinciales.ReadOnly = true;
            this.txtPenadosProvinciales.Size = new System.Drawing.Size(185, 21);
            this.txtPenadosProvinciales.TabIndex = 198;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(228, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 207;
            this.label3.Text = "AGREGADOS";
            // 
            // txtAgregados
            // 
            this.txtAgregados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgregados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgregados.Location = new System.Drawing.Point(231, 158);
            this.txtAgregados.Name = "txtAgregados";
            this.txtAgregados.ReadOnly = true;
            this.txtAgregados.Size = new System.Drawing.Size(185, 21);
            this.txtAgregados.TabIndex = 206;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(228, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 15);
            this.label4.TabIndex = 205;
            this.label4.Text = "PENADOS FEDERALES";
            // 
            // txtPenadosFederales
            // 
            this.txtPenadosFederales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPenadosFederales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPenadosFederales.Location = new System.Drawing.Point(231, 115);
            this.txtPenadosFederales.Name = "txtPenadosFederales";
            this.txtPenadosFederales.ReadOnly = true;
            this.txtPenadosFederales.Size = new System.Drawing.Size(185, 21);
            this.txtPenadosFederales.TabIndex = 203;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 15);
            this.label5.TabIndex = 204;
            this.label5.Text = "MEDIDA DE SEGURIDAD";
            // 
            // txtMedidaSeguridad
            // 
            this.txtMedidaSeguridad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMedidaSeguridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedidaSeguridad.Location = new System.Drawing.Point(17, 158);
            this.txtMedidaSeguridad.Name = "txtMedidaSeguridad";
            this.txtMedidaSeguridad.ReadOnly = true;
            this.txtMedidaSeguridad.Size = new System.Drawing.Size(185, 21);
            this.txtMedidaSeguridad.TabIndex = 202;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 15);
            this.label6.TabIndex = 201;
            this.label6.Text = "PROCESADOS FEDERALES";
            // 
            // txtProcesadosFederales
            // 
            this.txtProcesadosFederales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcesadosFederales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcesadosFederales.Location = new System.Drawing.Point(17, 115);
            this.txtProcesadosFederales.Name = "txtProcesadosFederales";
            this.txtProcesadosFederales.ReadOnly = true;
            this.txtProcesadosFederales.Size = new System.Drawing.Size(185, 21);
            this.txtProcesadosFederales.TabIndex = 200;
            // 
            // btnActualizarPoblacion
            // 
            this.btnActualizarPoblacion.BackColor = System.Drawing.Color.White;
            this.btnActualizarPoblacion.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnActualizarPoblacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarPoblacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarPoblacion.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnActualizarPoblacion.Location = new System.Drawing.Point(432, 150);
            this.btnActualizarPoblacion.Name = "btnActualizarPoblacion";
            this.btnActualizarPoblacion.Size = new System.Drawing.Size(168, 30);
            this.btnActualizarPoblacion.TabIndex = 70;
            this.btnActualizarPoblacion.Text = "Actualizar poblacion";
            this.btnActualizarPoblacion.UseVisualStyleBackColor = false;
            this.btnActualizarPoblacion.Click += new System.EventHandler(this.btnActualizarPoblacion_Click);
            // 
            // FormInternos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(865, 749);
            this.Controls.Add(this.btnActualizarPoblacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAgregados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPenadosFederales);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMedidaSeguridad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProcesadosFederales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPenadosProvinciales);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtProcesadosProvinciales);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtProblacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInternos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INTERNOS";
            this.Load += new System.EventHandler(this.FormInternos_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInternos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvInternos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cmbBusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProcesadosProvinciales;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtProblacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPenadosProvinciales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgregados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPenadosFederales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMedidaSeguridad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProcesadosFederales;
        private System.Windows.Forms.Button btnActualizarPoblacion;
    }
}