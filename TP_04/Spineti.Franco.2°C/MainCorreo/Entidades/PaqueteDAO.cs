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
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Inserta en la BD un objeto de tipo paquete.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            StringBuilder query = new StringBuilder();

            query.AppendFormat("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}')",
                p.DireccionEntrega,p.TrackingID,"Franco Spineti");

            return EjecutarNonQuery(query.ToString());
        }

        /// <summary>
        /// Creo la conexion a la BD e inicializo el comando para las querys.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection("Data Source=FRANCO-PC;Initial Catalog=correo-sp-2017;Integrated Security=True");
            //PaqueteDAO.conexion = new SqlConnection("Data Source=\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        /// <summary>
        /// Metodo que recibe una query y la ejecuta.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static bool EjecutarNonQuery(string sql)
        {
            bool todoOk = false;
            try
            {
                PaqueteDAO.comando.CommandText = sql;
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
                todoOk = true;
            }
            catch (Exception e)
            {
                todoOk = false;
            }
            finally
            {
                if (todoOk)
                    PaqueteDAO.conexion.Close();
            }
            return todoOk;
        }
    }
}
