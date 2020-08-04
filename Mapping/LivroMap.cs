using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Mapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Nome).HasMaxLength(60).IsRequired();
            builder.Property(l => l.ISBN).HasMaxLength(32).IsRequired();
            builder.Property(l => l.Categoria).IsRequired();
            builder.Property(l => l.DataLancamento).IsRequired();
        }
    }
}
