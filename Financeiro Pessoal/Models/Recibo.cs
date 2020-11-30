using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro_Pessoal.Models
{
    public class Recibo
    {
        [Key] //Chave Primária
        public int ID { get; set; }

        [Range(1, 999999)]
        [ForeignKey("FinanceiroID")] //Chave estrangeira de Financeiro
        public int FinanceiroID { get; set; }
        public Financeiro Financeiro { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DataBaixa { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Valor não pode ser 0!")]
        public double Valor { get; set; }
    }
}