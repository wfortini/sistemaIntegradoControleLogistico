using ModuleControleColeta.Models;
using ModuloControleColeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Services
{
    public interface ISolicitacaoService
    {
        Solicitacao CriarSolicitacao(Solicitacao solicitacao);
        List<Solicitacao> BuscarSolicitacoesPorCliente(Cliente cliente);
        Solicitacao BuscarSolicitacaoPorId(string id);
        Solicitacao AtualizarSolicitacao(Solicitacao solicitacao);


    }
}
