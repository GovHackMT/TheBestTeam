using ESaudeApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESaudeApi.Data
{
    public class DbESaudeApiContext : DbContext
    {
        public DbESaudeApiContext(DbContextOptions<DbESaudeApiContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Denuncia> Denuncia { get; set; }
        public DbSet<DenunciaMovimento> DenunciaMovimento { get; set; }
        public DbSet<DenunciaMovimentoTipo> DenunciaMovimentoTipo { get; set; }
        public DbSet<DenunciaTipo> DenunciaTipo { get; set; }
    }
}