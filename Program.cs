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

            c.MostrarNombres();
        }

    }

    class Conectar
    {
        public Conectar() { }

        String database { set; get; }
        String user { set; get; }
        String password { set; get; }

        public SqlConnection Conexion()
        {
            database = "PruebaConexion";
            user = "";
            password = "159753";
            String LineaConexion = "Server=HP; Database=" + database + ";User Id=sa;Password=" + password + "; trustServerCertificate=true; encrypt=false;";
            SqlConnection conexion = new SqlConnection(LineaConexion);
            conexion.Open();
            return conexion;
        }

        public void MostrarNombres()
        {
            using (SqlConnection connection = Conexion())
            {
                String query = "select * from personas";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Lista de nombres");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID = {reader["ID"]}  Nombre = {reader["Nombre"]}");
                    }
                }
            }
        }

        public void InsertarNombre(string nombre)
        {
            using (SqlConnection connection = Conexion())
            {
                String query = "Insert into personas(Nombre) value (@Nombre)";
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarNombre()
        {

        }

    }
}
