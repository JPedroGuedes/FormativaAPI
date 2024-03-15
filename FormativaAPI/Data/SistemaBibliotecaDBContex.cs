using FormativaAPI.Data.Map;
using FormativaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Data;

public class SistemaBibliotecaDBContex : DbContext
{
    public SistemaBibliotecaDBContex(DbContextOptions<SistemaBibliotecaDBContex> options) : base(options) { }
    
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<AutorModel> Autors { get; set; }
    public DbSet<AvaliacaoModel> Avaliacaos { get; set; }
    public DbSet<EditoraModel> Editoras { get; set; }
    public DbSet<EmprestimoModel> Emprestimos { get; set; }
    public DbSet<LivroModel> Livros { get; set; }
    public DbSet<ReservaModel> Reservas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new AvaliacaoMap());
        modelBuilder.ApplyConfiguration(new AutorMap());
        modelBuilder.ApplyConfiguration(new EditoraMap());
        modelBuilder.ApplyConfiguration(new EmprestimoMap());
        modelBuilder.ApplyConfiguration(new LivroMap());
        modelBuilder.ApplyConfiguration(new ReservaMap());


        base.OnModelCreating(modelBuilder);
    }
}