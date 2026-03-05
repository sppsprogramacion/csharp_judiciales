using CapaDatos;
using CapaNegocio;
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
    public partial class FormInternoEditarFotos : Form
    {
        public bool isFotoModificada { get; private set; }
        public DInterno dInternoGlobal { get; private set; }

        //PARA SUBIR IMAGEN
        string imagePath;
        string tipoFoto = "";

        public FormInternoEditarFotos(DInterno interno)
        {
            InitializeComponent();
            this.dInternoGlobal = interno;
        }

        private void FormInternoEditarFotos_Load(object sender, EventArgs e)
        {
            if (this.dInternoGlobal == null)
            {
                //tabInterno.Enabled = false;

                MessageBox.Show("No se encontro informaciòn del interno solicitado", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.isFotoModificada = false;

            groupFotos.Enabled = false;
            if (!string.IsNullOrEmpty(this.dInternoGlobal.foto))
            {
                pictureFoto.Load(this.dInternoGlobal.foto);
            }
            if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPI))
            {
                pictureFotoPI.Load(this.dInternoGlobal.fotoPI);
            }
            if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPD))
            {
                pictureFotoPD.Load(this.dInternoGlobal.fotoPD);
            }
            groupFotos.Enabled = true;
        }

        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.imagePath = ofd.FileName;
                    pictureImagenCargar.Image = System.Drawing.Image.FromFile(imagePath);
                }
            }
        }

        private void btnCancelarSubirImagen_Click(object sender, EventArgs e)
        {
            pictureImagenCargar.Image = null;
            this.imagePath = "";
        }

        private async void btnSubir_Click(object sender, EventArgs e)
        {
            NInterno nInterno = new NInterno();

            int idCiudadano = Convert.ToInt32(this.dInternoGlobal.id_interno);
            string rutaImagen = this.imagePath; // o lo que hayas guardado al seleccionar la imagen
            groupFotos.Enabled = false;
            var (exito, errorResponse) = await nInterno.subirImagen(idCiudadano, rutaImagen, this.tipoFoto);
            groupFotos.Enabled = true;

            if (exito)
            {
                MessageBox.Show("Imagen subida correctamente.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //buscar y actualizar el ciudadano this.dCiudadano
                this.BuscarInterno();
                this.isFotoModificada = true;
                pictureImagenCargar.Image = null;
                this.imagePath = "";
            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        //BUSCAR INTERNO
        private async void BuscarInterno()
        {
            int idInterno;
            NInterno nInterno = new NInterno();
            DInterno dInterno = new DInterno();
            idInterno = Convert.ToInt32(this.dInternoGlobal.id_interno);
            groupFotos.Enabled = false;
            (DInterno dInternoResponse, string errorInternoResponse) = await nInterno.BuscarInternoXID(idInterno);
            groupFotos.Enabled = true;

            dInterno = dInternoResponse;

            if (dInterno == null)
            {
                MessageBox.Show("No se encontro informaciòn del interno solicitado: " + errorInternoResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.dInternoGlobal = dInterno;

            groupFotos.Enabled = false;
            if (!string.IsNullOrEmpty(this.dInternoGlobal.foto))
            {
                pictureFoto.Load(this.dInternoGlobal.foto);
            }
            if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPI))
            {
                pictureFotoPI.Load(this.dInternoGlobal.fotoPI);
            }
            if (!string.IsNullOrEmpty(this.dInternoGlobal.fotoPD))
            {
                pictureFotoPD.Load(this.dInternoGlobal.fotoPD);
            }
            groupFotos.Enabled = true;
        }

        //FIN BUSCAR INTERNO................................................................
        private void radbtnPerfilIzquierdo_CheckedChanged(object sender, EventArgs e)
        {
            this.tipoFoto = "FPI";
        }

        private void radbtnFrente_CheckedChanged(object sender, EventArgs e)
        {
            this.tipoFoto = "FF";
        }

        private void radbtnPerfilDerecho_CheckedChanged(object sender, EventArgs e)
        {
            this.tipoFoto = "FPD";
        }

        private async void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Esta seguro  que desea quitar la imagen?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                MessageBox.Show("Ha cancelado la operacion.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NInterno nInterno = new NInterno();

            int idInterno = Convert.ToInt32(this.dInternoGlobal.id_interno);

            groupFotos.Enabled = false;
            var (exito, errorResponse) = await nInterno.quitarImagen(idInterno, this.tipoFoto);
            groupFotos.Enabled = true;

            if (exito)
            {
                MessageBox.Show("Imagen quitada correctamente.", "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //buscar y actualizar el ciudadano this.dCiudadano
                this.BuscarInterno();
                this.isFotoModificada = true;
                pictureImagenCargar.Image = null;

            }
            else
            {
                MessageBox.Show(errorResponse, "Judiciales", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Para indicar que cerró bien
            this.Close();
        }
    }
}
