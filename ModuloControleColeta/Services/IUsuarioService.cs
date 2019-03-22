using ModuloControleColeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Services
{
    public interface IUsuarioService
    {
        Usuario Registrar(Usuario usuario, string password);
        Usuario Autenticar(string login, string password);
    }
}
