using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoColeta.Api.Models
{
    public class ColetaResiduo
    {
        [Key]
        public int IdColeta { get; set; }

        [Required]
        public DateTime DataColeta { get; set; }

        [Required]
        public double Quantidade { get; set; }

        [Required]
        public int IdPontoColeta { get; set; }

        [ForeignKey("IdPontoColeta")]
        public PontoColeta? PontoColeta { get; set; }

        [Required]
        public int IdTipoResiduo { get; set; }

        [ForeignKey("IdTipoResiduo")]
        public TipoResiduo? TipoResiduo { get; set; }
    }
}