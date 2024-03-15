using FormativaAPI.Enums;

namespace FormativaAPI.Models;

public class EmprestimoModel
{
    public int Id { get; set; }
    public DateOnly DataEmprestimo { get; set; }
    public DateOnly DataDevolucao { get; set; }
    public StatusEmprestimo Status { get; set; }
    
    public virtual LivroModel? Livro { get; set; }
    public int? LivroId { get; set; }
    
    public virtual UsuarioModel? Usuario { get; set; }
    public int UsuarioId { get; set; }
}