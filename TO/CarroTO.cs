using System.ComponentModel.DataAnnotations;

namespace TO
{
    public class CarroTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        [StringLength(90)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório.")]
        [Display(Name = "Ano de Fabricação")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        [StringLength(30)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório.")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "A Placa deve ter entre 7 e 8 caracteres.")]
        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [StringLength(50)]
        public string Cor { get; set; }
    }
}
