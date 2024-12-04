namespace AgenciaVeiculos.Models
{
    public class VeiculoViewModel
    {
        public int IdVeiculo { get; set; }
        public string NmChassi { get; set; }
        public string NmPlaca { get; set; }
        public string NmCor { get; set; }
        public string DtAno { get; set; }
        public string NmModelo { get; set; }
        public string NmMarca { get; set; }
        public string CdStatus { get; set; }
        public string NmCategoria { get; set; }
        public decimal VlVeiculo { get; set; }
        public int CdAvaria { get; set; }
    }
}
