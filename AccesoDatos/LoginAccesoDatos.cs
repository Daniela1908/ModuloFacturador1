using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class LoginAccesoDatos
    {
        public LoginEntidad IniciarSesion(LoginEntidad loginEntidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "IniciarSesion";

                SqlParameter sqlParameterCorreo = new SqlParameter("@Correo", SqlDbType.VarChar);
                SqlParameter sqlParameterContrasena = new SqlParameter("@Contrasena", SqlDbType.VarChar);

                sqlParameterCorreo.Value = loginEntidad.Correo;
                sqlParameterContrasena.Value = loginEntidad.Contrasena;

                comando.Parameters.Add(sqlParameterCorreo);
                comando.Parameters.Add(sqlParameterContrasena);

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    LoginEntidad loginExitoso = new LoginEntidad();
                    loginExitoso.Correo = sqlDataReader["Correo"].ToString();
                    loginExitoso.Nombre = sqlDataReader["Nombre"].ToString();
                    loginExitoso.Apellidos = sqlDataReader["Apellidos"].ToString();
                    return loginExitoso;
                }
            }
            return null;
        }
    }
}
