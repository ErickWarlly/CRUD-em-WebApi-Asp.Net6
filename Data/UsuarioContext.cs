using System.Runtime.CompilerServices;


using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var alterar = modelBuilder.Entity<Usuario>();
            alterar.ToTable("tb_usuario");
            alterar.Property(y => y.Id).HasColumnName("id").ValueGeneratedOnAdd();
            alterar.Property(y => y.Nome).HasColumnName("nome").IsRequired();
            alterar.Property(y => y.DataNascimento).HasColumnName("data_nascimento");

            alterar.HasKey(y => y.Id);
        }
    }
}