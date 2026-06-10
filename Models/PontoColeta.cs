using System.ComponentModel.DataAnnotations;

namespace EcoColeta.Api.Models
{
    public class PontoColeta
    {
        [Key]
        public int IdPontoColeta { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomePonto { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Localizacao { get; set; } = string.Empty;

        [Required]
        public double CapacidadeMaxima { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusPonto { get; set; } = string.Empty;
    }
}