using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModuloControleColeta.Data;
using ModuloControleColeta.Models;

namespace ModuloControleColeta.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DBContext _context;

        public UsuarioService(DBContext context)
        {
            _context = context;
        }

        public Usuario Autenticar(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;

            var usuario = _context.Usuario.SingleOrDefault(x => x.Login == login);

            if (usuario == null)
                return null;

            if (!VerificarPasswordHash(password, usuario.PasswordHash, usuario.PasswordSalt))
                return null;
            
            return usuario;
        }

        public Usuario Registrar(Usuario usuario, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password é obrigatòrio.");

            if (_context.Usuario.Any(x => x.Login == usuario.Login))
                throw new ArgumentException("Login \"" + usuario.Login + "\" já em uso.");

            byte[] passwordHash, passwordSalt;
            criarPasswordHash(password, out passwordHash, out passwordSalt);

            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }



        private static void criarPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Valor não pode ser vazio ou conter espaço em branco.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerificarPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Valor não pode ser vazio ou conter espaço em branco.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Tamanho inválido (esperado 64 bytes).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Tamanho inválido (esperado 128 bytes).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
