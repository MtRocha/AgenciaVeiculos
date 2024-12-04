namespace AgenciaVeiculos.Models
{
    public class ContratoViewModel
    {
        public int IdContrato { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public DateTime DtContrato { get; set; }
        public int IdAluguel { get; set; }
        public string StContrato { get; set; }
        public DateTime? DtCancelamento { get; set; }
        public int DtPeriodoDias { get; set; }
    }
}
