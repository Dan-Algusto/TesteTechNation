using System.ComponentModel.DataAnnotations;

namespace TechNationTeste.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Pagador")]
        public string NomePagador { get; set; }

        [Display(Name = "Número da Nota")]
        public string NumeroIdentificacao { get; set; }

        [Display(Name = "Data de Emissão")]
        [DataType(DataType.Date)]
        public DateTime DataEmissao { get; set; }

        [Display(Name = "Data de Cobrança")]
        [DataType(DataType.Date)]
        public DateTime? DataCobranca { get; set; } // Permite nulo

        [Display(Name = "Data de Pagamento")]
        [DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; } // Permite nulo

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Display(Name = "Documento da Nota Fiscal")]
        public string DocumentoNotaFiscal { get; set; }

        [Display(Name = "Documento do Boleto")]
        public string DocumentoBoleto { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
