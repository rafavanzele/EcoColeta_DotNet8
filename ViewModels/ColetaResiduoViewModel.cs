using System.ComponentModel.DataAnnotations;

namespace EcoColeta.Api.ViewModels
{
    public class ColetaResiduoViewModel
    {
        public int IdColeta { get; set; }

        [Required(ErrorMessage = "A data da coleta é obrigatória.")]
        public DateTime DataColeta { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "O ponto de coleta é obrigatório.")]
        public int IdPontoColeta { get; set; }

        [Required(ErrorMessage = "O tipo de resíduo é obrigatório.")]
        public int IdTipoResiduo { get; set; }
    }
}