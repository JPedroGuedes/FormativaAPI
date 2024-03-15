using FormativaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormativaAPI.Data.Map;

public class ReservaMap : IEntityTypeConfiguration<ReservaModel>
{
    public void Configure(EntityTypeBuilder<ReservaModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DataReserva).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Status).IsRequired().HasMaxLength(255);
        
        builder.Property(x => x.LivroId).IsRequired().HasMaxLength(255);
        builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
        
        builder.HasOne(x => x.Livro);
        builder.HasOne(x => x.Usuario);
    }
}