using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiEstoque.Models;

namespace WebApiEstoque.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cor).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Quantidade);
            builder.Property(x => x.Tamanho).IsRequired().HasMaxLength(4);
        }
    }
}
