using System;
using System.Data.SqlClient;

namespace Entidades
{
    public class PaqueteDAO
    {
        private static SqlCommand comando;     //ATRIBUTO PARA EL COMANDO
        private static SqlConnection conexion; //ATRIBUTO PARA LA CONEXION
        
        public PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        public static bool Insertar(Paquete p)
        {
            
            PaqueteDAO dao = new PaqueteDAO();
            bool retorno = false;
            string alumno = "Coarasa Walter";
            string archivo = string.Format("INSERT INTO[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno])VALUES('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, alumno);
            try
            {
                retorno = EjecutarNonQuery(archivo);
            }
            catch (Exception e)
            {
                throw new TrackingIdRepetidoException(e.Message);
            }
            return retorno;
        }

        //METODO QUE EJECUTA EL SQL 
        private static bool EjecutarNonQuery(string sql)
        {
            bool todoOk = false;
            try
            {
                // LE PASO LA INSTRUCCION SQL
                PaqueteDAO.comando.CommandText = sql;
                // ABRO LA CONEXION A LA Base de Datos
                PaqueteDAO.conexion.Open();
                // EJECUTO EL COMMANDO
                PaqueteDAO.comando.ExecuteNonQuery();
                todoOk = true;
            }
            catch (Exception e)
            {
                todoOk = false;
                throw e;
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
