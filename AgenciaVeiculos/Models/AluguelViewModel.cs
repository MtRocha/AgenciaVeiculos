namespace AgenciaVeiculos.Models
{
    public class AluguelViewModel
    {
        public int IdAluguel { get; set; }
        public int IdVeiculo { get; set; }
        public int IdContrato { get; set; }
        public DateTime DtAluguel { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public string StAluguel { get; set; }
        public string TpPagamento { get; set; }
        public decimal VlAlugel { get; set; }
    }
}
