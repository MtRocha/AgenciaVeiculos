namespace AgenciaVeiculos.Models
{
    public class FuncionarioViewModel
    {
        public int IdFuncionario { get; set; }
        public string NrCpf { get; set; }
        public string NmNome { get; set; }
        public string NmSexo { get; set; }
        public int NrIdade { get; set; }
        public string NmFuncao { get; set; }
        public string CdStatus { get; set; }
        public DateTime DtAdmissao { get; set; }
        public decimal VlVeiculo { get; set; }
        public int CdAvaria { get; set; }
    }
}
