namespace Eliza.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaseDados : DbContext
    {
        public BaseDados()
            : base("name=BaseDados")
        {
        }

        public virtual DbSet<Acoes> Acoes { get; set; }
        public virtual DbSet<Dispensa> Dispensa { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Utensilios> Utensilios { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }
        public virtual DbSet<Utilizador_receita> Utilizador_receita { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acoes>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Acoes>()
                .HasMany(e => e.Ingrediente)
                .WithMany(e => e.Acoes)
                .Map(m => m.ToTable("IngredienteAcao").MapLeftKey("idAcao").MapRightKey("idIngrediente"));

            modelBuilder.Entity<Acoes>()
                .HasMany(e => e.Utensilios)
                .WithMany(e => e.Acoes)
                .Map(m => m.ToTable("UtensilioAcao").MapLeftKey("idAcao").MapRightKey("idUtensilio"));

            modelBuilder.Entity<Ingrediente>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Ingrediente>()
                .Property(e => e.descrição)
                .IsUnicode(false);

            modelBuilder.Entity<Ingrediente>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Ingrediente>()
                .HasMany(e => e.Dispensa)
                .WithRequired(e => e.Ingrediente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.tempo)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Receita>()
                .HasMany(e => e.Utilizador_receita)
                .WithRequired(e => e.Receita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utensilios>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Utensilios>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.rua)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.porta)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.cod_postal)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.intolerancias)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Utilizador>()
                .HasMany(e => e.Dispensa)
                .WithRequired(e => e.Utilizador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utilizador>()
                .HasMany(e => e.Utilizador_receita)
                .WithRequired(e => e.Utilizador)
                .WillCascadeOnDelete(false);
        }
    }
}
