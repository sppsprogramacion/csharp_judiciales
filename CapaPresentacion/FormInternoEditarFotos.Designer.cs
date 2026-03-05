namespace CapaPresentacion
{
    partial class FormInternoEditarFotos
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
            this.btnCancelarSubirImagen = new System.Windows.Forms.Button();
            this.btnQuitarImagen = new System.Windows.Forms.Button();
            this.btnBuscarImagen = new System.Windows.Forms.Button();
            this.btnSubir = new System.Windows.Forms.Button();
            this.pictureImagenCargar = new System.Windows.Forms.PictureBox();
            this.pictureFotoPD = new System.Windows.Forms.PictureBox();
            this.pictureFoto = new System.Windows.Forms.PictureBox();
            this.pictureFotoPI = new System.Windows.Forms.PictureBox();
            this.groupFotos = new System.Windows.Forms.GroupBox();
            this.radbtnPerfilDerecho = new System.Windows.Forms.RadioButton();
            this.radbtnFrente = new System.Windows.Forms.RadioButton();
            this.radbtnPerfilIzquierdo = new System.Windows.Forms.RadioButton();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImagenCargar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPI)).BeginInit();
            this.groupFotos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelarSubirImagen
            // 
            this.btnCancelarSubirImagen.BackColor = System.Drawing.Color.White;
            this.btnCancelarSubirImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarSubirImagen.Location = new System.Drawing.Point(225, 231);
            this.btnCancelarSubirImagen.Name = "btnCancelarSubirImagen";
            this.btnCancelarSubirImagen.Size = new System.Drawing.Size(77, 37);
            this.btnCancelarSubirImagen.TabIndex = 78;
            this.btnCancelarSubirImagen.Text = "Cancelar imagen";
            this.btnCancelarSubirImagen.UseVisualStyleBackColor = false;
            this.btnCancelarSubirImagen.Click += new System.EventHandler(this.btnCancelarSubirImagen_Click);
            // 
            // btnQuitarImagen
            // 
            this.btnQuitarImagen.BackColor = System.Drawing.Color.White;
            this.btnQuitarImagen.Image = global::CapaPresentacion.Properties.Resources.eliminar_basura;
            this.btnQuitarImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarImagen.Location = new System.Drawing.Point(313, 231);
            this.btnQuitarImagen.Name = "btnQuitarImagen";
            this.btnQuitarImagen.Size = new System.Drawing.Size(134, 37);
            this.btnQuitarImagen.TabIndex = 77;
            this.btnQuitarImagen.Text = "     Quitar imagen";
            this.btnQuitarImagen.UseVisualStyleBackColor = false;
            this.btnQuitarImagen.Click += new System.EventHandler(this.btnQuitarImagen_Click);
            // 
            // btnBuscarImagen
            // 
            this.btnBuscarImagen.BackColor = System.Drawing.Color.White;
            this.btnBuscarImagen.Image = global::CapaPresentacion.Properties.Resources.buscar;
            this.btnBuscarImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarImagen.Location = new System.Drawing.Point(72, 231);
            this.btnBuscarImagen.Name = "btnBuscarImagen";
            this.btnBuscarImagen.Size = new System.Drawing.Size(54, 37);
            this.btnBuscarImagen.TabIndex = 76;
            this.btnBuscarImagen.UseVisualStyleBackColor = false;
            this.btnBuscarImagen.Click += new System.EventHandler(this.btnBuscarImagen_Click);
            // 
            // btnSubir
            // 
            this.btnSubir.BackColor = System.Drawing.Color.White;
            this.btnSubir.Image = global::CapaPresentacion.Properties.Resources.upload;
            this.btnSubir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubir.Location = new System.Drawing.Point(137, 231);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(77, 37);
            this.btnSubir.TabIndex = 75;
            this.btnSubir.Text = "        Subir";
            this.btnSubir.UseVisualStyleBackColor = false;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // pictureImagenCargar
            // 
            this.pictureImagenCargar.Location = new System.Drawing.Point(76, 270);
            this.pictureImagenCargar.Name = "pictureImagenCargar";
            this.pictureImagenCargar.Size = new System.Drawing.Size(45, 37);
            this.pictureImagenCargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureImagenCargar.TabIndex = 74;
            this.pictureImagenCargar.TabStop = false;
            // 
            // pictureFotoPD
            // 
            this.pictureFotoPD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureFotoPD.Image = global::CapaPresentacion.Properties.Resources.interno_pd;
            this.pictureFotoPD.Location = new System.Drawing.Point(361, 19);
            this.pictureFotoPD.Name = "pictureFotoPD";
            this.pictureFotoPD.Size = new System.Drawing.Size(150, 170);
            this.pictureFotoPD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFotoPD.TabIndex = 73;
            this.pictureFotoPD.TabStop = false;
            // 
            // pictureFoto
            // 
            this.pictureFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureFoto.Image = global::CapaPresentacion.Properties.Resources.interno_ff;
            this.pictureFoto.Location = new System.Drawing.Point(186, 18);
            this.pictureFoto.Name = "pictureFoto";
            this.pictureFoto.Size = new System.Drawing.Size(150, 170);
            this.pictureFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFoto.TabIndex = 72;
            this.pictureFoto.TabStop = false;
            // 
            // pictureFotoPI
            // 
            this.pictureFotoPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureFotoPI.Image = global::CapaPresentacion.Properties.Resources.interno_pi;
            this.pictureFotoPI.Location = new System.Drawing.Point(11, 19);
            this.pictureFotoPI.Name = "pictureFotoPI";
            this.pictureFotoPI.Size = new System.Drawing.Size(150, 170);
            this.pictureFotoPI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFotoPI.TabIndex = 71;
            this.pictureFotoPI.TabStop = false;
            // 
            // groupFotos
            // 
            this.groupFotos.Controls.Add(this.btnCerrar);
            this.groupFotos.Controls.Add(this.radbtnPerfilDerecho);
            this.groupFotos.Controls.Add(this.radbtnFrente);
            this.groupFotos.Controls.Add(this.radbtnPerfilIzquierdo);
            this.groupFotos.Controls.Add(this.pictureFotoPI);
            this.groupFotos.Controls.Add(this.btnCancelarSubirImagen);
            this.groupFotos.Controls.Add(this.pictureFoto);
            this.groupFotos.Controls.Add(this.btnQuitarImagen);
            this.groupFotos.Controls.Add(this.pictureFotoPD);
            this.groupFotos.Controls.Add(this.btnBuscarImagen);
            this.groupFotos.Controls.Add(this.pictureImagenCargar);
            this.groupFotos.Controls.Add(this.btnSubir);
            this.groupFotos.Location = new System.Drawing.Point(15, 8);
            this.groupFotos.Name = "groupFotos";
            this.groupFotos.Size = new System.Drawing.Size(523, 374);
            this.groupFotos.TabIndex = 79;
            this.groupFotos.TabStop = false;
            // 
            // radbtnPerfilDerecho
            // 
            this.radbtnPerfilDerecho.AutoSize = true;
            this.radbtnPerfilDerecho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnPerfilDerecho.Location = new System.Drawing.Point(367, 195);
            this.radbtnPerfilDerecho.Name = "radbtnPerfilDerecho";
            this.radbtnPerfilDerecho.Size = new System.Drawing.Size(103, 19);
            this.radbtnPerfilDerecho.TabIndex = 81;
            this.radbtnPerfilDerecho.TabStop = true;
            this.radbtnPerfilDerecho.Text = "Perfil Derecho";
            this.radbtnPerfilDerecho.UseVisualStyleBackColor = true;
            this.radbtnPerfilDerecho.CheckedChanged += new System.EventHandler(this.radbtnPerfilDerecho_CheckedChanged);
            // 
            // radbtnFrente
            // 
            this.radbtnFrente.AutoSize = true;
            this.radbtnFrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnFrente.Location = new System.Drawing.Point(192, 195);
            this.radbtnFrente.Name = "radbtnFrente";
            this.radbtnFrente.Size = new System.Drawing.Size(60, 19);
            this.radbtnFrente.TabIndex = 80;
            this.radbtnFrente.TabStop = true;
            this.radbtnFrente.Text = "Frente";
            this.radbtnFrente.UseVisualStyleBackColor = true;
            this.radbtnFrente.CheckedChanged += new System.EventHandler(this.radbtnFrente_CheckedChanged);
            // 
            // radbtnPerfilIzquierdo
            // 
            this.radbtnPerfilIzquierdo.AutoSize = true;
            this.radbtnPerfilIzquierdo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbtnPerfilIzquierdo.Location = new System.Drawing.Point(17, 195);
            this.radbtnPerfilIzquierdo.Name = "radbtnPerfilIzquierdo";
            this.radbtnPerfilIzquierdo.Size = new System.Drawing.Size(107, 19);
            this.radbtnPerfilIzquierdo.TabIndex = 79;
            this.radbtnPerfilIzquierdo.TabStop = true;
            this.radbtnPerfilIzquierdo.Text = "Perfil Izquierdo";
            this.radbtnPerfilIzquierdo.UseVisualStyleBackColor = true;
            this.radbtnPerfilIzquierdo.CheckedChanged += new System.EventHandler(this.radbtnPerfilIzquierdo_CheckedChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.White;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCerrar.Location = new System.Drawing.Point(419, 323);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(98, 40);
            this.btnCerrar.TabIndex = 229;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormInternoEditarFotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(549, 394);
            this.Controls.Add(this.groupFotos);
            this.Name = "FormInternoEditarFotos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDITAR FOTOS";
            this.Load += new System.EventHandler(this.FormInternoEditarFotos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureImagenCargar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPI)).EndInit();
            this.groupFotos.ResumeLayout(false);
            this.groupFotos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureFotoPD;
        private System.Windows.Forms.PictureBox pictureFoto;
        private System.Windows.Forms.PictureBox pictureFotoPI;
        private System.Windows.Forms.Button btnCancelarSubirImagen;
        private System.Windows.Forms.Button btnQuitarImagen;
        private System.Windows.Forms.Button btnBuscarImagen;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.PictureBox pictureImagenCargar;
        private System.Windows.Forms.GroupBox groupFotos;
        private System.Windows.Forms.RadioButton radbtnPerfilIzquierdo;
        private System.Windows.Forms.RadioButton radbtnPerfilDerecho;
        private System.Windows.Forms.RadioButton radbtnFrente;
        private System.Windows.Forms.Button btnCerrar;
    }
}