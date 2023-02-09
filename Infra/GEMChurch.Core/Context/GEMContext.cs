using GEMEscolar.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GEMEscolar.Core.Context
{
    public partial class GEMContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public GEMContext(DbContextOptions<GEMContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Mensalidades> Mensalidades { get; set; }
        public virtual DbSet<Professores> Professores { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
