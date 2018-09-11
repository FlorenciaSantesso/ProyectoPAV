using System;
using System.Data;
using System.Data.SqlClient;
public class BDHelper
{
    //conectar a mi bdd
    private string string_conexion = "Data Source=LAPTOP-US2QF1H8\\SQLEXPRESS;Initial Catalog=BugsClase04;User ID=sa;Password=sole$1404";
    private static BDHelper instance;
    public static BDHelper getDBHelper()
    {
        if (instance == null)
            instance = new BDHelper();
        return instance;
    }

    SqlConnection conexion = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    DataTable tabla = new DataTable();

    public void actualizarBD(string sql)
    {
            conexion.Open();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conexion.Close();
    }
    public DataTable ConsultaSQL(string strSql)
    {
         conexion.ConnectionString = string_conexion;
         conexion.Open();
         cmd.Connection = conexion;
         cmd.CommandType = CommandType.Text;
         cmd.CommandText = strSql;
         //  El datatable se carga con el resultado de ejecutar la sentencia en el motor de base de datos

         tabla.Load (cmd.ExecuteReader());
         //  La función retorna el objeto datatable con 0, 1 o mas registros
         return tabla;
         if ((conexion.State == ConnectionState.Open))
         {
             conexion.Close();
         }

          // Dispose() libera los recursos asociados a la conexón
          conexion.Dispose();
      }

}
