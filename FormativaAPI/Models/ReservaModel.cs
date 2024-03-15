using FormativaAPI.Enums;

namespace FormativaAPI.Models;

public class ReservaModel
{
    public int Id { get; set; }
    public DateOnly DataReserva { get; set; }
    public StatusReserva Status { get; set; }
    
    public virtual LivroModel? Livro { get; set; }
    public int? LivroId { get; set; }
    
    public virtual UsuarioModel? Usuario { get; set; }
    public int UsuarioId { get; set; }
}