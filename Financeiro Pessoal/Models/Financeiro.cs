using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Financeiro_Pessoal.Models.CustomValidations.Financeiro;

namespace Financeiro_Pessoal.Models
{
    public class Financeiro
    {
        [TipoFinanceiro]
        [Key] //Chave Primária
        public int ID { get; set; }

        [ForeignKey("CategoriaID")] //Chave estrangeira de Categorias
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }

        [ForeignKey("IndividuoID")] //Chave estrangeira de Indivíduos
        public int? IndividuoID { get; set; }
        public Individuo Individuo { get; set; }

        [MaxLength(60, ErrorMessage = "Descição não pode ter mais que 60 caracteres")]
        [MinLength(3, ErrorMessage = "Descrição não pode ter menos que 3 caracteres!")]
        [Required]
        public string Descricao { get; set; }

        public int SequenciaID { get; set; } //ID onde será guardado a chave de ligação entre todos os títulos de determinado lançamento

        public ICollection<Recibo> Recibos { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEmissao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        public bool Receita { get; set; }
        
        public bool Despesa { get; set; }

        public int Sequencia { get; set; }

        public double Valor { get; set; }

        [StringLength(120, ErrorMessage = "Observacoes não pode ter mais que 120 caracteres")]
        public string Observacoes { get; set; }
    }
}