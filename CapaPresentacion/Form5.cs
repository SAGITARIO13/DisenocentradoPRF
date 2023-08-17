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
    public partial class Form5 : Form
    {
        private Negocio negocio;
        private Conexion conexion;
        public Form5()
        {
            InitializeComponent();
            string cadenaConexion = "Data Source=CARLOSSANCHEZ\\SQLEXPRESS; Initial Catalog=PROYECTOF; integrated security = true";
            negocio = new Negocio(cadenaConexion);
            conexion = new Conexion(cadenaConexion);

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string NombreUsuario = usernametxt.Text;
            string Contraseña = passwordtxt.Text;

            Usuario usuario = new Usuario { NombreUsuario = NombreUsuario };
            usuario.Contraseña = Contraseña;


            bool usuarioCreadoExitosamente = negocio.CrearUsuario2(usuario);

            if (usuarioCreadoExitosamente)
            {
                MessageBox.Show("Usuario creado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al crear usuario");
            }
        }
    }
}
