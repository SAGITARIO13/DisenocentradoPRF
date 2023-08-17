using Bunifu.UI.WinForms;
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
    public partial class Form3 : Form
    {
        private Negocio negocio;
        private Conexion conexion;
        public Form3()
        {
            InitializeComponent();
            string cadenaConexion = "Data Source=CARLOSSANCHEZ\\SQLEXPRESS; Initial Catalog=PROYECTOF; integrated security = true";
            negocio = new Negocio(cadenaConexion);
            conexion = new Conexion(cadenaConexion);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void precio_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Addproduct_Click(object sender, EventArgs e)
        {

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
 
        


        private void precio_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
