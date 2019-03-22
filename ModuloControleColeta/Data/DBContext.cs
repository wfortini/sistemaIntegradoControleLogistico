using Microsoft.EntityFrameworkCore;
using ModuleControleColeta.Models;
using ModuloControleColeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }

        public DbSet<Solicitacao> Solicitacao { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Frete> Frete { get; set; }
        public DbSet<Usuario> Usuario { get; set;  }
    }
}
