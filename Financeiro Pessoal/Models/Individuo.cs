using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro_Pessoal.Models 
{
    public class Individuo
    {
        [Key] //Chave Primária        
        public int ID { get; set; }

        [StringLength(40, MinimumLength = 3, ErrorMessage = "Nome deve ter pelo menos 3 caracteres, mas não mais que 40 caracteres!")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [StringLength(16, MinimumLength = 8, ErrorMessage = "Telefone deve ter pelo menos 8 caracteres, mas não mais que 16 caracteres!")]
        public string Telefone { get; set; }

        [StringLength(120, ErrorMessage = "Observacoes não pode ter mais que 120 caracteres")]
        public string Observacoes { get; set; }
    }
}