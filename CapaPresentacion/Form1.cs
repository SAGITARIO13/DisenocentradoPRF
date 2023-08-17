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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CapaDatos;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {

        private Negocio negocio;
        private Conexion conexion;


  

        public Form1()
        {
            InitializeComponent();

            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage2);
            string cadenaConexion = "Data Source=CARLOSSANCHEZ\\SQLEXPRESS; Initial Catalog=PROYECTOF; integrated security = true";
            negocio = new Negocio(cadenaConexion);
            conexion = new Conexion(cadenaConexion);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            string NombreUsuario = txtUsername.Text;
            string Contraseña = txtPassword.Text;

            Usuario usuarioActual = negocio.ObtenerUsuario(NombreUsuario);

            bool inicioSesionExitoso = negocio.IniciarSesion(NombreUsuario, Contraseña);

            if (inicioSesionExitoso)
            {
                if (usuarioActual.Rol_ID.Id == 2)
                {
                    secretariacs Secretaria = new secretariacs();
                    Secretaria.Show();
                }
                else
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            string NombreUsuario = txtUsername.Text;
            string Contraseña = txtPassword.Text;

            Usuario usuario = new Usuario { NombreUsuario = NombreUsuario };
            usuario.Contraseña = Contraseña;
            

            bool usuarioCreadoExitosamente = negocio.CrearUsuario(usuario);

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


