using System.ComponentModel.DataAnnotations;

namespace EcoColeta.Api.Models
{
    public class PontoColeta
    {
        [Key]
        public int IdPontoColeta { get; set; }

        [Required(ErrorMessage = "O nome do ponto de coleta é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do ponto de coleta deve ter no máximo 100 caracteres.")]
        public string NomePonto { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização do ponto de coleta é obrigatória.")]
        [MaxLength(200, ErrorMessage = "A localização deve ter no máximo 200 caracteres.")]
        public string Localizacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
        [Range(1, double.MaxValue, ErrorMessage = "A capacidade máxima deve ser maior que zero.")]
        public double CapacidadeMaxima { get; set; }

        [Required(ErrorMessage = "O status do ponto de coleta é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O status do ponto de coleta deve ter no máximo 50 caracteres.")]
        public string StatusPonto { get; set; } = string.Empty;
    }
}