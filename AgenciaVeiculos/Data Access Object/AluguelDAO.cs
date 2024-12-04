using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class AluguelDAO
    {

        public void InsertAluguel(AluguelViewModel aluguel)
        {
            var command = new SqlCommand("sp_InsertAluguel");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_VEICULO", aluguel.IdVeiculo);
            command.Parameters.AddWithValue("@ID_CONTRATO", aluguel.IdContrato);
            command.Parameters.AddWithValue("@DT_ALUGUEL", aluguel.DtAluguel);
            command.Parameters.AddWithValue("@DT_INICIO", aluguel.DtInicio);
            command.Parameters.AddWithValue("@DT_FIM", aluguel.DtFim);
            command.Parameters.AddWithValue("@ST_ALUGUEL", aluguel.StAluguel);
            command.Parameters.AddWithValue("@TP_PAGAMENTO", aluguel.TpPagamento);
            command.Parameters.AddWithValue("@VL_ALUGEL", aluguel.VlAlugel);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public void UpdateAluguel(AluguelViewModel aluguel)
        {
            var command = new SqlCommand("sp_UpdateAluguel");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_ALUGUEL", aluguel.IdAluguel);
            command.Parameters.AddWithValue("@ID_VEICULO", aluguel.IdVeiculo);
            command.Parameters.AddWithValue("@ID_CONTRATO", aluguel.IdContrato);
            command.Parameters.AddWithValue("@DT_ALUGUEL", aluguel.DtAluguel);
            command.Parameters.AddWithValue("@DT_INICIO", aluguel.DtInicio);
            command.Parameters.AddWithValue("@DT_FIM", aluguel.DtFim);
            command.Parameters.AddWithValue("@ST_ALUGUEL", aluguel.StAluguel);
            command.Parameters.AddWithValue("@TP_PAGAMENTO", aluguel.TpPagamento);
            command.Parameters.AddWithValue("@VL_ALUGEL", aluguel.VlAlugel);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public void DeleteAluguel(int idAluguel)
        {
            var command = new SqlCommand("sp_DeleteAluguel");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_ALUGUEL", idAluguel);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public AluguelViewModel GetAluguelById(int idAluguel)
        {
            var command = new SqlCommand("SELECT * FROM TB_ALUGUEL WHERE ID_ALUGUEL = @ID_ALUGUEL");
            command.Parameters.AddWithValue("@ID_ALUGUEL", idAluguel);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new AluguelViewModel
            {
                IdAluguel = Convert.ToInt32(row["ID_ALUGUEL"]),
                IdVeiculo = Convert.ToInt32(row["ID_VEICULO"]),
                IdContrato = Convert.ToInt32(row["ID_CONTRATO"]),
                DtAluguel = Convert.ToDateTime(row["DT_ALUGUEL"]),
                DtInicio = Convert.ToDateTime(row["DT_INICIO"]),
                DtFim = Convert.ToDateTime(row["DT_FIM"]),
                StAluguel = row["ST_ALUGUEL"].ToString(),
                TpPagamento = row["TP_PAGAMENTO"].ToString(),
                VlAlugel = Convert.ToDecimal(row["VL_ALUGEL"])
            };
        }

        public List<AluguelViewModel> GetAllAlugueis()
        {
            var command = new SqlCommand("SELECT * FROM TB_ALUGUEL");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var alugueis = new List<AluguelViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                alugueis.Add(new AluguelViewModel
                {
                    IdAluguel = Convert.ToInt32(row["ID_ALUGUEL"]),
                    IdVeiculo = Convert.ToInt32(row["ID_VEICULO"]),
                    IdContrato = Convert.ToInt32(row["ID_CONTRATO"]),
                    DtAluguel = Convert.ToDateTime(row["DT_ALUGUEL"]),
                    DtInicio = Convert.ToDateTime(row["DT_INICIO"]),
                    DtFim = Convert.ToDateTime(row["DT_FIM"]),
                    StAluguel = row["ST_ALUGUEL"].ToString(),
                    TpPagamento = row["TP_PAGAMENTO"].ToString(),
                    VlAlugel = Convert.ToDecimal(row["VL_ALUGEL"])
                });
            }

            return alugueis;
        }
    }

}
