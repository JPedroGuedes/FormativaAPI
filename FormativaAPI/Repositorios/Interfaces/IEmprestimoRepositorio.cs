using FormativaAPI.Models;

namespace FormativaAPI.Repositorios.Interfaces;

public interface IEmprestimoRepositorio
{
    Task<EmprestimoModel> Create(EmprestimoModel emprestimo);
    Task<EmprestimoModel> Read(int id);
    Task<EmprestimoModel> Update(EmprestimoModel emprestimo, int id);
    Task<bool> Delete(int id);
    Task<List<EmprestimoModel>> ReadAll();
}