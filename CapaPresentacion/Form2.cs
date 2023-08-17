using Bunifu.UI.WinForms;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;
using TheArtOfDev.HtmlRenderer.Adapters;


namespace CapaPresentacion
{
    public partial class Form2 : Form
    {
        private Negocio negocio;
        private Conexion conexion;

        private int cantidadProductos;
        string cadenaConexion = "Data Source=CARLOSSANCHEZ\\SQLEXPRESS; Initial Catalog=PROYECTOF; integrated security = true";
        private Usuario usuarioActual;
        public Form2()
        {
            InitializeComponent();
            
            negocio = new Negocio(cadenaConexion);
            conexion = new Conexion(cadenaConexion);




        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages3.SetPage(0);
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPages3.SetPage(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Editar_Click(object sender, EventArgs e)
        {
  
            Form4 form4 = new Form4();
            form4.Show();
        }


        private void añadir_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

        }

        private void bunifuTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string dato = "%" + bunifuTextBox2.Text + "%";
            getBuscar(dato);
        }

        private void getBuscar(string dato)
        {
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.con;
            
            cmd.CommandText = "SELECT * FROM Productos WHERE NombreProducto LIKE @Dato OR Precio LIKE @Dato OR Cantidad LIKE @Dato";
            cmd.Parameters.AddWithValue("@Dato", "%" + dato + "%");

            
            bunifuDataGridView1.Columns.Clear();
            bunifuDataGridView1.AutoGenerateColumns = false;
            bunifuDataGridView1.Columns.Add("Id", "ID");
            bunifuDataGridView1.Columns.Add("NombreProducto", "Nombre");
            bunifuDataGridView1.Columns.Add("Precio", "Precio");
            bunifuDataGridView1.Columns.Add("Cantidad", "Cantidad");

           
            try
            {
                conexion.Abrir();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                    bunifuDataGridView1.Rows.Add(reader["Id"], reader["NombreProducto"], reader["Precio"], reader["Cantidad"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Cerrar();
            }
        }


        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void ActualizarListaProductos()
        {
            List<Producto> listaProductos = negocio.ObtenerProductos();
            bunifuDataGridView1.DataSource = listaProductos;
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {

  
            int idProducto = Convert.ToInt32(bunifuDataGridView1.CurrentRow.Cells["Id"].Value);


            bool resultado = negocio.EliminarProducto(idProducto);
            if (resultado)
            {
                MessageBox.Show("Producto eliminado correctamente.");
                ActualizarListaProductos();
            }
            else
            {
                MessageBox.Show("Error al eliminar el producto. Intente nuevamente.");
            }

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == bunifuDataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                bool resultado = negocio.EliminarProducto(id);

                if (resultado)
                {
                    MessageBox.Show("Producto eliminado correctamente.");

                    ActualizarListaProductos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto. Intente nuevamente.");
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

            DataTable dt = negocio.ObtenerCantidadProductosPorDia();

            chart1.Series.Clear();

            Series serie = chart1.Series.Add("Productos por día");
            serie.ChartType = SeriesChartType.Column;

           
            foreach (DataRow row in dt.Rows)
            {
                string ingreso = row["Fecha_Registro"].ToString();
                int cantidad = Convert.ToInt32(row["CantidadProductos"]);

                serie.Points.AddXY(ingreso, cantidad);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM Productos";
            int cantidadProductos = 0;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    cantidadProductos = (int)command.ExecuteScalar();
                }
            }

       
            totalp.Text = cantidadProductos.ToString();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}


    


