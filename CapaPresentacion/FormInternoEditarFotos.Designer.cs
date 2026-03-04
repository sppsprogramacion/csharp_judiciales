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
            ((System.ComponentModel.ISupportInitialize)(this.pictureImagenCargar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPI)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelarSubirImagen
            // 
            this.btnCancelarSubirImagen.BackColor = System.Drawing.Color.White;
            this.btnCancelarSubirImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarSubirImagen.Location = new System.Drawing.Point(316, 246);
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
            this.btnQuitarImagen.Location = new System.Drawing.Point(172, 305);
            this.btnQuitarImagen.Name = "btnQuitarImagen";
            this.btnQuitarImagen.Size = new System.Drawing.Size(134, 37);
            this.btnQuitarImagen.TabIndex = 77;
            this.btnQuitarImagen.Text = "     Quitar imagen";
            this.btnQuitarImagen.UseVisualStyleBackColor = false;
            // 
            // btnBuscarImagen
            // 
            this.btnBuscarImagen.BackColor = System.Drawing.Color.White;
            this.btnBuscarImagen.Image = global::CapaPresentacion.Properties.Resources.buscar;
            this.btnBuscarImagen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarImagen.Location = new System.Drawing.Point(171, 246);
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
            this.btnSubir.Location = new System.Drawing.Point(229, 246);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(77, 37);
            this.btnSubir.TabIndex = 75;
            this.btnSubir.Text = "        Subir";
            this.btnSubir.UseVisualStyleBackColor = false;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // pictureImagenCargar
            // 
            this.pictureImagenCargar.Location = new System.Drawing.Point(405, 246);
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
            this.pictureFotoPD.Location = new System.Drawing.Point(408, 42);
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
            this.pictureFoto.Location = new System.Drawing.Point(233, 41);
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
            this.pictureFotoPI.Location = new System.Drawing.Point(58, 42);
            this.pictureFotoPI.Name = "pictureFotoPI";
            this.pictureFotoPI.Size = new System.Drawing.Size(150, 170);
            this.pictureFotoPI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFotoPI.TabIndex = 71;
            this.pictureFotoPI.TabStop = false;
            // 
            // FormInternoEditarFotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 383);
            this.Controls.Add(this.btnCancelarSubirImagen);
            this.Controls.Add(this.btnQuitarImagen);
            this.Controls.Add(this.btnBuscarImagen);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.pictureImagenCargar);
            this.Controls.Add(this.pictureFotoPD);
            this.Controls.Add(this.pictureFoto);
            this.Controls.Add(this.pictureFotoPI);
            this.Name = "FormInternoEditarFotos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDITAR FOTOS";
            this.Load += new System.EventHandler(this.FormInternoEditarFotos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureImagenCargar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFotoPI)).EndInit();
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
    }
}