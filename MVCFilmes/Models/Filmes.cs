using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCFilmes.Models
{
    public class Filmes
    {

         public int ID { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        public  string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }


        [
            Required(ErrorMessage = "Esse campo é obrigatorio"),
            StringLength(10),
            RegularExpression(@"^[A-z]+[a-zA-Z]*$", ErrorMessage = "Dados inválidos")

        ]
        public string Genero { get; set; } = string.Empty;


        [Required(ErrorMessage = "Esse campo é obrigatorio")]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        [Range(0,5, ErrorMessage = "Somente valores de 0 a 5")]
        public  int? Pontos { get; set; }
    }
}
