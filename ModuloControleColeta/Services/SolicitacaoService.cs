using ModuleControleColeta.Models;
using ModuloControleColeta.Data;
using ModuloControleColeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly DBContext _context;

        public SolicitacaoService(DBContext context)
        {
            _context = context;
        }

        public Solicitacao AtualizarSolicitacao(Solicitacao solicitacao)
        {
            throw new NotImplementedException();
        }

        public Solicitacao BuscarSolicitacaoPorId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Solicitacao> BuscarSolicitacoesPorCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Solicitacao CriarSolicitacao(Solicitacao solicitacao)
        {
            _context.Solicitacao.Add(solicitacao);
            _context.SaveChanges();
            return solicitacao;
        }
    }
}
