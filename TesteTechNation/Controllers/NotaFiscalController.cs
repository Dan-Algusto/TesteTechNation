using Microsoft.AspNetCore.Mvc;
using TechNationTeste.Models;
using TesteTechNation.Models;

namespace TesteTechNation.Controllers
{
    public class NotaFiscalController : Controller
    {
        private readonly Contexto _context;

        public NotaFiscalController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index(int? mesEmissao, int? mesCobranca, int? mesPagamento, string status, string periodo)
        {
            var notasFiscais = _context.notasFiscais.AsQueryable();
            var dadosGrafico = CalcularDadosGrafico(notasFiscais.ToList(), periodo);

            if (mesEmissao.HasValue)
            {
                notasFiscais = notasFiscais.Where(nf => nf.DataEmissao.Month == mesEmissao.Value);
            }

            if (mesCobranca.HasValue)
            {
                notasFiscais = notasFiscais.Where(nf => nf.DataCobranca.Value.Month == mesCobranca.Value);
            }

            if (mesPagamento.HasValue)
            {
                notasFiscais = notasFiscais.Where(nf => nf.DataPagamento.Value.Month == mesPagamento.Value);
            }

            if (!string.IsNullOrEmpty(status))
            {
                notasFiscais = notasFiscais.Where(nf => nf.Status == status);
            }

            var viewModel = new DashboardViewModel
            {
                TotalEmitido = notasFiscais.Sum(nf => nf.Valor),
                TotalInadimplente = notasFiscais.Where(nf => nf.Status == "Pagamento em atraso").Sum(nf => nf.Valor),
                PercentualInadimplencia = notasFiscais.Any() ? (notasFiscais.Where(nf => nf.Status == "Pagamento em atraso").Sum(nf => nf.Valor) / notasFiscais.Sum(nf => nf.Valor)) * 100 : 0,
                Grafico = CalcularDadosGrafico(notasFiscais.ToList(), periodo),
                NotasFiscais = notasFiscais.ToList()
            };

            // Passar os valores dos filtros para a ViewData
            ViewData["mesEmissao"] = mesEmissao;
            ViewData["mesCobranca"] = mesCobranca;
            ViewData["mesPagamento"] = mesPagamento;
            ViewData["status"] = status;
            ViewData["periodo"] = periodo;

            return View(viewModel);
        }

        private GraficoViewModel CalcularDadosGrafico(List<NotaFiscal> notasFiscais, string periodo)
        {
            var dadosAgrupados = periodo switch
            {
                "trimestre" => notasFiscais
                    .GroupBy(nf => (nf.DataEmissao.Month - 1) / 3 + 1)
                    .Select(g => new
                    {
                        Periodo = $"Trimestre {g.Key}",
                        Inadimplencia = g.Where(nf => nf.Status == "Pagamento em atraso").Sum(nf => nf.Valor),
                        Receita = g.Where(nf => nf.Status == "Pagamento realizado").Sum(nf => nf.Valor)
                    }),
                "ano" => notasFiscais
                    .GroupBy(nf => nf.DataEmissao.Year)
                    .Select(g => new
                    {
                        Periodo = g.Key.ToString(),
                        Inadimplencia = g.Where(nf => nf.Status == "Pagamento em atraso").Sum(nf => nf.Valor),
                        Receita = g.Where(nf => nf.Status == "Pagamento realizado").Sum(nf => nf.Valor)
                    }),
                _ => notasFiscais // "mes" é o padrão
                    .GroupBy(nf => nf.DataEmissao.Month)
                    .Select(g => new
                    {
                        Periodo = new DateTime(2023, g.Key, 1).ToString("MMM"),
                        Inadimplencia = g.Where(nf => nf.Status == "Pagamento em atraso").Sum(nf => nf.Valor),
                        Receita = g.Where(nf => nf.Status == "Pagamento realizado").Sum(nf => nf.Valor)
                    })
            };

            return new GraficoViewModel
            {
                Periodo = dadosAgrupados.Select(x => x.Periodo).ToList(),
                Inadimplencia = dadosAgrupados.Select(x => x.Inadimplencia).ToList(),
                Receita = dadosAgrupados.Select(x => x.Receita).ToList()
            };
        }

        public IActionResult Sobre()
        {
            return View();
        }

    }
}
