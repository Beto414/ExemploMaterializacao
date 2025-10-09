using System;
using System.ComponentModel.DataAnnotations;

namespace TO
{
    public class PacienteTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(250, ErrorMessage = "O Nome não pode exceder 250 caracteres.")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Nome da Mãe é obrigatório.")]
        [StringLength(250, ErrorMessage = "O Nome da Mãe não pode exceder 250 caracteres.")]
        [Display(Name = "Nome da Mãe")]
        public string NomeMae { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Por favor, insira uma data válida.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime? Nascimento { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        public SexoEnum Sexo { get; set; }
    }

    public enum SexoEnum
    {
        Masculino = 1,
        Feminino = 2,
        NaoInformado = 99
    }
}
