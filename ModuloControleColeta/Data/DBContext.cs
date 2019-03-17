using Microsoft.EntityFrameworkCore;
using ModuleControleColeta.Models;
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
    }
}
