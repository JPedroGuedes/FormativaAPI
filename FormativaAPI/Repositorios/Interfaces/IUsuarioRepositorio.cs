using FormativaAPI.Models;

namespace FormativaAPI.Repositorios.Interfaces;

public interface IUsuarioRepositorio
{
    Task<UsuarioModel> Create(UsuarioModel usuario);
    Task<UsuarioModel> Read(int id);
    Task<UsuarioModel> Update(UsuarioModel usuario, int id);
    Task<bool> Delete(int id);
    Task<List<UsuarioModel>> ReadAll();
}