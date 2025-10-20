using Dados;
using System.Linq;

namespace Repositorio
{
    public class UsuarioRepositorio : RepositorioBase
    {
        public void Adicionar(Usuario usuario)
        {
            this.Contexto.Usuarios.Add(usuario);
            this.Contexto.SaveChanges();
        }

        public Usuario GetPorNomeUsuario(string nomeUsuario)
        {
            return this.Contexto.Usuarios
                .FirstOrDefault(u => u.NomeUsuario.ToUpper() == nomeUsuario.ToUpper());
        }

        public bool NomeUsuarioExiste(string nomeUsuario)
        {
            return this.Contexto.Usuarios.Any(u => u.NomeUsuario.ToUpper() == nomeUsuario.ToUpper());
        }

        public bool EmailExiste(string email)
        {
            return this.Contexto.Usuarios.Any(u => u.Email.ToUpper() == email.ToUpper());
        }
        public Usuario GetPorId(int id)
        {
            return this.Contexto.Usuarios.Find(id);
        }

        public void Atualizar(Usuario usuario)
        {
            this.Contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            this.Contexto.SaveChanges();
        }

    }
}