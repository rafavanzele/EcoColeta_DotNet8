using System.ComponentModel.DataAnnotations;

namespace EcoColeta.Api.ViewModels
{
    public class TipoResiduoViewModel
    {
        public int IdTipoResiduo { get; set; }

        [Required(ErrorMessage = "O nome do tipo de resíduo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string NomeTipo { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Descricao { get; set; }

        public bool Reciclavel { get; set; }
    }
}