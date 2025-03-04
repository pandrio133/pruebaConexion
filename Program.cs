//estructura
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

//logica
namespace pruebaConexion
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Conectar c = new Conectar();
            
        }

    }

    class Conectar
    {
        public Conectar(){}

        String database { set;get; } 
        String user { set; get; } 
        String password{set; get; }
                
        public SqlConnection Conexion()
        {
            database = "PruebaConexion";
            user = "sa";
            password = "159753";
            String LineaConexion = "Server=localhost;Database="+database+";User Id="+user+";Password="+password;

            using (SqlConnection conexion = new SqlConnection(LineaConexion))
            {
                conexion.Open();
                return conexion;
            }
        }

        public void MostrarNombres()
        {
            using (SqlConnection connection = Conexion())
            {
                String query = "";
            };
        }

        


    }
}
