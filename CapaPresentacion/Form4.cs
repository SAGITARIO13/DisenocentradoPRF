using CapaEntidad;
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
    public partial class Form4 : Form
    {
        private Negocio negocio;
        private Conexion conexion;

        public Form4()
        {
            InitializeComponent();
            string cadenaConexion = "Data Source=CARLOSSANCHEZ\\SQLEXPRESS; Initial Catalog=PROYECTOF; integrated security = true";
            negocio = new Negocio(cadenaConexion);
            conexion = new Conexion(cadenaConexion);
        }

        private void editp_Click(object sender, EventArgs e)
        {
            // Obtener el producto a editar
            Producto producto = new Producto();
            producto.Id = int.Parse(idp.Text);
            producto.NombreProducto = nombrep.Text;
            producto.Precio = decimal.Parse(preciop.Text);
            producto.Cantidad = int.Parse(cantidadp.Text);
            producto.FechaRegistro = bunifuDatePicker2.Value;

            bool resultado = negocio.EditarProducto(producto);

           
            if (resultado)
            {
                MessageBox.Show("Producto editado correctamente.");
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Error al editar el producto. Intente nuevamente.");
            }
        }

        private void ActualizarDataGridView()
        {
            
            List<Producto> productos = negocio.ObtenerProductos();
            bunifuDataGridView1.DataSource = productos;
        }

        private void mproductos_Click(object sender, EventArgs e)
        {
            List<Producto> productos = negocio.ObtenerProductos();
            bunifuDataGridView1.DataSource = productos;
        }
    }
}
