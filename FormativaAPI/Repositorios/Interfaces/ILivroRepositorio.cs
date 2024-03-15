using FormativaAPI.Models;

namespace FormativaAPI.Repositorios.Interfaces;

public interface ILivroRepositorio
{
    Task<LivroModel> Create(LivroModel livro);
    Task<LivroModel> Read(int id);
    Task<LivroModel> Update(LivroModel livro, int id);
    Task<bool> Delete(int id);
    Task<List<LivroModel>> ReadAll();
}