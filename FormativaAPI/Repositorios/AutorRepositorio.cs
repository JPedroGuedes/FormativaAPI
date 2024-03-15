using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Repositorios;

public class AutorRepositorio : IAutorRepositorio
{
    private readonly SistemaBibliotecaDBContex _dbContext;
    public AutorRepositorio(SistemaBibliotecaDBContex SistemaBibliotecaDBContex)
    {
        _dbContext = SistemaBibliotecaDBContex;
    }
    public async Task<AutorModel> Create(AutorModel autor)
    {
        await _dbContext.Autors.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    public async Task<AutorModel> Read(int id)
    {
        return await _dbContext.Autors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<AutorModel> Update(AutorModel autor, int id)
    {
        AutorModel autorPorId = await Read(id);


        if (autorPorId == null)
        {
            throw new Exception($"Autor do ID: {id} não foi encontrado");
        }

        autorPorId.Nome = autor.Nome;
        autorPorId.Nacionalidade = autor.Nacionalidade;
        autorPorId.DataNascimento = autor.DataNascimento;

        _dbContext.Autors.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }

    public async Task<bool> Delete(int id)
    {
        AutorModel autorPorId = await Read(id);
        if (autorPorId == null)
        {
            throw new Exception($"Autor do Id: {id} não foi encontrado");
        }

        _dbContext.Autors.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<AutorModel>> ReadAll()
    {
        return await _dbContext.Autors.ToListAsync();
    }
}