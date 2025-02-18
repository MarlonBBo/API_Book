using API_Book.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Book.Infra
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) 
        {
        }

        public DbSet<Autor> Autores {  get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
