using FormativaAPI.Models;

namespace FormativaAPI.Repositorios.Interfaces;

public interface IEditoraRepositorio
{
    Task<EditoraModel> Create(EditoraModel editora);
    Task<EditoraModel> Read(int id);
    Task<EditoraModel> Update(EditoraModel editora, int id);
    Task<bool> Delete(int id);
    Task<List<EditoraModel>> ReadAll();
}