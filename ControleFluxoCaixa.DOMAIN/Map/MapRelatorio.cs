using ControleFluxoCaixa.DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFluxoCaixa.DOMAIN.Map
{
    public class MapRelatorio : IEntityTypeConfiguration<Relatorio>
    {
        public void Configure(EntityTypeBuilder<Relatorio> builder)
        {
            builder.ToTable("Relatorio");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalDebitos).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TotalCreditos).IsRequired();
            builder.Property(x => x.SaldoAtual).IsRequired();
        }
    }
}
