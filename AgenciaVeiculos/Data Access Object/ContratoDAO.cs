using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class ContratoDAO
    {
        public static void InsertContrato(ContratoViewModel contrato)
        {
            var command = new SqlCommand("sp_InsertContrato");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_CLIENTE", contrato.IdCliente);
            command.Parameters.AddWithValue("@ID_FUNCIONARIO", contrato.IdFuncionario);
            command.Parameters.AddWithValue("@DT_CONTRATO", contrato.DtContrato);
            command.Parameters.AddWithValue("@ID_ALUGUEL", contrato.IdAluguel);
            command.Parameters.AddWithValue("@ST_CONTRATO", contrato.StContrato);
            command.Parameters.AddWithValue("@DT_CANCELAMENTO", (object)contrato.DtCancelamento ?? DBNull.Value);
            command.Parameters.AddWithValue("@DT_PERIODO_DIAS", contrato.DtPeriodoDias);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void UpdateContrato(ContratoViewModel contrato)
        {
            var command = new SqlCommand("sp_UpdateContrato");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_CONTRATO", contrato.IdContrato);
            command.Parameters.AddWithValue("@ID_CLIENTE", contrato.IdCliente);
            command.Parameters.AddWithValue("@ID_FUNCIONARIO", contrato.IdFuncionario);
            command.Parameters.AddWithValue("@DT_CONTRATO", contrato.DtContrato);
            command.Parameters.AddWithValue("@ID_ALUGUEL", contrato.IdAluguel);
            command.Parameters.AddWithValue("@ST_CONTRATO", contrato.StContrato);
            command.Parameters.AddWithValue("@DT_CANCELAMENTO", (object)contrato.DtCancelamento ?? DBNull.Value);
            command.Parameters.AddWithValue("@DT_PERIODO_DIAS", contrato.DtPeriodoDias);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void DeleteContrato(int idContrato)
        {
            var command = new SqlCommand("sp_DeleteContrato");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_CONTRATO", idContrato);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static ContratoViewModel GetContratoById(int idContrato)
        {
            var command = new SqlCommand("SELECT * FROM TB_CONTRATOS WHERE ID_CONTRATO = @ID_CONTRATO");
            command.Parameters.AddWithValue("@ID_CONTRATO", idContrato);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new ContratoViewModel
            {
                IdContrato = Convert.ToInt32(row["ID_CONTRATO"]),
                IdCliente = Convert.ToInt32(row["ID_CLIENTE"]),
                IdFuncionario = Convert.ToInt32(row["ID_FUNCIONARIO"]),
                DtContrato = Convert.ToDateTime(row["DT_CONTRATO"]),
                IdAluguel = Convert.ToInt32(row["ID_ALUGUEL"]),
                StContrato = row["ST_CONTRATO"].ToString(),
                DtCancelamento = row["DT_CANCELAMENTO"] == DBNull.Value ? null : Convert.ToDateTime(row["DT_CANCELAMENTO"]),
                DtPeriodoDias = Convert.ToInt32(row["DT_PERIODO_DIAS"])
            };
        }

        public static List<ContratoViewModel> GetAllContratos()
        {
            var command = new SqlCommand("SELECT * FROM TB_CONTRATOS");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var contratos = new List<ContratoViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                contratos.Add(new ContratoViewModel
                {
                    IdContrato = Convert.ToInt32(row["ID_CONTRATO"]),
                    IdCliente = Convert.ToInt32(row["ID_CLIENTE"]),
                    IdFuncionario = Convert.ToInt32(row["ID_FUNCIONARIO"]),
                    DtContrato = Convert.ToDateTime(row["DT_CONTRATO"]),
                    IdAluguel = Convert.ToInt32(row["ID_ALUGUEL"]),
                    StContrato = row["ST_CONTRATO"].ToString(),
                    DtCancelamento = row["DT_CANCELAMENTO"] == DBNull.Value ? null : Convert.ToDateTime(row["DT_CANCELAMENTO"]),
                    DtPeriodoDias = Convert.ToInt32(row["DT_PERIODO_DIAS"])
                });
            }

            return contratos;
        }
    }

}
