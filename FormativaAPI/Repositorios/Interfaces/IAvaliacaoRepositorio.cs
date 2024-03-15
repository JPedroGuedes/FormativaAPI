using FormativaAPI.Models;

namespace FormativaAPI.Repositorios.Interfaces;

public interface IAvaliacaoRepositorio
{
    Task<AvaliacaoModel> Create(AvaliacaoModel avaliacao);
    Task<AvaliacaoModel> Read(int id);
    Task<AvaliacaoModel> Update(AvaliacaoModel avaliacao, int id);
    Task<bool> Delete(int id);
    Task<List<AvaliacaoModel>> ReadAll();
}