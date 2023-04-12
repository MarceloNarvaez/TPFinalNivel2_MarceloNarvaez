using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentacion
{
    public partial class frmDetalle : Form
    {
        //private List<Articulos> Articulos;
        private Articulos articulos = null;
        public frmDetalle()
        {
            InitializeComponent();
        }

        public frmDetalle(Articulos articulos ) 
        {
            InitializeComponent();
            this.articulos = articulos;
            Text = "Detalle del Articulo";
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            //ArticulosNegocio negocio = new ArticulosNegocio();
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            CategoriasNegocio categoriasNegocio = new CategoriasNegocio();
            try
            {
                cboMarca.DataSource = marcasNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriasNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulos != null)
                {
                    txtCodigo.Text = articulos.Codigo;
                    txtNombre.Text = articulos.Nombre;
                    txtDescripcion.Text = articulos.Descripcion;
                    txtImagenUrl.Text = articulos.ImagenUrl;
                    cargarImagen(articulos.ImagenUrl);
                    cboMarca.SelectedValue = articulos.Marca.Id;
                    cboCategoria.SelectedValue = articulos.Categoria.Id;
                    txtPrecio.Text = articulos.Precio.ToString("0.00");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 

        }

        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }

        private void cargarImagen(string imagen)
        {
            //cargarImagen()
            try
            {
                pbxDetalle.Load(imagen);// si comento todo esto anda pero sin  la imagen
            }                             //
            catch (Exception ex)
            {
                pbxDetalle.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/1665px-No-Image-Placeholder.svg.png");
            }
        }


        private void pbxDetalle_Click(object sender, EventArgs e)
        {
            // a modo prueba , lo quise borrar pero me da error
        }

        private void lblImagenUrl_Leave(object sender, EventArgs e)
        {
            // a modo prueba , lo quise borrar pero me da error
        }

        

        
    }
}
