using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class PagamentoDAO
    {
        public static void InsertPagamento(PagamentoViewModel pagamento)
        {
            var command = new SqlCommand("sp_InsertPagamento");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_ALUGUEL", pagamento.IdAluguel);
            command.Parameters.AddWithValue("@VL_PRESTACAO", pagamento.VlPrestacao);
            command.Parameters.AddWithValue("@DT_ULTIMO_PGTO", pagamento.DtUltimoPgto);
            command.Parameters.AddWithValue("@ST_PAGAMENTO", pagamento.StPagamento);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void UpdatePagamento(PagamentoViewModel pagamento)
        {
            var command = new SqlCommand("sp_UpdatePagamento");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_TRANSACAO", pagamento.IdTransacao);
            command.Parameters.AddWithValue("@ID_ALUGUEL", pagamento.IdAluguel);
            command.Parameters.AddWithValue("@VL_PRESTACAO", pagamento.VlPrestacao);
            command.Parameters.AddWithValue("@DT_ULTIMO_PGTO", pagamento.DtUltimoPgto);
            command.Parameters.AddWithValue("@ST_PAGAMENTO", pagamento.StPagamento);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void DeletePagamento(int idTransacao)
        {
            var command = new SqlCommand("sp_DeletePagamento");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_TRANSACAO", idTransacao);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static PagamentoViewModel GetPagamentoById(int idTransacao)
        {
            var command = new SqlCommand("SELECT * FROM TB_PAGAMENTOS WHERE ID_TRANSACAO = @ID_TRANSACAO");
            command.Parameters.AddWithValue("@ID_TRANSACAO", idTransacao);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new PagamentoViewModel
            {
                IdTransacao = Convert.ToInt32(row["ID_TRANSACAO"]),
                IdAluguel = Convert.ToInt32(row["ID_ALUGUEL"]),
                VlPrestacao = Convert.ToDecimal(row["VL_PRESTACAO"]),
                DtUltimoPgto = Convert.ToDateTime(row["DT_ULTIMO_PGTO"]),
                StPagamento = row["ST_PAGAMENTO"].ToString()
            };
        }

        public static List<PagamentoViewModel> GetAllPagamentos()
        {
            var command = new SqlCommand("SELECT * FROM TB_PAGAMENTOS");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var pagamentos = new List<PagamentoViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                pagamentos.Add(new PagamentoViewModel
                {
                    IdTransacao = Convert.ToInt32(row["ID_TRANSACAO"]),
                    IdAluguel = Convert.ToInt32(row["ID_ALUGUEL"]),
                    VlPrestacao = Convert.ToDecimal(row["VL_PRESTACAO"]),
                    DtUltimoPgto = Convert.ToDateTime(row["DT_ULTIMO_PGTO"]),
                    StPagamento = row["ST_PAGAMENTO"].ToString()
                });
            }

            return pagamentos;
        }
    }

}
