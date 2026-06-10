using System.ComponentModel.DataAnnotations;

namespace EcoColeta.Api.ViewModels
{
    public class PontoColetaViewModel
    {
        public int IdPontoColeta { get; set; }

        [Required(ErrorMessage = "O nome do ponto de coleta é obrigatório.")]
        [MaxLength(100)]
        public string NomePonto { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização é obrigatória.")]
        [MaxLength(200)]
        public string Localizacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
        public double CapacidadeMaxima { get; set; }

        [Required(ErrorMessage = "O status do ponto é obrigatório.")]
        [MaxLength(50)]
        public string StatusPonto { get; set; } = string.Empty;
    }
}