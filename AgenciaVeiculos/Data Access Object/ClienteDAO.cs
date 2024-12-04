using AgenciaVeiculos.Models;
using System.Data.SqlClient;
using System.Data;

namespace AgenciaVeiculos.Data_Access_Object
{
    public class ClienteDAO
    {
        public void InsertCliente(ClienteViewModel cliente)
        {
            var command = new SqlCommand("sp_InsertCliente");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NR_CPF", cliente.NrCpf);
            command.Parameters.AddWithValue("@NM_NOME", cliente.NmNome);
            command.Parameters.AddWithValue("@NR_IDADE", cliente.NrIdade);
            command.Parameters.AddWithValue("@NM_ENDERECO", cliente.NmEndereco);
            command.Parameters.AddWithValue("@DT_CADASTRO", cliente.DtCadastro);
            command.Parameters.AddWithValue("@VL_VEICULO", cliente.VlVeiculo);
            command.Parameters.AddWithValue("@NM_EMAIL", cliente.NmEmail);
            command.Parameters.AddWithValue("@NM_TELEFONE", cliente.NmTelefone);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public void UpdateCliente(ClienteViewModel cliente)
        {
            var command = new SqlCommand("sp_UpdateCliente");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_CLIENTE", cliente.IdCliente);
            command.Parameters.AddWithValue("@NR_CPF", cliente.NrCpf);
            command.Parameters.AddWithValue("@NM_NOME", cliente.NmNome);
            command.Parameters.AddWithValue("@NR_IDADE", cliente.NrIdade);
            command.Parameters.AddWithValue("@NM_ENDERECO", cliente.NmEndereco);
            command.Parameters.AddWithValue("@DT_CADASTRO", cliente.DtCadastro);
            command.Parameters.AddWithValue("@VL_VEICULO", cliente.VlVeiculo);
            command.Parameters.AddWithValue("@NM_EMAIL", cliente.NmEmail);
            command.Parameters.AddWithValue("@NM_TELEFONE", cliente.NmTelefone);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public void DeleteCliente(int idCliente)
        {
            var command = new SqlCommand("sp_DeleteCliente");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID_CLIENTE", idCliente);

            DB_AGENCIA.ExecuteNonQuery(command);
        }

        public ClienteViewModel GetClienteById(int idCliente)
        {
            var command = new SqlCommand("SELECT * FROM TB_CLIENTES WHERE ID_CLIENTE = @ID_CLIENTE");
            command.Parameters.AddWithValue("@ID_CLIENTE", idCliente);

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            if (dataTable.Rows.Count == 0)
                return null;

            var row = dataTable.Rows[0];
            return new ClienteViewModel
            {
                IdCliente = Convert.ToInt32(row["ID_CLIENTE"]),
                NrCpf = row["NR_CPF"].ToString(),
                NmNome = row["NM_NOME"].ToString(),
                NrIdade = Convert.ToInt32(row["NR_IDADE"]),
                NmEndereco = row["NM_ENDERECO"].ToString(),
                DtCadastro = Convert.ToDateTime(row["DT_CADASTRO"]),
                VlVeiculo = Convert.ToDecimal(row["VL_VEICULO"]),
                NmEmail = row["NM_EMAIL"].ToString(),
                NmTelefone = row["NM_TELEFONE"].ToString()
            };
        }

        public List<ClienteViewModel> GetAllClientes()
        {
            var command = new SqlCommand("SELECT * FROM TB_CLIENTES");

            var dataTable = DB_AGENCIA.ExecuteQuery(command);

            var clientes = new List<ClienteViewModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                clientes.Add(new ClienteViewModel
                {
                    IdCliente = Convert.ToInt32(row["ID_CLIENTE"]),
                    NrCpf = row["NR_CPF"].ToString(),
                    NmNome = row["NM_NOME"].ToString(),
                    NrIdade = Convert.ToInt32(row["NR_IDADE"]),
                    NmEndereco = row["NM_ENDERECO"].ToString(),
                    DtCadastro = Convert.ToDateTime(row["DT_CADASTRO"]),
                    VlVeiculo = Convert.ToDecimal(row["VL_VEICULO"]),
                    NmEmail = row["NM_EMAIL"].ToString(),
                    NmTelefone = row["NM_TELEFONE"].ToString()
                });
            }

            return clientes;
        }
    }

}
