namespace AgenciaVeiculos.Models
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string NrCpf { get; set; }
        public string NmNome { get; set; }
        public int NrIdade { get; set; }
        public string NmEndereco { get; set; }
        public DateTime DtCadastro { get; set; }
        public decimal VlVeiculo { get; set; }
        public string NmEmail { get; set; }
        public string NmTelefone { get; set; }
    }
}
