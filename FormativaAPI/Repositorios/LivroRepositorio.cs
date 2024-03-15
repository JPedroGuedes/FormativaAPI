using FormativaAPI.Data;
using FormativaAPI.Models;
using FormativaAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormativaAPI.Repositorios;

public class LivroRepositorio : ILivroRepositorio
{
    private readonly SistemaBibliotecaDBContex _dbContext;    
    public LivroRepositorio(SistemaBibliotecaDBContex SistemaBibliotecaDBContex)
    {
        _dbContext = SistemaBibliotecaDBContex;
    }
    public async Task<LivroModel> Create(LivroModel livro)
    {
        await _dbContext.Livros.AddAsync(livro);
        await _dbContext.SaveChangesAsync();

        return livro;
    }

    public async Task<LivroModel> Read(int id)
    {
        return await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<LivroModel> Update(LivroModel livro, int id)
    {
        LivroModel livroPorId = await Read(id);


        if (livroPorId == null)
        {
            throw new Exception($"Livro do ID: {id} não foi encontrado");
        }
        
        livroPorId.Titulo = livro.Titulo;
        livroPorId.Genero = livro.Genero;
        livroPorId.AnoPublicacao = livro.AnoPublicacao;
        livroPorId.ISBN = livro.ISBN;
        livroPorId.Sinopse = livro.Sinopse;

        _dbContext.Livros.Update(livroPorId);
        await _dbContext.SaveChangesAsync();

        return livroPorId;
    }

    public async Task<bool> Delete(int id)
    {
        LivroModel livroPorId = await Read(id);
        if (livroPorId == null)
        {
            throw new Exception($"Editora do Id: {id} não foi encontrado");
        }

        _dbContext.Livros.Remove(livroPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<LivroModel>> ReadAll()
    {
        return await _dbContext.Livros.ToListAsync();
    }
}