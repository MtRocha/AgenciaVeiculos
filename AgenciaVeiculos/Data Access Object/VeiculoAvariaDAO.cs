using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class VeiculoAvariaDAO
    {
        public static void InsertVeiculoAvaria(VeiculoAvariaViewModel veiculoAvaria)
        {
            var command = new SqlCommand("sp_InsertVeiculoAvaria");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CD_AVARIA", veiculoAvaria.CdAvaria);
            command.Parameters.AddWithValue("@ID_VEICULO", veiculoAvaria.IdVeiculo);
            command.Parameters.AddWithValue("@DT_AVARIA", veiculoAvaria.DtAvaria);
            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void UpdateVeiculoAvaria(VeiculoAvariaViewModel veiculoAvaria)
        {
            var command = new SqlCommand("sp_UpdateVeiculoAvaria");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", veiculoAvaria.Id);
            command.Parameters.AddWithValue("@CD_AVARIA", veiculoAvaria.CdAvaria);
            command.Parameters.AddWithValue("@ID_VEICULO", veiculoAvaria.IdVeiculo);
            command.Parameters.AddWithValue("@DT_AVARIA", veiculoAvaria.DtAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void DeleteVeiculoAvaria(int id)
        {
            var command = new SqlCommand("sp_DeleteVeiculoAvaria");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static VeiculoAvariaViewModel GetVeiculoAvariaById(int id)
        {
            var command = new SqlCommand("SELECT * FROM TB_VEICULOS_AVARIAS WHERE ID = @ID");
            command.Parameters.AddWithValue("@ID", id);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new VeiculoAvariaViewModel
            {
                Id = Convert.ToInt32(row["ID"]),
                CdAvaria = Convert.ToInt32(row["CD_AVARIA"]),
                IdVeiculo = Convert.ToInt32(row["ID_VEICULO"]),
                DtAvaria = Convert.ToDateTime(row["DT_AVARIA"])
            };
        }

        public static List<VeiculoAvariaViewModel> GetAllVeiculoAvarias()
        {
            var command = new SqlCommand("SELECT * FROM TB_VEICULOS_AVARIAS");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var veiculoAvarias = new List<VeiculoAvariaViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                veiculoAvarias.Add(new VeiculoAvariaViewModel
                {
                    Id = Convert.ToInt32(row["ID"]),
                    CdAvaria = Convert.ToInt32(row["CD_AVARIA"]),
                    IdVeiculo = Convert.ToInt32(row["ID_VEICULO"]),
                    DtAvaria = Convert.ToDateTime(row["DT_AVARIA"])
                });
            }

            return veiculoAvarias;
        }
    }

}
