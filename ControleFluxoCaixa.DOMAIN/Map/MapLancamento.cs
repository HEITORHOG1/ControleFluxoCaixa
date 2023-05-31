using ControleFluxoCaixa.DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFluxoCaixa.DOMAIN.Map
{
    public class MapLancamento : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("Lancamento");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
        }
    }
}
