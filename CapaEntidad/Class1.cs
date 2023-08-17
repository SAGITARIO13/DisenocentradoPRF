using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Class1
    {
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public Rol Rol_ID { get; set; }
       

    }

    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class Conexion
    {
        public SqlConnection con { get; set; }

        public Conexion(string cadenaConexion)
        {
            con = new SqlConnection(cadenaConexion);
        }

        public void Abrir()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void Cerrar()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
