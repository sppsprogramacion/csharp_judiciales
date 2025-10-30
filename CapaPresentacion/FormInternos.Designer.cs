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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvInternos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.txtApellidoBusqueda = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
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
            this.btnNuevo.Location = new System.Drawing.Point(9, 25);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(98, 40);
            this.btnNuevo.TabIndex = 116;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvInternos);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 454);
            this.groupBox2.TabIndex = 117;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Internos";
            // 
            // dtgvInternos
            // 
            this.dtgvInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvInternos.Location = new System.Drawing.Point(9, 77);
            this.dtgvInternos.Name = "dtgvInternos";
            this.dtgvInternos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvInternos.Size = new System.Drawing.Size(800, 368);
            this.dtgvInternos.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.btnBuscarApellido);
            this.groupBox1.Controls.Add(this.txtApellidoBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 78);
            this.groupBox1.TabIndex = 116;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(8, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 16);
            this.label26.TabIndex = 68;
            this.label26.Text = "APELLIDO";
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBuscarApellido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarApellido.ForeColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Location = new System.Drawing.Point(259, 21);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(93, 45);
            this.btnBuscarApellido.TabIndex = 2;
            this.btnBuscarApellido.Text = "Buscar apellido";
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // txtApellidoBusqueda
            // 
            this.txtApellidoBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoBusqueda.Location = new System.Drawing.Point(11, 39);
            this.txtApellidoBusqueda.Name = "txtApellidoBusqueda";
            this.txtApellidoBusqueda.Size = new System.Drawing.Size(227, 22);
            this.txtApellidoBusqueda.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.DarkCyan;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(0, -1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(823, 29);
            this.label28.TabIndex = 115;
            this.label28.Text = "INTERNOS";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormInternos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 763);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label28);
            this.Name = "FormInternos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInternos";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInternos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvInternos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.TextBox txtApellidoBusqueda;
        private System.Windows.Forms.Label label28;
    }
}