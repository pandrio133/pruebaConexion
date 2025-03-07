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
            



        }

    }

    class Conectar
    {
        public Conectar() { }

        private String database { set; get; }
        private String user { set; get; }
        private String password { set; get; }

        public SqlConnection Conexion()
        {
            database = "PruebaConexion";
            user = "sa";
            password = "159753";
            String LineaConexion = "Server=HP; Database=" + database + ";User Id=" + user + ";Password=" + password + "; trustServerCertificate=true; encrypt=false;";
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
                String query = "Insert into personas(Nombre)values(@Nombre)";
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@Nombre",nombre);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarNombre(int id, String nombre)
        {
            using (SqlConnection connection= Conexion())
            {
                String query = "Update personas set Nombre=@Nombre where Id=@Id";
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarNombre(int id)
        {
            using(SqlConnection connection = Conexion())
            {
                String query = "Delete from personas where Id=@Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void EliminarNombre(String nombre)
        {
            using(SqlConnection connection = Conexion())
            {
                String query = "Delete from personas where Nombre=@Nombre";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.ExecuteNonQuery();
                }
            }
        }

    }

    public class InterfazGrafica
    {
        
    }
}
