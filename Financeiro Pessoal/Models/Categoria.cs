using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro_Pessoal.Models
{
    public class Categoria 
    {
        [Key] //Chave Primária
        public int ID { get; set; }

        [MaxLength(20, ErrorMessage = "Descrição não pode ter mais que 20 caracteres")]
        [MinLength(3, ErrorMessage = "Descrição deve ter pelo menos 3 caracteres!")]
        public string Descricao { get; set; }

        public bool Receita { get; set; }

        public bool Despesa { get; set; }

        public bool Status { get; set; }
    }
}