using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data;

/// <summary>
/// Contexto do banco de dados - Equivalente ao Eloquent ORM do Laravel
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets - Equivalente aos Models do Laravel
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Favorite> Favorites { get; set; }

    // DbSets do sistema WBM
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoItem> PedidoItems { get; set; }
    public DbSet<Op> Ops { get; set; }
    public DbSet<OrdemServico> OrdensServico { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Estoque> Estoques { get; set; }
    public DbSet<Relatorio> Relatorios { get; set; }
    public DbSet<RelatorioArquivo> RelatorioArquivos { get; set; }
    public DbSet<MensagemSemana> MensagensSemana { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da tabela Users
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Password).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique(); // Email único
        });

        // Configuração da tabela Products
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Price).HasPrecision(18, 2);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Image).HasMaxLength(500);
        });

        // Configuração da tabela Favorites (relacionamento N:N entre User e Product)
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id);

            // Relacionamento com User
            entity.HasOne(e => e.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento com Product
            entity.HasOne(e => e.Product)
                .WithMany(p => p.Favorites)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índice único: um usuário não pode favoritar o mesmo produto duas vezes
            entity.HasIndex(e => new { e.UserId, e.ProductId }).IsUnique();
        });

        // ========== CONFIGURAÇÕES DO SISTEMA WBM ==========

        // Configuração da tabela Clientes
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Documento).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Telefone).HasMaxLength(50);
            entity.Property(e => e.Endereco).HasMaxLength(500);
        });

        // Configuração da tabela PedidoItems
        modelBuilder.Entity<PedidoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Item).IsRequired().HasMaxLength(255);
            entity.Property(e => e.ValorUnitario).HasPrecision(18, 2);

            // Relacionamento com Pedido
            entity.HasOne(e => e.Pedido)
                .WithMany(p => p.Items)
                .HasForeignKey(e => e.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuração da tabela Pedidos
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Numero).IsRequired().HasMaxLength(100);
            entity.Property(e => e.NumeroCliente).HasMaxLength(100);
            entity.Property(e => e.Cliente).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Prioridade).HasMaxLength(50);

            // Relacionamento N:N com Op (tabela pivô op_pedido)
            entity.HasMany(e => e.Ops)
                .WithMany(o => o.Pedidos)
                .UsingEntity(
                    "OpPedido",
                    l => l.HasOne(typeof(Op)).WithMany().HasForeignKey("OpId"),
                    r => r.HasOne(typeof(Pedido)).WithMany().HasForeignKey("PedidoId")
                );

            // Relacionamento N:N com OrdemServico (tabela pivô os_pedido)
            entity.HasMany(e => e.Ordens)
                .WithMany(o => o.Pedidos)
                .UsingEntity(
                    "OsPedido",
                    l => l.HasOne(typeof(OrdemServico)).WithMany().HasForeignKey("OrdemServicoId"),
                    r => r.HasOne(typeof(Pedido)).WithMany().HasForeignKey("PedidoId")
                );
        });

        // Configuração da tabela Ops
        modelBuilder.Entity<Op>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Numero).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Item).HasMaxLength(255);
            entity.Property(e => e.Responsavel).HasMaxLength(255);
            entity.Property(e => e.Setor).HasMaxLength(100);
            entity.Property(e => e.Prioridade).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        // Configuração da tabela OrdensServico
        modelBuilder.Entity<OrdemServico>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Numero).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.OpRef).HasMaxLength(100);
            entity.Property(e => e.Descricao).HasMaxLength(1000);
            entity.Property(e => e.Cliente).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Prioridade).HasMaxLength(50);
            entity.Property(e => e.Responsible).HasMaxLength(255);
            entity.Property(e => e.Sector).HasMaxLength(100);
        });

        // Configuração da tabela Tickets
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Titulo).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Descricao).HasMaxLength(2000);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Prioridade).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        // Configuração da tabela Estoques
        modelBuilder.Entity<Estoque>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Codigo).HasMaxLength(100);
            entity.Property(e => e.Categoria).HasMaxLength(100);
            entity.Property(e => e.Unidade).HasMaxLength(50);
            entity.Property(e => e.Localizacao).HasMaxLength(255);
            entity.Property(e => e.Preco).HasPrecision(18, 2);
        });

        // Configuração da tabela Relatorios
        modelBuilder.Entity<Relatorio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Titulo).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Setor).HasMaxLength(100);
            entity.Property(e => e.Conteudo).HasMaxLength(5000);
            entity.Property(e => e.AutorNome).HasMaxLength(255);
            entity.Property(e => e.ArquivoPath).HasMaxLength(500);
            entity.Property(e => e.ArquivoNome).HasMaxLength(255);
        });

        // Configuração da tabela RelatorioArquivos
        modelBuilder.Entity<RelatorioArquivo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ArquivoPath).HasMaxLength(500);
            entity.Property(e => e.ArquivoNome).HasMaxLength(255);

            // Relacionamento com Relatorio
            entity.HasOne(e => e.Relatorio)
                .WithMany(r => r.Arquivos)
                .HasForeignKey(e => e.RelatorioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuração da tabela MensagensSemana
        modelBuilder.Entity<MensagemSemana>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Conteudo).HasMaxLength(2000);
            entity.Property(e => e.Responsavel).HasMaxLength(255);
        });
    }
}
