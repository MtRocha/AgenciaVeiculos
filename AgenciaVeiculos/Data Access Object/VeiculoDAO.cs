using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class VeiculoDAO
    {
        public static void InsertVeiculo(VeiculoViewModel veiculo)
        {
            var command = new SqlCommand("sp_InsertVeiculo");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NM_CHASSI", veiculo.NmChassi);
            command.Parameters.AddWithValue("@NM_PLACA", veiculo.NmPlaca);
            command.Parameters.AddWithValue("@NM_COR", veiculo.NmCor);
            command.Parameters.AddWithValue("@DT_ANO", veiculo.DtAno);
            command.Parameters.AddWithValue("@NM_MODELO", veiculo.NmModelo);
            command.Parameters.AddWithValue("@NM_MARCA", veiculo.NmMarca);
            command.Parameters.AddWithValue("@CD_STATUS", veiculo.CdStatus);
            command.Parameters.AddWithValue("@NM_CATEGORIA", veiculo.NmCategoria);
            command.Parameters.AddWithValue("@VL_VEICULO", veiculo.VlVeiculo);
            command.Parameters.AddWithValue("@CD_AVARIA", veiculo.CdAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void UpdateVeiculo(VeiculoViewModel veiculo)
        {
            var command = new SqlCommand("sp_UpdateVeiculo");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_VEICULO", veiculo.IdVeiculo);
            command.Parameters.AddWithValue("@NM_CHASSI", veiculo.NmChassi);
            command.Parameters.AddWithValue("@NM_PLACA", veiculo.NmPlaca);
            command.Parameters.AddWithValue("@NM_COR", veiculo.NmCor);
            command.Parameters.AddWithValue("@DT_ANO", veiculo.DtAno);
            command.Parameters.AddWithValue("@NM_MODELO", veiculo.NmModelo);
            command.Parameters.AddWithValue("@NM_MARCA", veiculo.NmMarca);
            command.Parameters.AddWithValue("@CD_STATUS", veiculo.CdStatus);
            command.Parameters.AddWithValue("@NM_CATEGORIA", veiculo.NmCategoria);
            command.Parameters.AddWithValue("@VL_VEICULO", veiculo.VlVeiculo);
            command.Parameters.AddWithValue("@CD_AVARIA", veiculo.CdAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void DeleteVeiculo(int idVeiculo)
        {
            var command = new SqlCommand("sp_DeleteVeiculo");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_VEICULO", idVeiculo);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static VeiculoViewModel GetVeiculoById(int idVeiculo)
        {
            var command = new SqlCommand("SELECT * FROM TB_VEICULOS WHERE ID_VEICULO = @ID_VEICULO");
            command.Parameters.AddWithValue("@ID_VEICULO", idVeiculo);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new VeiculoViewModel
            {
                IdVeiculo = Convert.ToInt32(row["ID_VEICULO"]),
                NmChassi = row["NM_CHASSI"].ToString(),
                NmPlaca = row["NM_PLACA"].ToString(),
                NmCor = row["NM_COR"].ToString(),
                DtAno = row["DT_ANO"].ToString(),
                NmModelo = row["NM_MODELO"].ToString(),
                NmMarca = row["NM_MARCA"].ToString(),
                CdStatus = row["CD_STATUS"].ToString(),
                NmCategoria = row["NM_CATEGORIA"].ToString(),
                VlVeiculo = Convert.ToDecimal(row["VL_VEICULO"]),
                CdAvaria = Convert.ToInt32(row["CD_AVARIA"])
            };
        }

        public static List<VeiculoViewModel> GetAllVeiculos()
        {
            var command = new SqlCommand("SELECT * FROM TB_VEICULOS");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var veiculos = new List<VeiculoViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                veiculos.Add(new VeiculoViewModel
                {
                    IdVeiculo = Convert.ToInt32(row["ID_VEICULO"]),
                    NmChassi = row["NM_CHASSI"].ToString(),
                    NmPlaca = row["NM_PLACA"].ToString(),
                    NmCor = row["NM_COR"].ToString(),
                    DtAno = row["DT_ANO"].ToString(),
                    NmModelo = row["NM_MODELO"].ToString(),
                    NmMarca = row["NM_MARCA"].ToString(),
                    CdStatus = row["CD_STATUS"].ToString(),
                    NmCategoria = row["NM_CATEGORIA"].ToString(),
                    VlVeiculo = Convert.ToDecimal(row["VL_VEICULO"]),
                    CdAvaria = Convert.ToInt32(row["CD_AVARIA"])
                });
            }

            return veiculos;
        }
    }

}
