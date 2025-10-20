using Dados;
using Repositorio;
using System;
using System.Security.Cryptography;
using System.Text;
using TO;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioRepositorio _repositorio;

        public UsuarioNegocio()
        {
            _repositorio = new UsuarioRepositorio();
        }

        public void Registrar(UsuarioTO usuarioTO)
        {
            if (_repositorio.NomeUsuarioExiste(usuarioTO.NomeUsuario))
            {
                throw new Exception("Este nome de usuário já está em uso.");
            }
            if (_repositorio.EmailExiste(usuarioTO.Email))
            {
                throw new Exception("Este endereço de e-mail já está cadastrado.");
            }

            string senhaHash = GerarHashSenha(usuarioTO.Senha);

            var usuarioEntity = new Usuario
            {
                Nome = usuarioTO.Nome,
                NomeUsuario = usuarioTO.NomeUsuario,
                Email = usuarioTO.Email,
                SenhaHash = senhaHash
            };

            _repositorio.Adicionar(usuarioEntity);
        }

        public UsuarioTO Login(string nomeUsuario, string senha)
        {
            var usuarioEntity = _repositorio.GetPorNomeUsuario(nomeUsuario);

            if (usuarioEntity != null && VerificarSenha(senha, usuarioEntity.SenhaHash))
            {
                return new UsuarioTO
                {
                    Id = usuarioEntity.Id,
                    Nome = usuarioEntity.Nome,
                    NomeUsuario = usuarioEntity.NomeUsuario,
                    Email = usuarioEntity.Email
                };
            }

            return null;
        }

        // --- MÉTODOS DE CRIPTOGRAFIA ---

        private string GerarHashSenha(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerificarSenha(string senhaFornecida, string senhaHashArmazenada)
        {
            string hashDaSenhaFornecida = GerarHashSenha(senhaFornecida);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashDaSenhaFornecida, senhaHashArmazenada) == 0;
        }

        public UsuarioTO GetPerfil(string nomeUsuario)
        {
            var usuarioEntity = _repositorio.GetPorNomeUsuario(nomeUsuario);
            if (usuarioEntity == null) return null;

            return new UsuarioTO
            {
                Id = usuarioEntity.Id,
                Nome = usuarioEntity.Nome,
                NomeUsuario = usuarioEntity.NomeUsuario,
                Email = usuarioEntity.Email
            };
        }

        public void AtualizarPerfil(UsuarioTO usuarioTO)
        {
            var usuarioEntity = _repositorio.GetPorId(usuarioTO.Id);
            if (usuarioEntity == null) throw new Exception("Usuário não encontrado.");

            usuarioEntity.Nome = usuarioTO.Nome;
            usuarioEntity.Email = usuarioTO.Email;

            if (!string.IsNullOrEmpty(usuarioTO.Senha))
            {
                usuarioEntity.SenhaHash = GerarHashSenha(usuarioTO.Senha);
            }

            _repositorio.Atualizar(usuarioEntity);
        }
    }
}