
using BookStore.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
            
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base (options)
        {

        }
        
        public DbSet<Livro> Livro { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());
        }

    }
}
