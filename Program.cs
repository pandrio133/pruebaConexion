//estructura
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Diagnostics;



//logica
namespace pruebaConexion
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /**/
            IGUConsole star = new IGUConsole();
            star.run();
            
            
            
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

    public class IGUConsole
    {
        public IGUConsole()
        {

        }
        public void run()
        {

            Console.Title = "Prueba de Conexion a BASE DE DATOS SQL ";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("=================================================================");
            Console.WriteLine("=\t\t\tMENÚ DE INICIO\t\t\t\t=");
            Console.WriteLine("=================================================================");
            String ingreso;
            int opt;
            do
            {
                Console.WriteLine("Consultas disponibles::");
                Console.WriteLine("1) Mostrar Datos" +
                    "\n2) Insertar Dato" +
                    "\n3) Actualizar Dato" +
                    "\n4) Eliminar Dato" +
                    "\n5) SALIR");
                Console.WriteLine("=================================================================");
                ingreso = Console.ReadLine();
                if (!int.TryParse(ingreso, out opt) || opt>5 ||opt<1 )
                {
                    Console.WriteLine("---¡¡Valor Invaliudo!!---");
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                }
            }
            while (!int.TryParse(ingreso, out opt) || opt > 5 || opt < 1);

            Conectar con = new Conectar();
            switch (opt)
            {
                case 1:  
                    Console.WriteLine("============ Lista de Nombres ============");
                    con.MostrarNombres();
                    Console.WriteLine("==========================================");
                    run(); 
                    break;
                case 2:
                    Console.WriteLine("Ingrese el nombre a AGREGAR porfavor::");
                    ingreso = Console.ReadLine();
                    try
                    {
                    con.InsertarNombre(ingreso);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("¡¡ERROR de ingreso!!");
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        
                        throw;
                    }
                    Console.WriteLine("**Ingresado con EXITO**");
                    run();
                    break;
                case 3: 
                    int id;
                    do
                    {
                        Console.WriteLine("Ingrese el ID del Nombre a ACTUALIZAR porfavor::");
                        ingreso = Console.ReadLine();
                        if (!int.TryParse(ingreso, out id))
                        {  
                        Console.WriteLine("---¡¡Valor Invaliudo!!---");
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        }
                    } while (!int.TryParse(ingreso, out id));
                    Console.WriteLine("Ingrese el nuevo Nombre porfavor::");
                    ingreso = Console.ReadLine();
                    try
                    {
                        con.ActualizarNombre(id,ingreso);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("¡¡ERROR de ingreso!!");
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();

                        throw;
                    }
                    Console.WriteLine("**Ingresado con EXITO**");
                    run();
                    break;
                case 4:
                    do
                    {
                        Console.WriteLine("Ingrese el ID del Nombre a ELIMINAR porfavor::");
                        ingreso = Console.ReadLine();
                        if (!int.TryParse(ingreso, out id))
                        {
                            Console.WriteLine("---¡¡Valor Invaliudo!!---");
                            Console.Beep();
                            Console.Beep();
                            Console.Beep();
                            Console.Beep();
                        }
                    } while (!int.TryParse(ingreso, out id));
                    try
                    {
                        con.EliminarNombre(id);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("¡¡ERROR de solicitud!!");
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();

                        throw;
                    }
                    Console.WriteLine("**Eliminado con EXITO**");
                    run();
                    break;
                case 5: exit(); break;
                default:
                    break;
            }

        }

        public void exit()
        {
             Environment.Exit(0);

        }

    
    }
}
