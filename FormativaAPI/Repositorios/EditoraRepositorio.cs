using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Repositorios;

public class EditoraRepositorio : IEditoraRepositorio
{
    private readonly SistemaBibliotecaDBContex _dbContext;    
    public EditoraRepositorio(SistemaBibliotecaDBContex SistemaBibliotecaDBContex)
    {
        _dbContext = SistemaBibliotecaDBContex;
    }
    public async Task<EditoraModel> Create(EditoraModel editora)
    {
        await _dbContext.Editoras.AddAsync(editora);
        await _dbContext.SaveChangesAsync();

        return editora;
    }

    public async Task<EditoraModel> Read(int id)
    {
        return await _dbContext.Editoras.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<EditoraModel> Update(EditoraModel editora, int id)
    {
        EditoraModel editoraPorId = await Read(id);


        if (editoraPorId == null)
        {
            throw new Exception($"Avaliacao do ID: {id} não foi encontrado");
        }
        
        editoraPorId.Nome = editora.Nome;
        editoraPorId.Localizacao = editora.Localizacao;
        editoraPorId.AnoFundacao = editora.AnoFundacao;

        _dbContext.Editoras.Update(editoraPorId);
        await _dbContext.SaveChangesAsync();

        return editoraPorId;
    }

    public async Task<bool> Delete(int id)
    {
        EditoraModel editoraPorId = await Read(id);
        if (editoraPorId == null)
        {
            throw new Exception($"Editora do Id: {id} não foi encontrado");
        }

        _dbContext.Editoras.Remove(editoraPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<EditoraModel>> ReadAll()
    {
        return await _dbContext.Editoras.ToListAsync();
    }
}