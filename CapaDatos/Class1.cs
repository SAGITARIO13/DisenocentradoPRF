using System;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CapaDatos
    {

        private Conexion conexion;
        public CapaDatos(string cadenaConexion)
        {
            conexion = new Conexion(cadenaConexion);
        }

        public bool IniciarSesion(string NombreUsuario, string Contraseña)
        {
            bool inicioSesionExitoso = false;

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM usuarios WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", conexion.con))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                    conexion.Abrir();

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        inicioSesionExitoso = true;
                    }
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

            return inicioSesionExitoso;
        }

            
        public bool CrearUsuario(Usuario usuario)
        {
            bool creado = false;

            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol_ID) VALUES (@NombreUsuario, @Contraseña, @Rol_ID)", conexion.con))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@Rol_ID", 1);
                    conexion.Abrir();

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {

                        creado = true;
                    }
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

            return creado;
        }
        public bool CrearUsuario2(Usuario usuario)
        {
            bool creado = false;

            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol_ID) VALUES (@NombreUsuario, @Contraseña, @Rol_ID)", conexion.con))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@Rol_ID", 2);
                    conexion.Abrir();

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {

                        creado = true;
                    }
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

            return creado;
        }
        public Usuario ObtenerUsuario(string NombreUsuario)
        {
            Usuario usuario = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario", conexion.con))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                    conexion.Abrir();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario = new Usuario()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            Contraseña = reader["Contraseña"].ToString(),
                            Rol_ID = new Rol()
                            {
                                Id = Convert.ToInt32(reader["Rol_ID"]),
                            }
                        };
                    }
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

            return usuario;
        }


    }
}
