using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro_Pessoal.Models
{
    public class Categoria 
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre {1} e {2} caracteres!")]
        public string Descricao { get; set; }

        [Range(1, 2, ErrorMessage = "O Tipo de Categoria precisa ser informado!")]
        public int Tipo { get; set; }

        public bool Status { get; set; }
    }
}