using FormativaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormativaAPI.Data.Map;

public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
{
    public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Pontuacao).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Comentario).IsRequired().HasMaxLength(255);
        builder.Property(x => x.DataAvaliacao).IsRequired().HasMaxLength(255);
        
        builder.Property(x => x.LivroId).IsRequired().HasMaxLength(255);
        builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
        
        builder.HasOne(x => x.Livro);
        builder.HasOne(x => x.Usuario);
    }
}