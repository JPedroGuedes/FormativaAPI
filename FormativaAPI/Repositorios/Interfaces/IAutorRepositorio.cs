using FormativaAPI.Models;

namespace FormativaAPI.Repositorios.Interfaces;

public interface IAutorRepositorio
{
    Task<AutorModel> Create(AutorModel autor);
    Task<AutorModel> Read(int id);
    Task<AutorModel> Update(AutorModel autor, int id);
    Task<bool> Delete(int id);
    Task<List<AutorModel>> ReadAll();
}