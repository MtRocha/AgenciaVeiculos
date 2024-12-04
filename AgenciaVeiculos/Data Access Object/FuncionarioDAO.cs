using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class FuncionarioDAO
    {
        public static void InsertFuncionario(FuncionarioViewModel funcionario)
        {
            var command = new SqlCommand("sp_InsertFuncionario");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NR_CPF", funcionario.NrCpf);
            command.Parameters.AddWithValue("@NM_NOME", funcionario.NmNome);
            command.Parameters.AddWithValue("@NM_SEXO", funcionario.NmSexo);
            command.Parameters.AddWithValue("@NR_IDADE", funcionario.NrIdade);
            command.Parameters.AddWithValue("@NM_FUNCAO", funcionario.NmFuncao);
            command.Parameters.AddWithValue("@CD_STATUS", funcionario.CdStatus);
            command.Parameters.AddWithValue("@DT_ADMISSAO", funcionario.DtAdmissao);
            command.Parameters.AddWithValue("@VL_VEICULO", funcionario.VlVeiculo);
            command.Parameters.AddWithValue("@CD_AVARIA", funcionario.CdAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void UpdateFuncionario(FuncionarioViewModel funcionario)
        {
            var command = new SqlCommand("sp_UpdateFuncionario");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_FUNCIONARIO", funcionario.IdFuncionario);
            command.Parameters.AddWithValue("@NR_CPF", funcionario.NrCpf);
            command.Parameters.AddWithValue("@NM_NOME", funcionario.NmNome);
            command.Parameters.AddWithValue("@NM_SEXO", funcionario.NmSexo);
            command.Parameters.AddWithValue("@NR_IDADE", funcionario.NrIdade);
            command.Parameters.AddWithValue("@NM_FUNCAO", funcionario.NmFuncao);
            command.Parameters.AddWithValue("@CD_STATUS", funcionario.CdStatus);
            command.Parameters.AddWithValue("@DT_ADMISSAO", funcionario.DtAdmissao);
            command.Parameters.AddWithValue("@VL_VEICULO", funcionario.VlVeiculo);
            command.Parameters.AddWithValue("@CD_AVARIA", funcionario.CdAvaria);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static void DeleteFuncionario(int idFuncionario)
        {
            var command = new SqlCommand("sp_DeleteFuncionario");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_FUNCIONARIO", idFuncionario);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public static FuncionarioViewModel GetFuncionarioById(int idFuncionario)
        {
            var command = new SqlCommand("SELECT * FROM TB_FUNCIONARIOS WHERE ID_FUNCIONARIO = @ID_FUNCIONARIO");
            command.Parameters.AddWithValue("@ID_FUNCIONARIO", idFuncionario);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new FuncionarioViewModel
            {
                IdFuncionario = Convert.ToInt32(row["ID_FUNCIONARIO"]),
                NrCpf = row["NR_CPF"].ToString(),
                NmNome = row["NM_NOME"].ToString(),
                NmSexo = row["NM_SEXO"].ToString(),
                NrIdade = Convert.ToInt32(row["NR_IDADE"]),
                NmFuncao = row["NM_FUNCAO"].ToString(),
                CdStatus = row["CD_STATUS"].ToString(),
                DtAdmissao = Convert.ToDateTime(row["DT_ADMISSAO"]),
                VlVeiculo = Convert.ToDecimal(row["VL_VEICULO"]),
                CdAvaria = Convert.ToInt32(row["CD_AVARIA"])
            };
        }

        public static List<FuncionarioViewModel> GetAllFuncionarios()
        {
            var command = new SqlCommand("SELECT * FROM TB_FUNCIONARIOS");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var funcionarios = new List<FuncionarioViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                funcionarios.Add(new FuncionarioViewModel
                {
                    IdFuncionario = Convert.ToInt32(row["ID_FUNCIONARIO"]),
                    NrCpf = row["NR_CPF"].ToString(),
                    NmNome = row["NM_NOME"].ToString(),
                    NmSexo = row["NM_SEXO"].ToString(),
                    NrIdade = Convert.ToInt32(row["NR_IDADE"]),
                    NmFuncao = row["NM_FUNCAO"].ToString(),
                    CdStatus = row["CD_STATUS"].ToString(),
                    DtAdmissao = Convert.ToDateTime(row["DT_ADMISSAO"]),
                    VlVeiculo = Convert.ToDecimal(row["VL_VEICULO"]),
                    CdAvaria = Convert.ToInt32(row["CD_AVARIA"])
                });
            }

            return funcionarios;
        }
    }

}
