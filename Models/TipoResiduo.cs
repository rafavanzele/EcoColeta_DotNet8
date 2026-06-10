using System.ComponentModel.DataAnnotations;

namespace EcoColeta.Api.Models
{
    public class TipoResiduo
    {
        [Key]
        public int IdTipoResiduo { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeTipo { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Descricao { get; set; }

        public bool Reciclavel { get; set; }
    }
}