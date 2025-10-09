using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioBase
    {
        public ExemploMaterializacaoEntities Contexto 
        {
            get
            {
                return _Contexto;
            }
            set
            {
                _Contexto = value;
            }
        }
        private ExemploMaterializacaoEntities _Contexto;

        public RepositorioBase() 
        {
            _Contexto = new ExemploMaterializacaoEntities();
        }
    }
}
