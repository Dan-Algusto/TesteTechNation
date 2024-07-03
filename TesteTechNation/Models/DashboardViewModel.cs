using TechNationTeste.Models;

namespace TesteTechNation.Models
{
    public class DashboardViewModel
    {
        public decimal TotalEmitido { get; set; }
        public decimal TotalInadimplente { get; set; }
        public decimal PercentualInadimplencia { get; set; }

        public GraficoViewModel Grafico { get; set; }

        public List<NotaFiscal> NotasFiscais { get; set; }
    }
}