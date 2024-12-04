using System.Data;
using System.Data.SqlClient;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class DB_AGENCIA
    {
        private static readonly string connectString = "Server=NOTEVW;Database=DB_AGENCIA;Integrated Security=True;";

        private static SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(connectString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao abrir a conexão com o banco de dados.", ex);
            }
        }

        public static void ExecuteNonQuery(SqlCommand command)
        {
            using (var connection = GetConnection())
            {
                command.Connection = connection;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao executar o comando SQL.", ex);
                }
            }
        }

        public static object ExecuteScalar(SqlCommand command)
        {
            using (var connection = GetConnection())
            {
                command.Connection = connection;
                try
                {
                    return command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao executar a consulta SQL.", ex);
                }
            }
        }

        public static DataTable ExecuteQuery(SqlCommand command)
        {
            using (var connection = GetConnection())
            {
                command.Connection = connection;

                using (var adapter = new SqlDataAdapter(command))
                {
                    var dataTable = new DataTable();
                    try
                    {
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao executar a consulta SQL.", ex);
                    }

                    return dataTable;
                }
            }
        }
    }

}

