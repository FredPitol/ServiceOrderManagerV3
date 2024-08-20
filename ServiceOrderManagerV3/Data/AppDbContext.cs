using Microsoft.EntityFrameworkCore;
using ServiceOrderManagerV3.Models.Entities;

namespace ServiceOrderManagerV3.Data
{
    public class AppDbContext : DbContext
    {
        // Construtor que cria options do contexto dessa classe chamada options e passa para a classe pai
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // db = Representa um colecao de um tipo especificado , clients = nome da tabela
        // Fornece a migration as tabelas que serao criadas
        public DbSet<Client> Clients { get; set; }
    }
}
