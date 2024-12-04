using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class ConfigAvariaDAO
    {
        public static void InsertConfigAvaria(ConfigAvariaViewModel configAvaria)
        {
            var command = new SqlCommand("sp_InsertConfigAvaria");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CD_AVARIA", configAvaria.CdAvaria);
            command.Parameters.AddWithValue("@NM_AVARIA", configAvaria.NmAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void UpdateConfigAvaria(ConfigAvariaViewModel configAvaria)
        {
            var command = new SqlCommand("sp_UpdateConfigAvaria");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_AVARIA", configAvaria.IdAvaria);
            command.Parameters.AddWithValue("@CD_AVARIA", configAvaria.CdAvaria);
            command.Parameters.AddWithValue("@NM_AVARIA", configAvaria.NmAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void DeleteConfigAvaria(int idAvaria)
        {
            var command = new SqlCommand("sp_DeleteConfigAvaria");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_AVARIA", idAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static ConfigAvariaViewModel GetConfigAvariaById(int idAvaria)
        {
            var command = new SqlCommand("SELECT * FROM TB_CONFIG_AVARIA WHERE ID_AVARIA = @ID_AVARIA");
            command.Parameters.AddWithValue("@ID_AVARIA", idAvaria);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new ConfigAvariaViewModel
            {
                IdAvaria = Convert.ToInt32(row["ID_AVARIA"]),
                CdAvaria = Convert.ToInt32(row["CD_AVARIA"]),
                NmAvaria = row["NM_AVARIA"].ToString()
            };
        }

        public static List<ConfigAvariaViewModel> GetAllConfigAvarias()
        {
            var command = new SqlCommand("SELECT * FROM TB_CONFIG_AVARIA");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var configAvarias = new List<ConfigAvariaViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                configAvarias.Add(new ConfigAvariaViewModel
                {
                    IdAvaria = Convert.ToInt32(row["ID_AVARIA"]),
                    CdAvaria = Convert.ToInt32(row["CD_AVARIA"]),
                    NmAvaria = row["NM_AVARIA"].ToString()
                });
            }

            return configAvarias;
        }
    }

}
