namespace AgenciaVeiculos.Models
{
    public class PagamentoViewModel
    {
        public int IdTransacao { get; set; }
        public int IdAluguel { get; set; }
        public decimal VlPrestacao { get; set; }
        public DateTime DtUltimoPgto { get; set; }
        public string StPagamento { get; set; }
    }
}
