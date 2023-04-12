using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;

namespace presentacion
{
    
    public partial class frmAltaArticulos : Form
    {
        private Articulos articulos = null;
        private OpenFileDialog archivo = null;
        public frmAltaArticulos()
        {
            InitializeComponent();
        }
        
        public frmAltaArticulos(Articulos articulos)
        {
            InitializeComponent();
            this.articulos = articulos;
            Text = "Modificar Articulos";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void btnAceptar_Click(object sender, EventArgs e)
         {

             ArticulosNegocio negocio = new ArticulosNegocio();

            if(btnAceptar != null) 
            {
                MessageBox.Show("complete  los campos");
            } 
            try 
            {
                if (articulos == null)
                    articulos = new Articulos();
                articulos.Codigo = txtCodigo.Text;
                articulos.Nombre = txtNombre.Text;
                articulos.Descripcion = txtDescripcion.Text;
                articulos.Marca = (Marcas)cboMarca.SelectedItem;
                articulos.Categoria = (Categorias)cboCategoria.SelectedItem;
                articulos.ImagenUrl = txtImagenUrl.Text;
                articulos.Precio = decimal.Parse(txtPrecio.Text);
                

                if (articulos.Id != 0)
                {
                    
                    negocio.modificar(articulos);
                    MessageBox.Show("Modificado exitoso");
                }
                else 
                {
                    negocio.agregar(articulos);
                    MessageBox.Show("Agregado exitoso");
                }

                // img guardada si la levanto localmente:
                if(archivo != null && txtImagenUrl.Text.ToUpper().Contains("HTTP"))// HTTP en mayuscula por el ToUpper
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Articulos-App"] + archivo.SafeFileName);

                Close();
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
            try
            {
                pbxArticulos.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulos.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/1665px-No-Image-Placeholder.svg.png");
            }
        }

        private void frmAltaArticulos_Load(object sender, EventArgs e)
        {
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

                if(articulos != null) 
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

        private void btnAgragarImg_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if(archivo.ShowDialog() == DialogResult.OK) 
            {
                txtImagenUrl.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Articulos-App"] + archivo.SafeFileName);
            }
        }

       

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbxArticulos_Click(object sender, EventArgs e)
        {

        }
    }
}
