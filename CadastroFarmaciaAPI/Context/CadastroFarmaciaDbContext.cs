using System;
using System.Collections.Generic;
using CadastroFarmaciaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CadastroFarmaciaAPI.Context
{
    public partial class CadastroFarmaciaDbContext : DbContext
    {
        public CadastroFarmaciaDbContext()
        {
        }

        public CadastroFarmaciaDbContext(DbContextOptions<CadastroFarmaciaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<EntregaProduto> EntregaProdutos { get; set; } = null!;
        public virtual DbSet<Farmaceutico> Farmaceuticos { get; set; } = null!;
        public virtual DbSet<Fornecedor> Fornecedors { get; set; } = null!;
        public virtual DbSet<PrescricaoMedica> PrescricaoMedicas { get; set; } = null!;
        public virtual DbSet<ProdutoFarmaceutico> ProdutoFarmaceuticos { get; set; } = null!;
        public virtual DbSet<VendaProduto> VendaProdutos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LENOVO-DIEGO\\SQLEXPRESS;  Initial Catalog=CadastroFarmaciaDb;  Trusted_Connection=TRUE;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__Cliente__9B8553FCA2B50FA9");

                entity.ToTable("Cliente");

                entity.Property(e => e.Idcliente)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCliente");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Endereco).HasMaxLength(255);

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<EntregaProduto>(entity =>
            {
                entity.HasKey(e => e.Identrega)
                    .HasName("PK__EntregaP__9670127CBD2F6CB8");

                entity.Property(e => e.Identrega)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEntrega");

                entity.Property(e => e.DataEntrega).HasColumnType("date");

                entity.Property(e => e.FornecedorId).HasColumnName("FornecedorID");

                entity.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.EntregaProdutos)
                    .HasForeignKey(d => d.FornecedorId)
                    .HasConstraintName("FK__EntregaPr__Forne__59063A47");
            });

            modelBuilder.Entity<Farmaceutico>(entity =>
            {
                entity.HasKey(e => e.Idfarmacutico)
                    .HasName("PK__Farmaceu__ADE9FBBCA5EB7ECC");

                entity.ToTable("Farmaceutico");

                entity.Property(e => e.Idfarmacutico)
                    .ValueGeneratedNever()
                    .HasColumnName("IDFarmacutico");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.Property(e => e.NumeroRegistroProfissional).HasMaxLength(50);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.Idfornecedor)
                    .HasName("PK__Forneced__7E2B6B95FA11532C");

                entity.ToTable("Fornecedor");

                entity.Property(e => e.Idfornecedor)
                    .ValueGeneratedNever()
                    .HasColumnName("IDFornecedor");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Endereco).HasMaxLength(255);

                entity.Property(e => e.NomeFornecedor).HasMaxLength(100);

                entity.Property(e => e.NumeroTelefone).HasMaxLength(20);
            });

            modelBuilder.Entity<PrescricaoMedica>(entity =>
            {
                entity.HasKey(e => e.Idprescricao)
                    .HasName("PK__Prescric__C807FE499B15210C");

                entity.ToTable("PrescricaoMedica");

                entity.Property(e => e.Idprescricao)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPrescricao");

                entity.Property(e => e.DataPrescricao).HasColumnType("date");

                entity.Property(e => e.FarmaceuticoId).HasColumnName("FarmaceuticoID");

                entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

                entity.HasOne(d => d.Farmaceutico)
                    .WithMany(p => p.PrescricaoMedicas)
                    .HasForeignKey(d => d.FarmaceuticoId)
                    .HasConstraintName("FK__Prescrica__Farma__5441852A");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.PrescricaoMedicas)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK__Prescrica__Pacie__534D60F1");
            });

            modelBuilder.Entity<ProdutoFarmaceutico>(entity =>
            {
                entity.HasKey(e => e.Idproduto)
                    .HasName("PK__ProdutoF__4283A371F6AEA9D6");

                entity.ToTable("ProdutoFarmaceutico");

                entity.Property(e => e.Idproduto)
                    .ValueGeneratedNever()
                    .HasColumnName("IDProduto");

                entity.Property(e => e.DataValidade).HasColumnType("date");

                entity.Property(e => e.Descricao).HasMaxLength(255);

                entity.Property(e => e.Fabricante).HasMaxLength(100);

                entity.Property(e => e.NomeProduto).HasMaxLength(100);

                entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<VendaProduto>(entity =>
            {
                entity.HasKey(e => e.Idvenda)
                    .HasName("PK__VendaPro__2712B59690BBBF5C");

                entity.Property(e => e.Idvenda)
                    .ValueGeneratedNever()
                    .HasColumnName("IDVenda");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.DataVenda).HasColumnType("date");

                entity.Property(e => e.FarmaceuticoId).HasColumnName("FarmaceuticoID");

                entity.Property(e => e.ValorTotal).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.VendaProdutos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__VendaProd__Clien__4F7CD00D");

                entity.HasOne(d => d.Farmaceutico)
                    .WithMany(p => p.VendaProdutos)
                    .HasForeignKey(d => d.FarmaceuticoId)
                    .HasConstraintName("FK__VendaProd__Farma__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
