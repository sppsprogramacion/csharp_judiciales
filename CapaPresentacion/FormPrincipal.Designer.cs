namespace CapaPresentacion
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.btnCerrarSistema = new System.Windows.Forms.Button();
            this.btnVerInternos = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTraslados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.BackColor = System.Drawing.Color.DarkCyan;
            this.lblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.White;
            this.lblEncabezado.Location = new System.Drawing.Point(1, 1);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(811, 29);
            this.lblEncabezado.TabIndex = 76;
            this.lblEncabezado.Text = "JUDICIALES";
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrarSistema
            // 
            this.btnCerrarSistema.BackColor = System.Drawing.Color.White;
            this.btnCerrarSistema.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnCerrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSistema.ForeColor = System.Drawing.Color.Teal;
            this.btnCerrarSistema.Location = new System.Drawing.Point(708, 438);
            this.btnCerrarSistema.Name = "btnCerrarSistema";
            this.btnCerrarSistema.Size = new System.Drawing.Size(93, 45);
            this.btnCerrarSistema.TabIndex = 77;
            this.btnCerrarSistema.Text = "Cerrar sistema";
            this.btnCerrarSistema.UseVisualStyleBackColor = false;
            this.btnCerrarSistema.Click += new System.EventHandler(this.btnCerrarSistema_Click);
            // 
            // btnVerInternos
            // 
            this.btnVerInternos.BackColor = System.Drawing.Color.DarkCyan;
            this.btnVerInternos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerInternos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerInternos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerInternos.ForeColor = System.Drawing.Color.White;
            this.btnVerInternos.Location = new System.Drawing.Point(12, 47);
            this.btnVerInternos.Name = "btnVerInternos";
            this.btnVerInternos.Size = new System.Drawing.Size(120, 70);
            this.btnVerInternos.TabIndex = 78;
            this.btnVerInternos.Text = "Internos";
            this.btnVerInternos.UseVisualStyleBackColor = false;
            this.btnVerInternos.Click += new System.EventHandler(this.btnVerInternos_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblUsuario.Location = new System.Drawing.Point(36, 467);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 16);
            this.lblUsuario.TabIndex = 80;
            this.lblUsuario.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::CapaPresentacion.Properties.Resources.usuario_verde;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.usuario_verde;
            this.pictureBox1.Location = new System.Drawing.Point(8, 462);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // btnTraslados
            // 
            this.btnTraslados.BackColor = System.Drawing.Color.Orange;
            this.btnTraslados.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTraslados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraslados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraslados.ForeColor = System.Drawing.Color.White;
            this.btnTraslados.Location = new System.Drawing.Point(141, 47);
            this.btnTraslados.Name = "btnTraslados";
            this.btnTraslados.Size = new System.Drawing.Size(120, 70);
            this.btnTraslados.TabIndex = 81;
            this.btnTraslados.Text = "Traslados";
            this.btnTraslados.UseVisualStyleBackColor = false;
            this.btnTraslados.Click += new System.EventHandler(this.btnTraslados_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(813, 495);
            this.Controls.Add(this.btnTraslados);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnVerInternos);
            this.Controls.Add(this.btnCerrarSistema);
            this.Controls.Add(this.lblEncabezado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Judiciales";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Button btnCerrarSistema;
        private System.Windows.Forms.Button btnVerInternos;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTraslados;
    }
}

