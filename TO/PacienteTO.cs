using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class PacienteTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeMae { get; set; }
        public DateTime? Nascimento { get; set; }
        public SexoEnum Sexo { get; set; }


    }

    public enum SexoEnum
    {
        Masculino = 1,
        Feminino = 2,
        NaoInformado = 99
    }
}
