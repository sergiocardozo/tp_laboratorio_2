using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor estatico que va inicializar la conexion a SQL
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("server =.\\SQLEXPRESS;Database=correo-sp-2017;Trusted_Connection=True;");
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.Add("@direccionEntrega", System.Data.SqlDbType.VarChar);
            comando.Parameters.Add("@trackingID", System.Data.SqlDbType.VarChar);
            comando.Parameters.AddWithValue("@alumno", "Sergio Esteban Cardozo");
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Guarda un objeto del tipo paquete en la base de datos
        /// </summary>
        /// <param name="p">Paquete a guardar</param>
        /// <returns>retorna true si se guardo correctamente</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                conexion.Open();
                string commandoString = "INSERT INTO dbo.paquetes (direccionEntrega,trackingID,alumno) VALUES (@direccionEntrega, @trackingID, @alumno)";
                comando.Parameters["@direccionEntrega"].Value = p.DireccionEntrega;
                comando.Parameters["@trackingID"].Value = p.TrackingID;
                comando.CommandText = commandoString;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            return true;
        } 
        #endregion
    }
}
