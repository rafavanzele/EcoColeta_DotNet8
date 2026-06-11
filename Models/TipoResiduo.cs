using System.ComponentModel.DataAnnotations;

namespace EcoColeta.Api.Models
{
    public class TipoResiduo
    {
        [Key]
        public int IdTipoResiduo { get; set; }

        [Required(ErrorMessage = "O nome do tipo de resíduo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do tipo de resíduo deve ter no máximo 100 caracteres.")]
        public string NomeTipo { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        public bool Reciclavel { get; set; }
    }
}