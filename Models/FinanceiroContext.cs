using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace contigencia.Models
{
    public partial class FinanceiroContext : DbContext
    {
        public FinanceiroContext()
        {
        }

        public FinanceiroContext(DbContextOptions<FinanceiroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<Lancamento> Lancamento { get; set; }
        public virtual DbSet<PlanoContas> PlanoContas { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(e => e.Idconta)
                    .HasName("PRIMARY");

                entity.ToTable("conta");

                entity.HasIndex(e => e.UsuarioIdUsuario)
                    .HasName("fk_Conta_Usuario_idx");

                entity.Property(e => e.Idconta).HasColumnType("int(11)");

                entity.Property(e => e.NomeConta)
                    .IsRequired()
                    .HasColumnName("nomeConta")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Saldo)
                    .HasColumnName("saldo")
                    .HasColumnType("decimal(9,2)");

                entity.Property(e => e.UsuarioIdUsuario)
                    .HasColumnName("Usuario_idUsuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UsuarioIdUsuarioNavigation)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.UsuarioIdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Conta_Usuario");
            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.Idlanc)
                    .HasName("PRIMARY");

                entity.ToTable("lancamento");

                entity.HasIndex(e => e.IdTransacao)
                    .HasName("Id_transacao");

                entity.Property(e => e.Idlanc).HasColumnType("int(11)");

                entity.Property(e => e.IdTransacao)
                    .HasColumnName("Id_transacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nomelanc)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Valor).HasColumnType("decimal(9,2)");

                entity.HasOne(d => d.IdTransacaoNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdTransacao)
                    .HasConstraintName("lancamento_ibfk_1");
            });

            modelBuilder.Entity<PlanoContas>(entity =>
            {
                entity.HasKey(e => e.IdPlanoContas)
                    .HasName("PRIMARY");

                entity.ToTable("plano_contas");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("usuario_id");

                entity.Property(e => e.IdPlanoContas)
                    .HasColumnName("idPlano_contas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("char(1)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PlanoContas)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plano_contas_ibfk_1");
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => e.IdTransacao)
                    .HasName("PRIMARY");

                entity.ToTable("transacao");

                entity.HasIndex(e => e.ContaIdconta)
                    .HasName("fk_Transacao_Conta1_idx");

                entity.HasIndex(e => e.PlanoContasIdPlanoContas)
                    .HasName("fk_Transacao_Plano_Contas1_idx");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("transacao_ibfk_1");

                entity.Property(e => e.IdTransacao)
                    .HasColumnName("idTransacao")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContaIdconta)
                    .HasColumnName("Conta_idconta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PlanoContasIdPlanoContas)
                    .HasColumnName("Plano_Contas_idPlano_Contas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasColumnType("char(1)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(9,2)");

                entity.HasOne(d => d.ContaIdcontaNavigation)
                    .WithMany(p => p.Transacao)
                    .HasForeignKey(d => d.ContaIdconta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Transacao_Conta1");

                entity.HasOne(d => d.PlanoContasIdPlanoContasNavigation)
                    .WithMany(p => p.Transacao)
                    .HasForeignKey(d => d.PlanoContasIdPlanoContas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Transacao_Plano_Contas1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Transacao)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transacao_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
