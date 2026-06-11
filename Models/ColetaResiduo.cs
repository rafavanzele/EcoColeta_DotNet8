using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoColeta.Api.Models
{
    public class ColetaResiduo
    {
        [Key]
        public int IdColeta { get; set; }

        [Required(ErrorMessage = "A data da coleta é obrigatória.")]
        public DateTime DataColeta { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "O ponto de coleta é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Informe um ponto de coleta válido.")]
        public int IdPontoColeta { get; set; }

        [ForeignKey("IdPontoColeta")]
        public PontoColeta? PontoColeta { get; set; }

        [Required(ErrorMessage = "O tipo de resíduo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Informe um tipo de resíduo válido.")]
        public int IdTipoResiduo { get; set; }

        [ForeignKey("IdTipoResiduo")]
        public TipoResiduo? TipoResiduo { get; set; }
    }
}