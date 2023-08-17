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
    public partial class secretariacs : Form
    {
        private Negocio negocio;
        private Conexion conexion;
        public secretariacs()
        {
            InitializeComponent();
            string cadenaConexion = "Data Source=CARLOSSANCHEZ\\SQLEXPRESS; Initial Catalog=PROYECTOF; integrated security = true";
            negocio = new Negocio(cadenaConexion);
            conexion = new Conexion(cadenaConexion);
        }

        private void Addp_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.NombreProducto = nombretxt.Text;
            producto.Precio = decimal.Parse(preciotxt.Text);
            producto.Cantidad = int.Parse(cantidadtxt.Text);
            producto.FechaRegistro = bunifuDatePicker1.Value;
            bool resultado = negocio.AgregarProducto(producto);

            
            if (resultado)
            {
                MessageBox.Show("Producto agregado correctamente.");
                List<Producto> productos = negocio.ObtenerProductos();

                
                bunifuDataGridView2.DataSource = productos;
                bunifuDataGridView2.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agregar el producto. Intente nuevamente.");
            }
        }
    }
}
